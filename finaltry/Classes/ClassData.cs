using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace finaltry.Classes
{
    public class ClassData
    {
        public string classname { get; set; }
        public int classprice { get; set; }


        ClassData(string classnam, int classpric)
        {
            classname = classnam;
            classprice = classpric;
        }
    }
}
