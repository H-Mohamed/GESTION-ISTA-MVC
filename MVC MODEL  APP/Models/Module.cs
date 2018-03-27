using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC_MODEL__APP.Models
{
    class Module
    {
        public int codeM { get; set; }
        public string nomM { get; set; }
        public int codeP { get; set; }
        public DateTime dateP { get; set; }
        public DateTime DateR { get; set; }
        public Module() { }
        public Module(int CM,string NM,int CP,DateTime DP,DateTime DR)
        {
            codeM = CM;
            codeP = CP;
            nomM = NM;
            dateP = DP;
            DateR = DR;
        }
    }
}
