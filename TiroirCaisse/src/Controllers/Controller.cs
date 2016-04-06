using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using TiroirCaisse.Entities;

namespace TiroirCaisse.src.Controllers
{
    public class Controller
    {

        //TODO: à améliorer
        public string listToCSV(List<Object> list, Type type)
        {
            string res = "";
            //En têtes
            string line = "";
            foreach (PropertyInfo propertyInfo in type.GetProperties())
            {
                line += ';' + propertyInfo.Name;
            }
            line = line.Substring(1);
            res += line + "\r\n";
            foreach (object o in list)
            {
                line = "";
                foreach (PropertyInfo propertyInfo in type.GetProperties())
                {
                    Object value = propertyInfo.GetValue(o);
                    if (value.GetType().IsGenericType)
                    {
                        if (value.GetType() == typeof(List<Prestation>))
                        {
                                foreach (object o1 in value as List<Prestation>)
                                {
                                    line += ',' + o1.ToString();
                                }
                        }
                        else if (value.GetType() == typeof(List<Produit>))
                        {
                            foreach (object o1 in value as List<Produit>)
                            {
                                line += ',' + o1.ToString();
                            }
                        }
                    }
                    else
                    {
                        line += ';' + propertyInfo.GetValue(o).ToString();
                    }
                }
                line = line.Substring(1);
                res += line + "\r\n";
            }           
            return res;
        }
        public int saveCSVFile(string filepath, string csv)
        {
            File.WriteAllText(filepath, csv);
            return 0;
        }
    }
}
