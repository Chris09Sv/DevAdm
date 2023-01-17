using DevControl.Models;
using DevControl.Models.VieModel;
using DevControl.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DevControl.Apis
{
    [Route("api/[controller]")]
    [ApiController]
    public class WorkerController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly IData data;
        public WorkerController(IData data, IConfiguration configuration)
        {
            this.data = data;
            _configuration = configuration;
        }
        [HttpGet]

        public IActionResult Index()
        {
            var query = "select * from establecimientos";

            var user = data.LoadDataVp<EstablecimientosVp, dynamic>(query, new { }, _configuration.GetConnectionString("DataViepi"));

            return Ok(user);
        }
    }
}
