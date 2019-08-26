using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DoorServe.Models;
using Doorserve.Core;
using Doorserve.Core.Dtos;
using Doorserve.Core.Pages;
using Microsoft.Extensions.Configuration;

namespace DoorServe.Controllers
{
    public class HomeController : Controller
    {
        private readonly IPageContentService PageService;
        private readonly ICommonService serv;
        private readonly string BaseUrl = "";
        public HomeController(IPageContentService _pageServices, IConfiguration config, ICommonService _serv )
        {
            PageService = _pageServices;
            BaseUrl=config.GetValue<string>("FilePath");
            serv = _serv;
        }
        public async Task<IActionResult> Index()
        {
            var page = new PageViewModel();
            page.BaseUrl = BaseUrl;
            page.PageContants = await PageService.GetPageContents(new Guid("06174296-86E0-41B6-A96F-916BE0F165F1"), 107);
            page.PageBanners = await PageService.GetPageBanners(new Guid("06174296-86E0-41B6-A96F-916BE0F165F1"), 107);
            return View(page);
        }
        public async Task<IActionResult> About()
        {
            var page = new PageViewModel();
            page.BaseUrl = BaseUrl;
            page.PageContants = await PageService.GetPageContents(new Guid("06174296-86E0-41B6-A96F-916BE0F165F1"), 109);
            page.PageBanners = await PageService.GetPageBanners(new Guid("06174296-86E0-41B6-A96F-916BE0F165F1"), 109);
            return View(page);
        }
        public async Task<IActionResult> Contact()
        {
            var page = new PageViewModel();
            page.BaseUrl = BaseUrl;
            page.PageContants = await PageService.GetPageContents(new Guid("06174296-86E0-41B6-A96F-916BE0F165F1"), 111);
            page.PageBanners = await PageService.GetPageBanners(new Guid("06174296-86E0-41B6-A96F-916BE0F165F1"), 111);
            page.Contact = await serv.GetConacts(new Guid("06174296-86E0-41B6-A96F-916BE0F165F1"));
            return View(page);
        }
        public async Task<IActionResult> Service()
        {
            var page = new PageViewModel();
            page.BaseUrl = BaseUrl;
            page.PageContants = await PageService.GetPageContents(new Guid("06174296-86E0-41B6-A96F-916BE0F165F1"), 108);
            page.PageBanners = await PageService.GetPageBanners(new Guid("06174296-86E0-41B6-A96F-916BE0F165F1"), 108);
            return View(page);
        }
        public async Task<IActionResult> Location()
        {
            return View();
        }


        public async Task<IActionResult> Career()
        {
            var page = new PageViewModel();
            page.BaseUrl = BaseUrl;
            page.PageContants = await PageService.GetPageContents(new Guid("06174296-86E0-41B6-A96F-916BE0F165F1"), 110);
            page.PageBanners = await PageService.GetPageBanners(new Guid("06174296-86E0-41B6-A96F-916BE0F165F1"), 110);
            return View(page);
        }

        public IActionResult Privacy()
        {
            return View();
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
