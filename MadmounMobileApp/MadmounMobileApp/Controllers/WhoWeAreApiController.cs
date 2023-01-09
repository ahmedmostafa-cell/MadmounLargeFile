using BL;
using Domains;
using MadmounMobileApp.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MadmounMobileApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WhoWeAreApiController : ControllerBase
    {
        WhoWeAreService whoWeAreService;
        UserManager<ApplicationUser> Usermanager;
        AdviceService adviceService;
        AdvertismentService advertismentService;
        ServiceCategoryService srviceCategoryService;
        ServiceService serviceService;
        CityService cityService;
        AreaService areaService;
        MadmounDbContext ctx;
        public WhoWeAreApiController(WhoWeAreService WhoWeAreService,UserManager<ApplicationUser> usermanager, AdviceService AdviceService, AdvertismentService AdvertismentService, ServiceCategoryService SrviceCategoryService, ServiceService ServiceService, CityService CityService, AreaService AreaService, MadmounDbContext context)
        {
            whoWeAreService = WhoWeAreService;
            areaService = AreaService;
            ctx = context;
            cityService = CityService;
            serviceService = ServiceService;
            srviceCategoryService = SrviceCategoryService;
            advertismentService = AdvertismentService;
            adviceService = AdviceService;
            Usermanager = usermanager;
        }
        // GET: api/<WhoWeAreApiController>
        [HttpGet]
        public IEnumerable<TbWhoWeAre> Get()
        {
            HomePageModel model = new HomePageModel();
            model.LstWhoWeAres = whoWeAreService.getAll();
            return model.LstWhoWeAres;
        }

        // GET api/<WhoWeAreApiController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<WhoWeAreApiController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<WhoWeAreApiController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<WhoWeAreApiController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
