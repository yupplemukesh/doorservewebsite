using Doorserve.Core.Dtos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Doorserve.Core.Pages
{
   public interface IPageContentService:IDisposable
    {
        Task<List<PageContentModel>> GetPageContents(Guid CompId, int PageId);
        Task<List<BannerModel>> GetPageBanners(Guid CompId, int PageId);
        void Save();
    }
}
