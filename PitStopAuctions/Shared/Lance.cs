using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PitStopAuctions.Shared
{
    public class Lance
    {
        public int Id {  get; set; }
        public DateTime Hora {  get; set; }
        public int Montante { get; set; }
        public int UtilizadorID { get; set; }

        public int LeilaoId { get; set; }
        
    }
}
