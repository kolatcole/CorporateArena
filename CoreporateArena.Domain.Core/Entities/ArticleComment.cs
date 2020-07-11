using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CorporateArena.Domain
{
    public class ArticleComment
    {
        [Key]
        public int ID { get; set; }
        [StringLength(150, MinimumLength = 5)]
        public string Title { get; set; }
        [StringLength(150, MinimumLength = 5)]
        public string Author { get; set; }
        public string Content { get; set; }
        public int ArticleID { get; set; }
        public Article Article { get; set; }
        public DateTime? DateCreated { get; set; }
        public DateTime? DateModified { get; set; }
        public int UserCreated { get; set; }
        public int CommentLikes { get; set; }


        
    }
}
