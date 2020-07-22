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
            var userExist = await _uService.CheckIfUserExist(data.UserCreated);
            if (!userExist)
                return new SaveResponse { status = false, Result = "User Not Found" };

            string name = "CreateBrainTeaser";
            var permission = await _uService.CheckforPermission(data.UserCreated, name);

            if(!permission)
                return new SaveResponse { Result = "User does not have permission to perform this action" };

            int BRID = await _repo.insertAsync(data);
            return new SaveResponse { ID = BRID, status = true, Result = "Brain Teaser successfully created" };


        }

        public async Task<SaveResponse> SubmitAnswerAsync(BrainTeaserAnswer data)
        {
            var userExist = await _uService.CheckIfUserExist(data.UserCreated);
            if (!userExist)
                return new SaveResponse { status = false, Result = "User Not Found" };

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
            var userExist = await _uService.CheckIfUserExist(data.UserCreated);
            if (!userExist)
                return new SaveResponse { status = false, Result = "User Not Found" };

            string name = "UpdateBrainTeaser";
            var permission = await _uService.CheckforPermission(data.UserCreated, name);

            if (!permission)
                return new SaveResponse { Result = "User does not have permission to perform this action" };

            await _repo.updateAsync(data);
            return new SaveResponse {  status = true, Result = "Brain Teaser successfully updated" };

        }

        public async Task<SaveResponse> DeleteBrainTeaser(int ID,int userID)
        {

            var userExist = await _uService.CheckIfUserExist(userID);
            if (!userExist)
                return new SaveResponse { status = false, Result = "User Not Found" };

            string name = "DeleteBrainTeaser";
            var permission = await _uService.CheckforPermission(userID, name);

            if (!permission)
                return new SaveResponse { Result = "User does not have permission to perform this action" };

            var answers = await _bRepo.getAllByIDAsync(ID);
            if(answers!=null)
                await _bRepo.deleteAllByIDAsync(ID);

            await _repo.deleteAsync(ID);

            
            return new SaveResponse { status = true, Result = "Brain Teaser successfully deleted" };

        }
    }
}
