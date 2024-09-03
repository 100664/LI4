using Microsoft.AspNetCore.Mvc;

namespace PitStopAuctions.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UtilizadorController : ControllerBase
    {
        private readonly DataContext _dataContext;
        public UtilizadorController(DataContext context)
        {
            _dataContext = context;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Utilizador>> GetUtilizador(int id)
        {
            var user = await _dataContext.Utilizadores.FirstOrDefaultAsync(x => x.Id == id);
            if (user == null)
            {
                return NotFound("Este user não existe.");
            }
            return Ok(user);
        }

        [HttpGet("by-username/{username}")]
        public async Task<ActionResult<Utilizador>> GetUtilizadorByUsername(string username)
        {
            var user = await _dataContext.Utilizadores.FirstOrDefaultAsync(x => x.Username.Equals(username));
            if (user == null)
            {
                return NotFound("Este user não existe.");
            }
            return Ok(user);
        }

        [HttpPost]
        public async Task<ActionResult<List<Utilizador>>> CriarUtilizador(Utilizador le)
        {
            // Check if CC is unique
            if (_dataContext.Utilizadores.Any(u => u.CC == le.CC))
            {
                return BadRequest("CC must be unique. Another user with the same CC already exists.");
            }

            // Check if NIF is unique
            if (_dataContext.Utilizadores.Any(u => u.Nif == le.Nif))
            {
                return BadRequest("NIF must be unique. Another user with the same NIF already exists.");
            }

            // Check if Username is unique
            if (_dataContext.Utilizadores.Any(u => u.Username == le.Username))
            {
                return BadRequest("Username must be unique. Another user with the same Username already exists.");
            }

            if (_dataContext.Utilizadores.Any(u => u.Email == le.Email))
            {
                return BadRequest("Username must be unique. Another user with the same Username already exists.");
            }


            // Check if NIF is unique
            if (_dataContext.Marcas.Any(u => u.Nif == le.Nif))
            {
                return BadRequest("NIF must be unique. Another user with the same NIF already exists.");
            }

            // Check if Username is unique
            if (_dataContext.Marcas.Any(u => u.Username == le.Username))
            {
                return BadRequest("Username must be unique. Another user with the same Username already exists.");
            }

            if (_dataContext.Marcas.Any(u => u.Email == le.Email))
            {
                return BadRequest("Username must be unique. Another user with the same Username already exists.");
            }

            // All uniqueness checks passed, proceed to add the user
            _dataContext.Utilizadores.Add(le);
            await _dataContext.SaveChangesAsync();

            return Ok(await GetDBUtilizadores());
        }
        private async Task<List<Utilizador>> GetDBUtilizadores()
        {
            return await _dataContext.Utilizadores.ToListAsync();
        }


        [HttpGet]
        public async Task<ActionResult<List<Utilizador>>> GetAllUtilizadores()
        {
            var allUsers = await _dataContext.Utilizadores.ToListAsync();
            return Ok(allUsers);
        }

    }
}
