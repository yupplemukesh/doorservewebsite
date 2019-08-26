using System;
using System.Collections.Generic;
using System.Text;

namespace Doorserve.Core.Dtos
{
   public class BannerModel
    {
        public string Name { get; set; }
        public string SectionName { get; set; }
        public string AltText { get; set; }
        public string Description { get; set; }
        public string HeaderTitle { get; set; }
        public string BannerFileName { get; set; }

        public string BannerLinkURL { get; set; }
    }
}
