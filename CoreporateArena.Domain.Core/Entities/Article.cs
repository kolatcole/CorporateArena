using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
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
        public bool isApproved { get; set; }
        public string Content { get; set; }
        public string ImageUrl { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateModified { get; set; }

        
    }

    public class ArticleComment
    {
        [Key]
        public int ID { get; set; }
        [StringLength(150, MinimumLength = 5)]
        public string Title { get; set; }
        public string Content { get; set; }
        public int ArticleID { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateModified { get; set; }
        public int UserCreated { get; set; }
        public int CommentLikes { get; set; }

        [NotMapped]
        public List<int> UsersLiked { get; set; }



    }
}
