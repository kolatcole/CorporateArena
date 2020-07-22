using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CorporateArena.Domain
{
    public interface IBrainTeaserService
    {
        Task<SaveResponse> SaveBrainTeaserAsync(BrainTeaser data);
        Task<SaveResponse> SubmitAnswerAsync(BrainTeaserAnswer data);
        Task<BrainTeaser> GetBrainTeaserandAnswerAsync(int ID);
        Task<SaveResponse> UpdateBrainTeaserAsync(BrainTeaser data);
        Task<SaveResponse> DeleteBrainTeaser(int ID,int userID);
    }
}
