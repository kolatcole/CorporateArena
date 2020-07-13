using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using static CorporateArena.Domain.Models;

namespace CorporateArena.Domain
{
    public interface IPrivilegeService
    {
        Task<MyEnum> GetActionsAsync();
        Task<Dictionary<string,string>> GetModelsAsync();
    }
}
