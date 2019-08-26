using System;
using System.Collections.Generic;
using System.Text;

namespace Doorserve.Core.Dtos
{
   public class HeaderFooterModel
    {
        public ContactDetails Contact { get; set; }
        public string BaseUrl { get; set;    }
        public List<CategoryModel> Categories { get; set; }
    }
}
