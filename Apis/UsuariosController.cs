using System.Data;
using Dapper;
using DevControl.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;

namespace DevControl.Apis
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        private readonly DevContext _context;
        private readonly IConfiguration iconfiguration;

        public UsuariosController(DevContext context, IConfiguration iconfiguration)
        {
            _context = context;
            this.iconfiguration = iconfiguration;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var sql = @"SELECT
    u.uname as Usuario, u.Activo, u.Nombres, u.Apellidos, u.Email,
    t.centro as Centro, t.codigo as Codigo, t.Activo,
    CONCAT_WS(' ',case when len(t.COD_ONE_PR)=1 then CONCAT('0',t.COD_ONE_PR) else CAST(t.COD_ONE_PR as varchar) end,t.Provincia) as Provincia,
    
    CONCAT_WS(' ',CONCAT(case when len(t.COD_ONE_PR)=1 then CONCAT('0',t.COD_ONE_PR) else CAST(t.COD_ONE_PR as varchar) end,COD_ONE_MU),t.Municipio) as Municipio, Institucio as Institucion
from Usuarios U
    left JOIN Usuarios_centros A
    on 
u.uname=a.uname
    left JOIN tbcentros  t
    on 
t.Id=a.Centro";
            //  var customers=""'
     
     
            using (IDbConnection connection = new SqlConnection(iconfiguration.GetConnectionString("DataSof")))
            {
                
                    var customers = connection.Query(sql);

                    return Ok(customers);             
            };

            var tab = "hello";
            return Ok(tab);
        }
    }
}