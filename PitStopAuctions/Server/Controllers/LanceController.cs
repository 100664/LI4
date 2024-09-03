using Microsoft.AspNetCore.Mvc;
using PitStopAuctions.Shared;
using static System.Net.WebRequestMethods;

namespace PitStopAuctions.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LanceController : ControllerBase
    {
        private readonly DataContext _dataContext;
        public LanceController(DataContext context)
        {
            _dataContext = context;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Lance>> GetProduto(int id)
        {
            var prod = await _dataContext.Lances.FirstOrDefaultAsync(x => x.Id == id);
            if (prod == null)
            {
                return NotFound("Este lance não existe.");
            }
            return Ok(prod);
        }


        [HttpPost]
        public async Task<ActionResult<List<Lance>>> CriarLance(Lance lanc)
        {
            _dataContext.Lances.Add(lanc);
            await _dataContext.SaveChangesAsync();
            return Ok(await GetDBLances());
        }

        private async Task<List<Lance>> GetDBLances()
        {
            return await _dataContext.Lances.ToListAsync();
        }


        [HttpGet]
        public async Task<ActionResult<List<Lance>>> GetAllLances()
        {
            var allLances = await _dataContext.Lances.ToListAsync();
            return Ok(allLances);
        }

    }
}
