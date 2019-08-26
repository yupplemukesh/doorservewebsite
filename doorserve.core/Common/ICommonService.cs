using Doorserve.Core.Dtos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Doorserve.Core
{
   public interface ICommonService:IDisposable
    {
        Task<List<CategoryModel>> GetCategories(Guid compId);
        Task<ContactDetails> GetConacts(Guid compId);
        void Save();
    }
}
