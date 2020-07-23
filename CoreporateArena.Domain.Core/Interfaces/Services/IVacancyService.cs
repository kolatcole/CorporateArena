using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CorporateArena.Domain
{
    public interface IVacancyService
    {
        Task<SaveResponse> SaveVacancyAsync(Vacancy data);

        Task<Vacancy> GetVacancyByIDAsync(int ID);
        
        Task<Vacancy> GetAllVacanciesAsync();
        
        Task<SaveResponse> UpdateVacancyAsync(Vacancy data);
        
        Task<SaveResponse> DeleteVacancyAsync(int ID);
    }
}
