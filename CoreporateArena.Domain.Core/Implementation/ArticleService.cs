using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CorporateArena.Domain
{
    public class ArticleService : IArticleService
    {

        private readonly IUserService _uService;
        private readonly IRepo<Article> _repo;
        private readonly IRepo<ArticleComment> _cRepo;
        private readonly IArticleLikeRepo _alRepo;
       // private readonly ICommentLikeRepo _clRepo;

        public ArticleService(IUserService uService, IRepo<Article> repo, IRepo<ArticleComment> cRepo, IArticleLikeRepo alRepo/*IRepo<CommentLike> clRepo*/)
        {
            _uService = uService;
            _repo = repo;
            _cRepo = cRepo;
            _alRepo = alRepo;
       //     _clRepo = clRepo;
        }


        public async Task<SaveResponse> SaveArticleAsync(Article data)
        {
            var userExist = await _uService.CheckIfUserExist(data.AuthorID);
            if (!userExist)
                return new SaveResponse { status = false, Result = "User Not Found" };

            string name = "CreateArticle";
            var permission = await _uService.CheckforPermission(data.AuthorID, name);

            if (!permission)
                return new SaveResponse { Result = "User does not have permission to perform this action" };

            int AID = await _repo.insertAsync(data);
            return new SaveResponse { ID = AID, status = true, Result = "Article successfully created" };
        }


        public async Task<SaveResponse> SubmitCommentAsync(ArticleComment data)
        {
            var userExist = await _uService.CheckIfUserExist(data.UserCreated);
            if (!userExist)
                return new SaveResponse { status = false, Result = "User Not Found" };

            int CID = await _cRepo.insertAsync(data);
            return new SaveResponse { ID = CID, status = true, Result = "Comment successfully submitted" };


        }
        public async Task<Article> GetArticleWithCommentsAsync(int ID)
        {
            var article = await _repo.getAsync(ID);

            var comments = await _cRepo.getAllByIDAsync(ID);
            if(comments!=null)
                article.Comments = comments;

            return article;
        }
        public async Task<SaveResponse> UpdateArticleAsync(Article data)
        {
            var userExist = await _uService.CheckIfUserExist(data.AuthorID);
            if (!userExist)
                return new SaveResponse { status = false, Result = "User Not Found" };

            string name = "UpdateArticle";
            var permission = await _uService.CheckforPermission(data.AuthorID, name);

            if (!permission)
                return new SaveResponse { Result = "User does not have permission to perform this action" };

            await _repo.updateAsync(data);
            return new SaveResponse { status = true, Result = "Article successfully updated" };

        }

        public async Task<SaveResponse> DeleteArticleAsync(int ID, int userID)
        {

            var userExist = await _uService.CheckIfUserExist(userID);
            if (!userExist)
                return new SaveResponse { status = false, Result = "User Not Found" };

            string name = "DeleteArticle";
            var permission = await _uService.CheckforPermission(userID, name);

            if (!permission)
                return new SaveResponse { Result = "User does not have permission to perform this action" };

            var comments = await _cRepo.getAllByIDAsync(ID);
            if (comments != null)
                await _cRepo.deleteAllByIDAsync(ID);

            await _repo.deleteAsync(ID);


            return new SaveResponse { status = true, Result = "Article successfully deleted" };

        }

        public async Task<SaveResponse> LikeArticleAsync(int userID, int articleID)
        {
            var userExist = await _uService.CheckIfUserExist(userID);
            if (!userExist)
                return new SaveResponse { status = false, Result = "User Not Found" };

            var article = await _repo.getAsync(articleID);

            // check if the userid and articleid exist in articleLike

            var like = await _alRepo.getAsync(userID, articleID);

            // Increase articlelikeCount and save articleLike, if it hasn't been liked before
            if (like == null)
            {


                var newLike = new ArticleLike
                {
                    ArticleID = articleID,
                    UserCreated = userID
                };
                await _alRepo.insertAsync(newLike);
                article.ArticleLikesCount += 1;
                await _repo.updateAsync(article);
                return new SaveResponse { status = true, Result = "Article was liked" };
            }

            else
            {
                await _alRepo.deleteAsync(userID, articleID);
                article.ArticleLikesCount -= 1;
                await _repo.updateAsync(article);
                return new SaveResponse { status = true, Result = "Article was unliked" };
            }


        }
    }
}
