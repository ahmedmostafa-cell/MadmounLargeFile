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
    public class ContactUsController : Controller
    {
        ContactUsService contactUsService;
        TermsOfUseService termsOfUseService;
        WhoWeAreService whoWeAreService;
        AdviceService adviceService;
        AdvertismentService advertismentService;
        ServiceCategoryService srviceCategoryService;
        ServiceService serviceService;
        CityService cityService;
        AreaService areaService;
        MadmounDbContext ctx;
        public ContactUsController(ContactUsService ContactUsService,TermsOfUseService TermsOfUseService, WhoWeAreService WhoWeAreService, AdviceService AdviceService, AdvertismentService AdvertismentService, ServiceCategoryService SrviceCategoryService, ServiceService ServiceService, CityService CityService, AreaService AreaService, MadmounDbContext context)
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
            contactUsService = ContactUsService;
        }
        [Authorize(Roles = "Admin,تواصل معنا")]
        public IActionResult Index()
        {
            HomePageModel model = new HomePageModel();
            model.LstContactUss = contactUsService.getAll();
            return View(model);


        }



        [Authorize(Roles = "Admin,تواصل معنا")]
        public async Task<IActionResult> Save(TbContactUs ITEM, int id, List<IFormFile> files)
        {

            //_4ZsoftwareCompanyTestTaskContext o_4ZsoftwareCompanyTestTaskContext = new _4ZsoftwareCompanyTestTaskContext();

            //ClsItems oClsItems = new ClsItems();

            //TbCountry oldItem = new TbCountry();
            //oldItem = ctx.TbCompanies.Where(a => a.CompanyId == id).FirstOrDefault();
            if (ITEM.ContactUsId == Guid.Parse("00000000-0000-0000-0000-000000000000"))
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
                        //ITEM.TermsOfUseImage = ImageName;
                    }
                }


                contactUsService.Add(ITEM);


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
                        //ITEM.TermsOfUseImage = ImageName;
                    }
                }


                //oldItem.CompanyDescription = ITEM.CompanyDescription;
                //oldItem.CompanyImageName = ITEM.CompanyImageName;

                contactUsService.Edit(ITEM);

            }


            HomePageModel model = new HomePageModel();
            model.LstContactUss = contactUsService.getAll();
            return View("Index", model);
        }




        [Authorize(Roles = "Admin,تواصل معنا")]
        public IActionResult Delete(Guid id)
        {

            TbContactUs oldItem = ctx.TbContactUss.Where(a => a.ContactUsId == id).FirstOrDefault();

            contactUsService.Delete(oldItem);

            HomePageModel model = new HomePageModel();
            model.LstContactUss = contactUsService.getAll();
            return View("Index", model);



        }



        [Authorize(Roles = "Admin,تواصل معنا")]
        public IActionResult Form(Guid? id)
        {
            TbContactUs oldItem = ctx.TbContactUss.Where(a => a.ContactUsId == id).FirstOrDefault();


            return View(oldItem);
        }
    }
}
