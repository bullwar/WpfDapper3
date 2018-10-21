using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfAppDapper3
{
    public class People
    {
        public int id { get; set; }
        public string FIO { get; set; }

 
        public void info()
        {
            Console.WriteLine(id + " " + FIO);
        }
    }
}
