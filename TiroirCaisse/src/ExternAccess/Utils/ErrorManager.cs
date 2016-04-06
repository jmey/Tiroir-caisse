using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TiroirCaisse.src.Utils
{
    public static class ErrorManager
    {
        private  static List<Error> errorList { get; set; }

        public static void addError(string message, ErrorLevel level)
        {
            errorList.Add(new Error(message, level));
        }

        public static string checkError()
        {
            string res = null;
            if(errorList.Count != 0)
            {
                foreach (Error e in errorList)
                {
                    if (e.level != ErrorLevel.utilisateur)
                    {
                        if (!Properties.Settings.Default.TestMode)
                        {
                            res += e.message + '\n';
                        }
                    }
                    else
                    {
                        res += e.message + '\n';
                    }
                }
                   
            }
            return res;
        }
    }

}
