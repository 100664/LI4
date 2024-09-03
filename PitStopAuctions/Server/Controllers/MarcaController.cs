using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace PitStopAuctions.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MarcaController : ControllerBase
    {
        private readonly DataContext _dataContext;
        public MarcaController(DataContext context)
        {
            _dataContext = context;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Marca>> GetMarca(int id)
        {
            var marca = await _dataContext.Marcas.FirstOrDefaultAsync(x => x.Id == id);
            if (marca == null)
            {
                return NotFound("Esta marca não existe.");
            }
            return Ok(marca);
        }

        [HttpGet("by-username/{username}")]
        public async Task<ActionResult<Marca>> GetMarcarByUsername(string username)
        {
            var marca = await _dataContext.Marcas.FirstOrDefaultAsync(x => x.Username.Equals(username));
            if (marca == null)
            {
                return NotFound("Este Marca não existe.");
            }
            return Ok(marca);
        }

        [HttpPost]
        public async Task<ActionResult<List<Marca>>> CriarMarca(Marca le)
        {
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
            _dataContext.Marcas.Add(le);
            await _dataContext.SaveChangesAsync();

            return Ok(await GetDBMarcas());
        }

        private async Task<List<Marca>> GetDBMarcas()
        {
            return await _dataContext.Marcas.ToListAsync();
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<List<Marca>>> UpdateMarca(Marca marca, int id)
        {
            var dbmarca = await _dataContext.Marcas
                .FirstOrDefaultAsync(sh => sh.Id == id);
            if (dbmarca == null)
                return NotFound("Sorry, but no Marca for you. :/");

            dbmarca.Nome = marca.Nome;
            dbmarca.Morada = marca.Morada;
            dbmarca.Cidade = marca.Cidade;
            dbmarca.CodPostal = marca.CodPostal;
            dbmarca.Image = marca.Image;
            dbmarca.Password = marca.Password;
            dbmarca.Approved = marca.Approved;


            await _dataContext.SaveChangesAsync();

            return Ok(await GetDBMarcas());
        }

        [HttpGet]
        public async Task<ActionResult<List<Marca>>> GetAllMarcas()
        {
            var allMarcas = await _dataContext.Marcas.ToListAsync();
            return Ok(allMarcas);
        }

    }
}
