using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC_MODEL__APP.Models
{
    class Note
    {
        public int codeEtudiant { get; set; }
        public int codeModule { get; set; }
        public float note { get; set; }
        public Note() { }
        public Note(int CE,int CM,float Note) {
            codeEtudiant = CE;
            codeModule = CM;
            note = Note;
        }
    }
}
