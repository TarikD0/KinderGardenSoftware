using System.Data.SqlTypes;

namespace finaltry
{
    public class Activity
    {
       
        public Activity(string ActivityName, int money1)
        {
            getActivity = ActivityName;
            money = money1; 
        }
        public string getActivity { get; set; }
        public int money { get; set; }
    }
}