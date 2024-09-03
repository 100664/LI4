using Microsoft.AspNetCore.Mvc;
using PitStopAuctions.Shared;
using static System.Net.WebRequestMethods;

namespace PitStopAuctions.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutoController : ControllerBase
    {
        private readonly DataContext _dataContext;
        public ProdutoController(DataContext context)
        {
            _dataContext = context;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Produto>> GetProduto(int id)
        {
            var prod = await _dataContext.Produtos.FirstOrDefaultAsync(x => x.Id == id);
            if (prod == null)
            {
                return NotFound("Este produto não existe.");
            }
            return Ok(prod);
        }


        [HttpPost]
        public async Task<ActionResult<List<Produto>>> CriarProduto(Produto prod)
        {
            _dataContext.Produtos.Add(prod);
            await _dataContext.SaveChangesAsync();
            return Ok(GetDBProdutos());
        }

        private async Task<List<Produto>> GetDBProdutos()
        {
            return await _dataContext.Produtos.ToListAsync();
        }


        [HttpGet]
        public async Task<ActionResult<List<Produto>>> GetAllProdutos()
        {
            var allProdutos = await _dataContext.Produtos.ToListAsync();
            return Ok(allProdutos);
        }

    }
}
