using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CorporateArena.Domain
{
    public class BrainTeaserService : IBrainTeaserService
    {
        private readonly IRepo<BrainTeaser> _repo;
        private readonly IUserService _uService;
        private readonly IRepo<BrainTeaserAnswer> _bRepo;

        public BrainTeaserService(IRepo<BrainTeaser> repo, IUserService uService, IRepo<BrainTeaserAnswer> bRepo)
        {
            _repo = repo;
            _uService = uService;
            _bRepo = bRepo;
            
        }

        public async Task<SaveResponse> SaveBrainTeaserAsync(BrainTeaser data)
        {
            

            int BRID = await _repo.insertAsync(data);
            return new SaveResponse { ID = BRID, status = true, Result = "Brain Teaser successfully created" };


        }

        public async Task<SaveResponse> SubmitAnswerAsync(BrainTeaserAnswer data)
        {
            

            int AID = await _bRepo.insertAsync(data);
            return new SaveResponse { ID = AID, status = true, Result = "Answer successfully submitted" };


        }
        public async Task<BrainTeaser> GetBrainTeaserandAnswerAsync(int ID)
        {
            var bt = await _repo.getAsync(ID);

            var answers = await _bRepo.getAllByIDAsync(ID);
            bt.BrainTeaserAnswers = answers;

            return bt;
        }
        public async Task<SaveResponse> UpdateBrainTeaserAsync(BrainTeaser data)
        {
            
            await _repo.updateAsync(data);
            return new SaveResponse {  status = true, Result = "Brain Teaser successfully updated" };

        }

        public async Task<SaveResponse> DeleteBrainTeaser(int ID,int userID)
        {

           

            var answers = await _bRepo.getAllByIDAsync(ID);
            if(answers!=null)
                await _bRepo.deleteAllByIDAsync(ID);

            await _repo.deleteAsync(ID);

            
            return new SaveResponse { status = true, Result = "Brain Teaser successfully deleted" };

        }
    }
}
