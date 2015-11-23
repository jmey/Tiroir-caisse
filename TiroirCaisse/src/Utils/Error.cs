using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TiroirCaisse.src.Utils
{
    public class Error
    {
        public string message { get; set; }
        public ErrorLevel level { get; set; }

        public Error(string msg, ErrorLevel lvl)
        {
            message = msg;
            level = lvl;
        }
    }
    public enum ErrorLevel
    {
        utilisateur,
        administrateur
        
    }


}
