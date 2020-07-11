using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CorporateArena.Domain
{
    public class Privilege:BaseEntity
    {
        public string Name { get; set; }
        public string DisplayName { get; set; }
        public string Action { get; set; }
        public string Entity { get; set; }


        public static string TrafficUpdates => "Traffic Updates";
        public static string User => "User";
        public static string BrainTeaser => "Brain Teaser";
        public enum MyEnum
        {
            Create,Read,Update,Delete
        }
    }
    
}
