using BL;
using Domains;
using MadmounMobileApp.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System;
using Microsoft.AspNetCore.Authorization;

namespace MadmounMobileApp.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class WhoWeAreController : Controller
    {
        WhoWeAreService whoWeAreService;
        AdviceService adviceService;
        AdvertismentService advertismentService;
        ServiceCategoryService srviceCategoryService;
        ServiceService serviceService;
        CityService cityService;
        AreaService areaService;
        MadmounDbContext ctx;
        public WhoWeAreController(WhoWeAreService WhoWeAreService,AdviceService AdviceService, AdvertismentService AdvertismentService, ServiceCategoryService SrviceCategoryService, ServiceService ServiceService, CityService CityService, AreaService AreaService, MadmounDbContext context)
        {
            areaService = AreaService;
            ctx = context;
            cityService = CityService;
            serviceService = ServiceService;
            srviceCategoryService = SrviceCategoryService;
            advertismentService = AdvertismentService;
            adviceService = AdviceService;
            whoWeAreService = WhoWeAreService;
        }
        [Authorize(Roles = "Admin,من نحن")]
        public IActionResult Index()
        {
            HomePageModel model = new HomePageModel();
            model.lstAreas = areaService.getAll();
            model.lstCities = cityService.getAll();
            model.lstServices = serviceService.getAll();
            model.lstServicecATEGORIES = srviceCategoryService.getAll();
            model.lstAdvertisements = advertismentService.getAll();
            model.lstAdvices = adviceService.getAll();
            model.LstWhoWeAres = whoWeAreService.getAll();
            return View(model);


        }



        [Authorize(Roles = "Admin,من نحن")]
        public async Task<IActionResult> Save(TbWhoWeAre ITEM, int id, List<IFormFile> files)
        {

            //_4ZsoftwareCompanyTestTaskContext o_4ZsoftwareCompanyTestTaskContext = new _4ZsoftwareCompanyTestTaskContext();

            //ClsItems oClsItems = new ClsItems();

            //TbCountry oldItem = new TbCountry();
            //oldItem = ctx.TbCompanies.Where(a => a.CompanyId == id).FirstOrDefault();
            if (ITEM.WhoWeAreId == Guid.Parse("00000000-0000-0000-0000-000000000000"))
            {

                foreach (var file in files)
                {
                    if (file.Length > 0)
                    {
                        string ImageName = Guid.NewGuid().ToString() + ".jpg";
                        var filePaths = Path.Combine(Directory.GetCurrentDirectory(), @"wwwroot\Uploads", ImageName);
                        using (var stream = System.IO.File.Create(filePaths))
                        {
                            await file.CopyToAsync(stream);
                        }
                        ITEM.WhoWeAreImage = ImageName;
                    }
                }


                whoWeAreService.Add(ITEM);


            }
            else
            {
                foreach (var file in files)
                {
                    if (file.Length > 0)
                    {
                        string ImageName = Guid.NewGuid().ToString() + ".jpg";
                        var filePaths = Path.Combine(Directory.GetCurrentDirectory(), @"wwwroot\Uploads", ImageName);
                        using (var stream = System.IO.File.Create(filePaths))
                        {
                            await file.CopyToAsync(stream);
                        }
                        ITEM.WhoWeAreImage = ImageName;
                    }
                }


                //oldItem.CompanyDescription = ITEM.CompanyDescription;
                //oldItem.CompanyImageName = ITEM.CompanyImageName;

                whoWeAreService.Edit(ITEM);

            }


            HomePageModel model = new HomePageModel();
            model.lstAreas = areaService.getAll();
            model.lstCities = cityService.getAll();
            model.lstServices = serviceService.getAll();
            model.lstServicecATEGORIES = srviceCategoryService.getAll();
            model.lstAdvertisements = advertismentService.getAll();
            model.lstAdvices = adviceService.getAll();
            model.LstWhoWeAres = whoWeAreService.getAll();
            return View("Index", model);
        }




        [Authorize(Roles = "Admin,من نحن")]
        public IActionResult Delete(Guid id)
        {

            TbWhoWeAre oldItem = ctx.TbWhoWeAres.Where(a => a.WhoWeAreId == id).FirstOrDefault();

            whoWeAreService.Delete(oldItem);

            HomePageModel model = new HomePageModel();
            model.lstAreas = areaService.getAll();
            model.lstCities = cityService.getAll();
            model.lstServices = serviceService.getAll();
            model.lstServicecATEGORIES = srviceCategoryService.getAll();
            model.lstAdvertisements = advertismentService.getAll();
            model.lstAdvices = adviceService.getAll();
            model.LstWhoWeAres = whoWeAreService.getAll();
            return View("Index", model);



        }



        [Authorize(Roles = "Admin,من نحن")]
        public IActionResult Form(Guid? id)
        {
            TbWhoWeAre oldItem = ctx.TbWhoWeAres.Where(a => a.WhoWeAreId == id).FirstOrDefault();


            return View(oldItem);
        }
    }
}
