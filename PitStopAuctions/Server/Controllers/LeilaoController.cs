using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PitStopAuctions.Shared;
using static System.Net.WebRequestMethods;

namespace PitStopAuctions.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LeilaoController : ControllerBase
    {
        private readonly DataContext _dataContext;
        public LeilaoController(DataContext context) 
        {
            _dataContext = context;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Leilao>> GetLeilao(int id)
        {
            var leilao = await _dataContext.Leiloes
                .Include(l => l.Marca)
                .Include(l => l.Lances)
                .Include(l => l.Produto)
                .Include(l => l.LanceAtual)
                .FirstOrDefaultAsync(x => x.Id == id);
            if (leilao == null)
            {
                return NotFound("Este leilão não existe.");
            }
            leilao.LanceAtual = leilao.Lances?.FirstOrDefault(l => l.Id == leilao.LanceAtualId);

            return Ok(leilao);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<List<Leilao>>> UpdateLeilao(Leilao le, int id)
        {
            var dbLeilao = await _dataContext.Leiloes
                .Include(l => l.Marca)
                .Include(l => l.Lances)
                .Include(l => l.Produto)
                .Include(l => l.LanceAtual)
                .FirstOrDefaultAsync(x => x.Id == id);

            if (dbLeilao == null)
                return NotFound("Sorry, but no leilao for you. :/");

            dbLeilao.Nome = le.Nome;
            dbLeilao.Descricao = le.Descricao;
            dbLeilao.Data_inicio = le.Data_inicio;
            dbLeilao.Data_fim = le.Data_fim;
            dbLeilao.PrecoInicial = le.PrecoInicial;
            dbLeilao.Imagem = le.Imagem;
            dbLeilao.LanceAtualId = le.LanceAtualId;
            dbLeilao.MarcaId = le.MarcaId;
            dbLeilao.ProdutoId = le.ProdutoId;
            dbLeilao.LanceAtual = dbLeilao.Lances?.FirstOrDefault(l => l.Id == dbLeilao.LanceAtualId);
            dbLeilao.Lances.Add(dbLeilao.LanceAtual);

            await _dataContext.SaveChangesAsync();

            return Ok(await GetDBLeiloes());
        }

        [HttpPost]
        public async Task<ActionResult<List<Leilao>>> CriarLeilao(Leilao le)
        {
            le.Marca = null;
            _dataContext.Leiloes.Add(le);
            await _dataContext.SaveChangesAsync();
            return Ok(await GetDBLeiloes());
        }

        private async Task<List<Leilao>> GetDBLeiloes()
        {
            return await _dataContext.Leiloes   
                .Include(l => l.Marca)
                .Include(l => l.Lances)
                .Include(l => l.Produto)
                .Include(l => l.LanceAtual)
                .ToListAsync();
        }


        [HttpGet]
        public async Task<ActionResult<List<Leilao>>> GetAllLeiloes()
        {
            var allLeiloes = await _dataContext.Leiloes   
                .Include(l => l.Marca)
                .Include(l => l.Lances)
                .Include(l => l.Produto)
                .Include(l => l.LanceAtual)
                .ToListAsync();
            return Ok(allLeiloes);
        }

    }
}
