using System.Data;
using Dapper;
using DevControl.Data;
using DevControl.Models;
using DevControl.Models.Establecimientos;
using DevControl.Models.Viepi;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;

namespace DevControl.Services
{
    public class Data : IData
    {
        private readonly DevContext _context;
        private readonly IConfiguration iconfiguration;

        public Data(DevContext context, IConfiguration iconfiguration)
        {
            _context = context;
            this.iconfiguration = iconfiguration;
        }

        public List<T> LoadData<T, U>(string sql, U parameters, string connectionString)
        {
            using (IDbConnection connection = new SqlConnection(connectionString))
            {
                List<T> rows = connection.Query<T>(sql, parameters).ToList();
                return rows;
            }

        }

        public List<T> LoadDataVp<T, U>(string sql, U parameters, string connectionString)
        {
            using (IDbConnection connection = new MySqlConnection(connectionString))
            {
                List<T> rows = connection.Query<T>(sql, parameters).ToList();
                return rows;
            }

        }

        public IEnumerable<UsuariosViewModel> GetTbUsuarios()
        {
            var sql = @"SELECT
                                a.Id,
                                    u.uname as Usuario, u.Activo, u.Nombres, u.Apellidos, u.Email,
                                    t.centro as Centro, t.codigo as Codigo, t.Activo as Estado,
                                    CONCAT_WS(' ',case when len(t.COD_ONE_PR)=1 then CONCAT('0',t.COD_ONE_PR) else CAST(t.COD_ONE_PR as varchar) end,t.Provincia) as Provincia,
                                    
                                    CONCAT_WS(' ',CONCAT(case when len(t.COD_ONE_PR)=1 then CONCAT('0',t.COD_ONE_PR) else CAST(t.COD_ONE_PR as varchar) end,COD_ONE_MU),t.Municipio) as Municipio, Institucio as Institucion
                                from Usuarios U
                                    left JOIN Usuarios_centros A
                                    on 
                                u.uname=a.uname
                                    left JOIN tbcentros  t
                                    on 
                                t.Id=a.Centro
                                
                                ";
            //  var customers=""'

            using (IDbConnection connection = new SqlConnection(iconfiguration.GetConnectionString("DataSof")))
            {

                var customers = connection.Query<UsuariosViewModel>(sql);

                return customers;
            };
        }

        public IEnumerable<vmEstablecimientos> GetVmEstablecimientos()
        {
            var sql = @"
                            select
                                    e.id,
                                    e.Centro, i.Institucion, c.Categoria, sc.Subsector, e.Nivel, CONCAT_WS(' ', t.codigo, t.Provincia) as Provincia, CONCAT_WS(' ',m.codigo,m.municipio) as Municipio, d.Distrito, s.barrio as Sector,
                                    ' ' as Area,
                                    e.prueba,
                                    case when Laboratorio=1 then 'Si' else 'No' end as Laboratorio,
                                    case when IdViepi>0 then 'Si' else 'No' end as Viepi,
                                    case when sat is not null then 'Si' else 'No' end as Sat

                                from tbEstablecimientos e
                                    inner JOIN tbProvincias t
                                    on
                                t.id=e.Provincia
                                    inner JOIN tbMunicipios m
                                    on 
                                m.Id=e.Municipio
                                    left JOIN tbDistritos d
                                    on 
                                d.Id=e.Distrito
                                    left JOIN tbSectores s
                                    on 
                                s.Id=e.Sector
                                    inner JOIN tbInstitucion i
                                    on 
                                i.Id=e.Institucion
                                    INNER JOIN tbCategorias c
                                    on 
                                c.Id=e.Categoria
                                    inner JOIN tbSubsectors sc
                                    on 
                                sc.Id=e.Subsector
                                
                                
                                ";
            //  var customers=""'

            using (IDbConnection connection = new SqlConnection(iconfiguration.GetConnectionString("DevControlContext")))
            {

                var customers = connection.Query<vmEstablecimientos>(sql);

                return customers;
            };
        }

        public void AddUsuarioCentro(int usuario, int centro)
        {
            var userQuery = "select * from usuarios where id=" + usuario;
            var centroQuery = "select * from tbcentros where id=" + centro;

            var user = LoadData<TbUsuarios, dynamic>(userQuery, new { }, iconfiguration.GetConnectionString("DataSof"));

            var estab = LoadData<TbCentros, dynamic>(centroQuery, new { }, iconfiguration.GetConnectionString("DataSof"));

            if (user.Count() == 1 & estab.Count() == 1)
            {

            }




        }

        public void AddEstablecimiento(TbEstablecimientos tbEstablecimientos)
        {

            var cat = _context.tbCategorias.Where(x => x.Id == tbEstablecimientos.Categoria).SingleOrDefault();
            var Qtipo = "select * from tipoesta where idi=" + tbEstablecimientos.Institucion + " and nombre='" + cat.Categoria + "'";

            var tipo = LoadDataVp<tipoesta, dynamic>(Qtipo, new { }, iconfiguration.GetConnectionString("DataViepi")).SingleOrDefault();


            var Qgeo = @"SELECT idadm1,idadm2
                                from DevAdm.dbo.tbMunicipios t 
                                inner JOIN viepi.dbo.cntry_adm2 c 
                                on 
                                c.Provincia+c.Municipio collate SQL_Latin1_General_CP1_CI_AS = t.codigo
                                where id=" + tbEstablecimientos.Municipio;
            var geo = LoadData<cntry_adm, dynamic>(Qgeo, new { }, iconfiguration.GetConnectionString("DevControlContext")).SingleOrDefault();

            var area = _context.tbArea.Where(x => x.id == tbEstablecimientos.Area).SingleOrDefault();


            var Qnivel = @"
                        select 
                            n.idn1, n.nombre as region, idn2, n.idi, institucion, n2.nombre as provincia, n2.provincia as prov
                        from viepi.dbo.nivel1 n
                            inner JOIN viepi.dbo.nivel2 n2
                            on 
                        n2.idn1=n.idn1
                            inner JOIN viepi.dbo.instituciones i
                            on i.idi=n.idi                      
                            where n.idi=" + tbEstablecimientos.Institucion + " and n2.nombre='" + area.Area + "'";

            var nivel = LoadData<Niveles, dynamic>(Qnivel, new { }, iconfiguration.GetConnectionString("DevControlContext")).SingleOrDefault();


            var tipoesta = tipo.idt;
            var i = tbEstablecimientos.Institucion;
            var x = 0;

            vEstablecimientos est = new()
            {
                nombre = tbEstablecimientos.Centro,
                institucion = tbEstablecimientos.Institucion,
                nivel1 = nivel.idn1,
                nivel2 = nivel.idn2,
                tipo = tipoesta,
                idadm1 = geo.idadm1,
                idadm2 = geo.idadm2,
                pruebas = tbEstablecimientos.prueba,
                lab = tbEstablecimientos.Laboratorio,
                estado = tbEstablecimientos.Estado
            };

            var insert = "INSERT INTO establecimientos  (nombre ,institucion,nivel1 ,nivel2,tipo,idadm1,idadm2,pruebas,lab,estado)           values  (@nombre, @institucion,@nivel1,@nivel2,@tipo,@idadm1,@idadm2,@pruebas,@lab,@estado) ";
            using (IDbConnection connection = new MySqlConnection(iconfiguration.GetConnectionString("DataViepi")))
            {
                connection.Execute(insert,  new { est.nombre, est.institucion, est.nivel1, est.nivel2, est.tipo, est.idadm1, est.idadm2, est.pruebas, est.lab, est.estado } );
            }

            // how to execute an insert statement using a class with dapper?






            //Source: https://stackoverflow.com/questions/5957774



        }



        public void UpdateEstablecimiento(TbEstablecimientos tbEstablecimientos)
        {
            Console.WriteLine(tbEstablecimientos.Id);

            var cat = _context.tbCategorias.Where(x => x.Id == tbEstablecimientos.Categoria).SingleOrDefault();
            var Qtipo = "select * from tipoesta where idi=" + tbEstablecimientos.Institucion + " and nombre='" + cat.Categoria + "'";

            var tipo = LoadDataVp<tipoesta, dynamic>(Qtipo, new { }, iconfiguration.GetConnectionString("DataViepi")).SingleOrDefault();


            var Qgeo = @"SELECT idadm1,idadm2
                                from DevAdm.dbo.tbMunicipios t 
                                inner JOIN viepi.dbo.cntry_adm2 c 
                                on 
                                c.Provincia+c.Municipio collate SQL_Latin1_General_CP1_CI_AS = t.codigo
                                where id=" + tbEstablecimientos.Municipio;
            var geo = LoadData<cntry_adm, dynamic>(Qgeo, new { }, iconfiguration.GetConnectionString("DevControlContext")).SingleOrDefault();

            var area = _context.tbArea.Where(x => x.id == tbEstablecimientos.Area).SingleOrDefault();


            var Qnivel = @"
                        select 
                            n.idn1, n.nombre as region, idn2, n.idi, institucion, n2.nombre as provincia, n2.provincia as prov
                        from viepi.dbo.nivel1 n
                            inner JOIN viepi.dbo.nivel2 n2
                            on 
                        n2.idn1=n.idn1
                            inner JOIN viepi.dbo.instituciones i
                            on i.idi=n.idi                      
                            where n.idi=" + tbEstablecimientos.Institucion + " and n2.nombre='" + area.Area + "'";

            var nivel = LoadData<Niveles, dynamic>(Qnivel, new { }, iconfiguration.GetConnectionString("DevControlContext")).SingleOrDefault();


            var tipoesta = tipo.idt;
            var i = tbEstablecimientos.Institucion;
            var x = 0;

            vEstablecimientos est = new()
            {
                nombre = tbEstablecimientos.Centro,
                institucion = tbEstablecimientos.Institucion,
                nivel1 = nivel.idn1,
                nivel2 = nivel.idn2,
                tipo = tipoesta,
                idadm1 = geo.idadm1,
                idadm2 = geo.idadm2,
                pruebas = tbEstablecimientos.prueba,
                lab = tbEstablecimientos.Laboratorio,
                estado = tbEstablecimientos.Estado,
                id=Convert.ToInt32(tbEstablecimientos.IdViepi)
            };

            var insert = "update  establecimientos set  institucion=@institucion,           nivel1=@nivel1, nivel2=@nivel2,             tipo=@tipo,             idadm1=@idadm1,             idadm2=@idadm2,             pruebas=@pruebas,           lab=@lab,             estado=@estado           where id=@id";
            using (IDbConnection connection = new MySqlConnection(iconfiguration.GetConnectionString("DataViepi")))
            {
                connection.Execute(insert,  new { est.nombre, est.institucion, est.nivel1, est.nivel2, est.tipo, est.idadm1, est.idadm2, est.pruebas, est.lab, est.estado, est.id } );
            }

            // how to execute an insert statement using a class with dapper?






            //Source: https://stackoverflow.com/questions/5957774



        }



    }
}