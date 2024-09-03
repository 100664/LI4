using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PitStopAuctions.Shared
{
    public class Marca
    {
        public Boolean Approved { get; set; } = false;
        public int Id { get; set; }
        public string Nome { get; set; } = string.Empty;
        public string Nif { get; set; } = string.Empty;
        public string Morada { get; set; } = string.Empty;
        public string Cidade { get; set; } = string.Empty;
        public string CodPostal { get; set; } = string.Empty;
        public string Username { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string Image { get; set; } = string.Empty;

        public Boolean CheckPassword(string password)
        {
            return password.Equals(Password);
        }
    }
}
