using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace finaltry.Classes
{
    public class Parent
    {

        public string name { get; set; }
        public string email { get; set; }
        public int phone { get; set; }



        public Parent(string na, string em, int ph)
        {
            name = na;
            email = em;
            phone = ph;
        }
    }
}
