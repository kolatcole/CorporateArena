using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CorporateArena.Domain
{
    public class TrafficUpdateService: ITrafficUpdateService
    {
        private readonly IRepo<TrafficComment> _cRepo;
        private readonly IRepo<TrafficUpdate> _uRepo;
        private readonly IUserService _uService;

        public TrafficUpdateService(IRepo<TrafficComment> cRepo,IRepo<TrafficUpdate> uRepo, IUserService uService)
        {
            _cRepo = cRepo;
            _uRepo = uRepo;
            _uService = uService;
        }

        public async Task<TrafficUpdate> GetTrafficUpdateWithComments(int ID)
        {
            var trafficUpdate = await _uRepo.getAsync(ID);

            var comments = await _cRepo.getAllByIDAsync(ID);
            if (comments != null)
                trafficUpdate.TrafficUpdateComments = comments;

            return trafficUpdate;
        }

        public async Task<SaveResponse> SaveTrafficUpdateAsync(TrafficUpdate data)
        {
            var userExist = await _uService.CheckIfUserExist(data.UserCreated);
            if (!userExist)
                return new SaveResponse { status = false, Result = "User Not Found" };

            string name = "CreateTrafficUpdate";
            var permission = await _uService.CheckforPermission(data.UserCreated, name);

            if (!permission)
                return new SaveResponse { Result = "User does not have permission to perform this action" };

            int TID = await _uRepo.insertAsync(data);
            return new SaveResponse { ID = TID, status = true, Result = "Traffic Update successfully created" };
        }

        public async Task<SaveResponse> SaveTrafficUpdateCommentAsync(TrafficComment data)
        {
            var userExist = await _uService.CheckIfUserExist(data.UserCreated);
            if (!userExist)
                return new SaveResponse { status = false, Result = "User Not Found" };

            int CID = await _cRepo.insertAsync(data);
            return new SaveResponse { ID = CID, status = true, Result = "Comment successfully submitted" };
        }

        public async Task<SaveResponse> DeleteArticleAsync(int ID, int userID)
        {

            var userExist = await _uService.CheckIfUserExist(userID);
            if (!userExist)
                return new SaveResponse { status = false, Result = "User Not Found" };

            string name = "DeleteTrafficUpdate";
            var permission = await _uService.CheckforPermission(userID, name);

            if (!permission)
                return new SaveResponse { Result = "User does not have permission to perform this action" };

            var comments = await _cRepo.getAllByIDAsync(ID);
            if (comments != null)
                await _cRepo.deleteAllByIDAsync(ID);

            await _uRepo.deleteAsync(ID);


            return new SaveResponse { status = true, Result = "Traffic Update successfully deleted" };

        }

    }
}
