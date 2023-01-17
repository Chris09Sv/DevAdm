using System.Data;
using Dapper;
using DevControl.Data;
using DevControl.Models;
using DevControl.Models.Establecimientos;
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
            
            
        }
    }
}