using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProvaFinale6Library
{
    public class Spesa
    {
        public int IDspesa { get; set; } 
        public string Descrizione { get; set; }
        public DateTime DataSpesa { get; set; }
        public string Utente { get; set; }
        public bool Approvata { get; set; }
        public decimal Importo { get; set; }
        public int IDcat { get; set; }
    }
}
