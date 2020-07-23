using CorporateArena.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorporateArena.Infrastructure
{
    public class VacancyRepo : IRepo<Vacancy>
    {

        private readonly TContext _context;
        public VacancyRepo (TContext context)
        {
            _context = context;
        }
        public Task deleteAllByIDAsync(int ID)
        {
            throw new NotImplementedException();
        }

        public async Task deleteAsync(int ID)
        {
            try
            {
                var vacancy=await _context.Vacancies.FindAsync(ID);
                _context.Vacancies.Remove(vacancy);
                await _context.SaveChangesAsync();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<Vacancy>> getAllAsync()
        {
            try
            {
                var vacancies = await _context.Vacancies.ToListAsync();
                return vacancies;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public Task<List<Vacancy>> getAllByIDAsync(int ID)
        {
            throw new NotImplementedException();
        }

        public async Task<Vacancy> getAsync(int ID)
        {
           try
            {
                var vacancy = await _context.Vacancies.FindAsync(ID);
                return vacancy;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public async Task<int> insertAsync(Vacancy data)
        {
            try
            {
                var vacancy = new Vacancy
                {
                    DateCreated = DateTime.Now,
                    JobDescription = data.JobDescription,
                    JobTitle = data.JobTitle,
                    Company = data.Company,
                    Email = data.Email,
                    Location = data.Location,
                    Url = data.Url,
                    UserCreated = data.UserCreated
                };
                await _context.Vacancies.AddAsync(vacancy);
                await _context.SaveChangesAsync();
                return vacancy.ID;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public Task<bool> insertListAsync(List<Vacancy> data)
        {
            throw new NotImplementedException();
        }

        public async Task updateAsync(Vacancy data)
        {
            try
            {
                var vacancy=await _context.Vacancies.FindAsync(data.ID);
                if (data.JobDescription != null) vacancy.JobDescription = data.JobDescription;
                if (data.JobTitle != null) vacancy.JobTitle = data.JobTitle;
                if (data.Location != null) vacancy.Location = data.Location;
                if (data.Url != null) vacancy.Url = data.Url;
                if (data.Email != null) vacancy.Email = data.Email;
                if (data.Company != null) vacancy.Company = data.Company;
                vacancy.DateModified = DateTime.Now;

                _context.Vacancies.Update(vacancy);
                await _context.SaveChangesAsync();


            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
