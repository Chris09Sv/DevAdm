
using DevControl.Data;
using DevControl.Services;
using Microsoft.AspNetCore.Mvc;

namespace DevControl.Apis
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class MunicipiosController : ControllerBase
    {

        private readonly DevContext _context;
        private readonly IData _data;

        public MunicipiosController(DevContext context, IData data)
        {
            _data = data;
            _context = context;
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

        [HttpGet]

        public ActionResult GetCentros()
        {



            return Ok(_data.GetVmEstablecimientos());
        }

    }

}