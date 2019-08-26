using Doorserve.Core;
using Doorserve.Core.Dtos;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DoorServe.Views.Shared.Components.Footer
{
    public class Footer:ViewComponent
    {

        private readonly ICommonService serv;
        public Footer(ICommonService _service)
        {
            serv = _service;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var header = new HeaderFooterModel();
            header.Contact = await serv.GetConacts(new Guid("06174296-86E0-41B6-A96F-916BE0F165F1"));
            header.Categories = await serv.GetCategories(new Guid("06174296-86E0-41B6-A96F-916BE0F165F1"));
            return View(header);
        }
    }
}
