using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CorporateArena.Domain
{
    public class Article
    {
        [Key]
        public int ID { get; set; }
        [StringLength(150, MinimumLength = 5)]
        public string Title { get; set; }

        public int AuthorID { get; set; }

        public string Content { get; set; }
        public string ImageUrl { get; set; }

        public int TotalViews { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateModified { get; set; }

        
    }
}
