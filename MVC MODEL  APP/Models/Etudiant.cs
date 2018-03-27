using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC_MODEL__APP.Models
{
    class Etudiant
    {
        public int codeE { get; set; }
        public string nom { get; set; }
        public string prenom { get; set; }
        public DateTime daten { get; set; }
        public string email { get; set; }
        public Etudiant() { }
        public Etudiant(int CE,string N,string P,DateTime DN,string EM)
        {
            codeE = CE;
            nom = N;
            prenom = P;
            daten = DN;
            email = EM;
        }
    }
}
