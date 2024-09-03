using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PitStopAuctions.Shared
{
    public class Leilao
    {
        public int Id { get; set; }
        public string Nome { get; set; } = string.Empty;
        public string Descricao { get; set; } = string.Empty;
        public DateTime Data_inicio { get; set; }
        public DateTime Data_fim { get; set; }
        public float PrecoInicial { get; set; }
        public string Imagem { get; set; } = string.Empty;
        public List<Lance>? Lances { get; set; } = new List<Lance> { };
        public Lance? LanceAtual { get; set; }
        public int? LanceAtualId { get; set; }
        public Marca? Marca {  get; set; }
        public int MarcaId { get; set; }
        public Produto? Produto {  get; set; }
        public int ProdutoId { get; set; }

        public Lance GetLanceAtual()
        {
            return this.LanceAtual;
        }

        public void AtualizarLance(Lance newBid)
        {
            this.LanceAtual = newBid;
            this.LanceAtualId = newBid.Id;
        }
    }
}
