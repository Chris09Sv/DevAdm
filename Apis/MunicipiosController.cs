using Dapper;
using DevControl.Data;
using DevControl.Models;
using DevControl.Models.Establecimientos;
using DevControl.Models.Viepi;
using DevControl.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Collections.Immutable;
using System.Configuration;
using System.Data;

namespace DevControl.Apis
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class MunicipiosController : ControllerBase
    {

        private readonly DevContext _context;
        private readonly IData _data;
        private readonly IConfiguration iconfiguration;

        public MunicipiosController(DevContext context, IData data,IConfiguration iconfiguration)
        {
            _data = data;
            this.iconfiguration = iconfiguration;
            _context = context;
        }

        [HttpGet]
        public ActionResult GetProv()
        {
            //var municipio = _context.tbProvincias.ToList();
            var query = "select id,codigo,concat_ws(' ',codigo,Provincia) as Provincia from tbprovincias  union select '','',''";

            using (IDbConnection connection = new SqlConnection(iconfiguration.GetConnectionString("DevControlContext")))
            {

                var customers = connection.Query<TbProvincias>(query);

                return Ok(customers);
            };


            //return Ok(municipio);
        }
        [HttpGet("{id}")]
        public ActionResult GetMunicipios(int id)
        {
            var municipio = _context.tbMunicipios.Where(x => Convert.ToInt32(x.provincia) == id).ToList();
            if (municipio == null)
            {
                return NotFound();
            }



            return Ok(municipio);
        }
        [HttpGet("{id}")]

        public ActionResult GetDistritos(int id)
        {
            var mun = _context.tbMunicipios.Where(x => x.Id == id).ToList().SingleOrDefault();

            if (mun == null)
            {
                return NotFound();
            }


            var municipio = _context.tbDistritos.Where(x => x.provincia + x.municipio == mun.codigo).ToList();
            if (municipio == null)
            {
                return NotFound();
            }



            return Ok(municipio);
        }

        [HttpGet("{id}")]

        public ActionResult GetBarrio(int id)
        {

            var mun = _context.tbDistritos.Where(x => x.Id == id).ToList().SingleOrDefault();
            if (mun == null)
            {
                return NotFound();
            }

            var pa = mun.provincia + mun.municipio + mun.codigo;
            var municipio = _context.tbSectores.Where(x => x.provincia + x.municipio + x.distrito == pa).ToList();
            if (municipio == null)
            {
                return NotFound();
            }



            return Ok(municipio);
        }

        [HttpGet("{id}")]
        public ActionResult GetArea(int id)
        {
            var prov = _context.tbProvincias.Where(x => x.id == id).SingleOrDefault();
            var Area = _context.tbArea.Where(x => x.Provincia == prov.codigo).ToList();

            if (Area == null)
            {
                return NotFound();
            }



            return Ok(Area);
        }

        [HttpGet("{id}")]

        public ActionResult GetSeccion(int id)
        {

            var mun = _context.tbDistritos.Where(x => x.Id == id).ToList().SingleOrDefault();
            if (mun == null)
            {
                return NotFound();
            }

            var pa = mun.provincia + mun.municipio + mun.codigo;
            var municipio = _context.tbSecciones.Where(x => x.cod_one_pr + x.cod_one_mu + x.cod_one_dm == pa).ToList();
            if (municipio == null)
            {
                return NotFound();
            }



            return Ok(municipio);
        }

        [HttpGet]

        public ActionResult GetCentros()
        {
            return Ok(_data.GetVmEstablecimientos());
        }
        [HttpGet]

        public ActionResult GetInstituciones()
        {
            var Institucion = _context.tbInstitucion.ToList();

            Institucion.Insert(1,  new TbInstitucion { Institucion = ""});
            return Ok(Institucion.OrderBy(x=>x.Institucion));
        }
       

    }

}