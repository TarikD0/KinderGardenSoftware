using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace finaltry.Classes
{
    public class Student
    {
        int id { get; set; }
        string name { get; set; }
        Parent parent { get; set; }
        string Class { get; set; }
        bool takeslunch { get; set; }
        bool usesbus { get; set; }

        List<Activity> activities { get; set; }
        string address { get; set; }
        int price { get; set; }


        public int getPrice()
        {
            int total = 0;
            if(takeslunch)
            {
                total = total + 30;
            }
            if (usesbus)
            {
                total = total + 50;
            }
           // total = total + Class.price;
            foreach(var activity in activities)
            {
                total = total + activity.money;
            }

            return total;
        }
        public Student(int i, string na, Parent pa, string cl, bool tl, bool ub, List<Activity> ac)
        {
            id = i;
            name = na;
            parent = pa;
            Class = cl;
            takeslunch = tl;
            usesbus = ub;
            activities = ac;
        }
        public Student(int i, string na, Parent pa, string cl, bool tl, bool ub, List<Activity> ac, string ad)
        {
            id = i;
            name = na;
            parent = pa;
            Class = cl;
            takeslunch = tl;
            usesbus = ub;
            activities = ac;
            address = ad;
        }
    }
}
