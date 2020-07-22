using CorporateArena.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorporateArena.Infrastructure
{
    public class BrainTeaserAnswerRepo : IRepo<BrainTeaserAnswer>
    {

        private readonly TContext _context;

        public BrainTeaserAnswerRepo(TContext context)
        {
            _context = context;
        }

        public async Task deleteAllByIDAsync(int BTID)
        {
            try
            {
                var answers = await _context.BrainTeaserAnswers.Where(x => x.BrainTeaserID == BTID).ToListAsync();
                _context.BrainTeaserAnswers.RemoveRange(answers);
                await _context.SaveChangesAsync();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task deleteAsync(int ID)
        {
            try
            {
                var bt = await _context.BrainTeaserAnswers.FindAsync(ID);
                _context.BrainTeaserAnswers.Remove(bt);
                await _context.SaveChangesAsync();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<BrainTeaserAnswer>> getAllAsync()
        {
            try
            {
                var bts = await _context.BrainTeaserAnswers.ToListAsync();
                return bts;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<BrainTeaserAnswer>> getAllByIDAsync(int BrainTeaserID)
        {
            try
            {
                var bta = await _context.BrainTeaserAnswers.Where(x => x.BrainTeaserID == BrainTeaserID).ToListAsync();
                return bta;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<BrainTeaserAnswer> getAsync(int ID)
        {
            try
            {
                var bt = await _context.BrainTeaserAnswers.FindAsync(ID);
                return bt;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<int> insertAsync(BrainTeaserAnswer data)
        {

            try
            {
                BrainTeaserAnswer bt = new BrainTeaserAnswer
                {
                    DateCreated = DateTime.Now,
                    Answer=data.Answer,
                    BrainTeaserID=data.BrainTeaserID,
                    UserCreated = data.UserCreated
                };

                await _context.BrainTeaserAnswers.AddAsync(bt);
                await _context.SaveChangesAsync();
                return bt.ID;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public Task<bool> insertListAsync(List<BrainTeaserAnswer> data)
        {
            throw new NotImplementedException();
        }

       public Task updateAsync(BrainTeaserAnswer data)
        {
            throw new NotImplementedException();
        }
    }
}
