using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC_MODEL__APP.Models
{
    class Professeur
    {
        public int codeP { get; set; }
        public string nom { get; set; }
        public string prenom { get; set; }
        public string diplome { get; set; }
        public string contact { get; set; }
        public Professeur() { }
        public Professeur(int Code, string Nom, string Prenom, string Diplome, string Contact)
        {
            codeP = Code;
            nom = Nom;
            prenom = Prenom;
            diplome = Diplome;
            contact = Contact;
        }
    }
}
