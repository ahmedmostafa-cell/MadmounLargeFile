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
    public class TermsOfUseController : Controller
    {
        TermsOfUseService termsOfUseService;
        WhoWeAreService whoWeAreService;
        AdviceService adviceService;
        AdvertismentService advertismentService;
        ServiceCategoryService srviceCategoryService;
        ServiceService serviceService;
        CityService cityService;
        AreaService areaService;
        MadmounDbContext ctx;
        public TermsOfUseController(TermsOfUseService TermsOfUseService ,WhoWeAreService WhoWeAreService, AdviceService AdviceService, AdvertismentService AdvertismentService, ServiceCategoryService SrviceCategoryService, ServiceService ServiceService, CityService CityService, AreaService AreaService, MadmounDbContext context)
        {
            areaService = AreaService;
            ctx = context;
            cityService = CityService;
            serviceService = ServiceService;
            srviceCategoryService = SrviceCategoryService;
            advertismentService = AdvertismentService;
            adviceService = AdviceService;
            whoWeAreService = WhoWeAreService;
            termsOfUseService = TermsOfUseService;
        }
        [Authorize(Roles = "Admin,شروط الاستخدام")]
        public IActionResult Index()
        {
            HomePageModel model = new HomePageModel();
            model.LstTermsOfUses = termsOfUseService.getAll();
            return View(model);


        }



        [Authorize(Roles = "Admin,شروط الاستخدام")]
        public async Task<IActionResult> Save(TbTermsOfUse ITEM, int id, List<IFormFile> files)
        {

            //_4ZsoftwareCompanyTestTaskContext o_4ZsoftwareCompanyTestTaskContext = new _4ZsoftwareCompanyTestTaskContext();

            //ClsItems oClsItems = new ClsItems();

            //TbCountry oldItem = new TbCountry();
            //oldItem = ctx.TbCompanies.Where(a => a.CompanyId == id).FirstOrDefault();
            if (ITEM.TermsOfUseId == Guid.Parse("00000000-0000-0000-0000-000000000000"))
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
                        ITEM.TermsOfUseImage = ImageName;
                    }
                }


                termsOfUseService.Add(ITEM);


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
                        ITEM.TermsOfUseImage = ImageName;
                    }
                }


                //oldItem.CompanyDescription = ITEM.CompanyDescription;
                //oldItem.CompanyImageName = ITEM.CompanyImageName;

                termsOfUseService.Edit(ITEM);

            }


            HomePageModel model = new HomePageModel();
            model.LstTermsOfUses = termsOfUseService.getAll();
            return View("Index", model);
        }




        [Authorize(Roles = "Admin,شروط الاستخدام")]
        public IActionResult Delete(Guid id)
        {

            TbTermsOfUse oldItem = ctx.TbTermsOfUses.Where(a => a.TermsOfUseId == id).FirstOrDefault();

            termsOfUseService.Delete(oldItem);

            HomePageModel model = new HomePageModel();
            model.LstTermsOfUses = termsOfUseService.getAll();
            return View("Index", model);



        }



        [Authorize(Roles = "Admin,شروط الاستخدام")]
        public IActionResult Form(Guid? id)
        {
            TbTermsOfUse oldItem = ctx.TbTermsOfUses.Where(a => a.TermsOfUseId == id).FirstOrDefault();


            return View(oldItem);
        }
    }
}
