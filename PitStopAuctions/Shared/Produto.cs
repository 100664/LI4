using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PitStopAuctions.Shared
{
    public class Produto
    {
        public string Modelo { get; set; }
        public string Versao { get; set; }
        public string Combustivel { get; set; }
        public int Ano { get; set; }
        public decimal Cilindrada { get; set; }
        public decimal Potencia { get; set; }
        public string Cor { get; set; }
        public string TipoCaixa { get; set; }
        public int NumeroMudancas { get; set; }
        public int NumeroPortas { get; set; }
        public int Lotacao { get; set; }
        public string Classe { get; set; }
        public string Tracao { get; set; }
        public int EmissaoCO2 { get; set; }
        public string GarantiaStand { get; set; }
        public string Registo { get; set; }
        public string Origem { get; set; }
        public int Id { get; set; }
    }

}
