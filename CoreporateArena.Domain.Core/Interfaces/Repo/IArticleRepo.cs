﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CorporateArena.Domain
{
    public interface IArticleRepo
    {
        

        Task  deleteAllByIDAsync(int ID);
        
        Task deleteAsync(int ID);
        
        Task<List<Article>> getAllAsync();

        Task<ArticleComment> getSingleCommentAsync(int userID, int articleID, int commentID);

        Task<Article> getAsync(int ID);

        Task<int> insertAsync(Article data);
        
        Task<bool> insertListAsync(List<Article> data);

        Task updateAsync(Article data);
    }
}
