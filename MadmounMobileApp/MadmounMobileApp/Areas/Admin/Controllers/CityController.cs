﻿using BL;
using Domains;
using MadmounMobileApp.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MadmounMobileApp.Areas.Admin.Controllers
{

    [Area("Admin")]
    
    public class CityController : Controller
    {
        CityService cityService;
        MadmounDbContext ctx;
        public CityController(CityService Cityservice, MadmounDbContext context)
        {
            cityService = Cityservice;
            ctx = context;

        }

        [Authorize(Roles = "Admin,المدن")]
        public IActionResult Index()
        {
            HomePageModel model = new HomePageModel();
            model.lstCities = cityService.getAll();
            return View(model);


        }



        [Authorize(Roles = "Admin,اضافة او تعديل المدن")]
        public async Task<IActionResult> Save(TbCity ITEM, int id, List<IFormFile> files)
        {

            //_4ZsoftwareCompanyTestTaskContext o_4ZsoftwareCompanyTestTaskContext = new _4ZsoftwareCompanyTestTaskContext();

            //ClsItems oClsItems = new ClsItems();

            //TbCountry oldItem = new TbCountry();
            //oldItem = ctx.TbCompanies.Where(a => a.CompanyId == id).FirstOrDefault();
            if (ITEM.CityId == Guid.Parse("00000000-0000-0000-0000-000000000000"))
            {
               



                cityService.Add(ITEM);


            }
            else
            {



                //oldItem.CompanyDescription = ITEM.CompanyDescription;
                //oldItem.CompanyImageName = ITEM.CompanyImageName;

                cityService.Edit(ITEM);

            }


            HomePageModel model = new HomePageModel();
            model.lstCities = cityService.getAll();


            return View("Index", model);
        }




        [Authorize(Roles = "Admin,حذف المدن ")]
        public IActionResult Delete(Guid id)
        {

            TbCity oldItem = ctx.TbCities.Where(a => a.CityId == id).FirstOrDefault();

            cityService.Delete(oldItem);

            HomePageModel model = new HomePageModel();
            model.lstCities = cityService.getAll();


            return View("Index", model);



        }




        public IActionResult Form(Guid? id)
        {
            TbCity oldItem = ctx.TbCities.Where(a => a.CityId == id).FirstOrDefault();
            oldItem = ctx.TbCities.Where(a => a.CityId == id).FirstOrDefault();
            
            return View(oldItem);
        }
    }
}
