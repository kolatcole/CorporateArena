using CorporateArena.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CorporateArena.Infrastructure
{
    public class CommentLikeRepo : IRepo<CommentLike>
    {

        private readonly TContext _context;
        public CommentLikeRepo(TContext context)
        {
            _context = context;
        }

        public async Task deleteAllByIDAsync(int ID)
        {
            try
            {
                var like = await _context.CommentLikes.FindAsync(ID);
                _context.CommentLikes.Remove(like);
                await _context.SaveChangesAsync();


            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Task deleteAsync(int ID)
        {
            throw new NotImplementedException();
        }

        public Task<List<CommentLike>> getAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<List<CommentLike>> getAllByIDAsync(int ID)
        {
            throw new NotImplementedException();
        }

        public Task<CommentLike> getAsync(int ID)
        {
            throw new NotImplementedException();
        }

        public async Task<int> insertAsync(CommentLike data)
        {
            try
            {
                var like = new CommentLike
                {
                    CommentID = data.CommentID,
                    UserCreated = data.UserCreated
                };

                await _context.CommentLikes.AddAsync(like);
                await _context.SaveChangesAsync();
                return like.ID;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public Task<bool> insertListAsync(List<CommentLike> data)
        {
            throw new NotImplementedException();
        }

        public Task updateAsync(CommentLike data)
        {
            throw new NotImplementedException();
        }
    }
}
