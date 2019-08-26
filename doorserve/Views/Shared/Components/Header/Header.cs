using Doorserve.Core;
using Doorserve.Core.Dtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DoorServe.Views.Shared.Components
{
    public class Header: ViewComponent
    {
        private readonly ICommonService serv;
        private readonly string BaseUrl = "";
        public Header(ICommonService _serv, IConfiguration config)
        {
            serv = _serv;
            BaseUrl = config.GetValue<string>("FilePath");
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var header = new HeaderFooterModel();
            header.BaseUrl = BaseUrl;
            header.Contact = await serv.GetConacts(new Guid("06174296-86E0-41B6-A96F-916BE0F165F1"));
            header.Categories = await serv.GetCategories(new Guid("06174296-86E0-41B6-A96F-916BE0F165F1"));
            return View(header);
        }
    }
}
