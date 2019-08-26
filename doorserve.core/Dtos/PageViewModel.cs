using System;
using System.Collections.Generic;
using System.Text;

namespace Doorserve.Core.Dtos
{
   public class PageViewModel
    {
        public List<PageContentModel> PageContants { get; set; }
        public List<BannerModel> PageBanners{ get; set; }
        public ContactDetails Contact { get; set;   }
        public string BaseUrl { get; set;    }
    }
}
