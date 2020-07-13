using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace CorporateArena.Domain
{
    public class Privilege : BaseEntity
    {
        public string Name { get; set; }
        public string DisplayName { get; set; }

        public string Action {

            get;
            set;

        }
        public string Entity { get; set; }
    }


    

    public class Models
    {
        
        Dictionary<int, string> Aq = new Dictionary<int, string>();

        public IEnumerable<KeyValuePair<int,string>> GetActions()
        {
            Aq.Add(1, "Create");
            Aq.Add(2, "Read");
            Aq.Add(3, "Update");
            Aq.Add(4, "Delete");

            var fiat = Aq.ToList();
            return fiat;
        }

        //public MyEnum GetActionss()
        //{
        //    MyEnum en = new MyEnum();
        //    return en;
        //}

        public MyEnum GetActionss()
        {
            MyEnum en = new MyEnum();
            return en;
        }




        public static List<KeyValuePair<string, string>> Mod = new List<KeyValuePair<string, string>>()
        {
            new KeyValuePair<string, string>("Traffic Updates","TrafficUpdates"),
            new KeyValuePair<string, string>("User","User"),
            new KeyValuePair<string, string>("Brain Teaser","BrainTeaser")


        };
        public enum MyEnum
        {
            Create, Read, Update, Delete
        }

        
    }
    
}
