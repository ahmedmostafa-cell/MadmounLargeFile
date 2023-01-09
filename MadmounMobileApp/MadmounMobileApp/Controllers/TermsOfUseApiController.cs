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
    public class TermsOfUseApiController : ControllerBase
    {
        TermsOfUseService termsOfUseService;
        WhoWeAreService whoWeAreService;
        UserManager<ApplicationUser> Usermanager;
        AdviceService adviceService;
        AdvertismentService advertismentService;
        ServiceCategoryService srviceCategoryService;
        ServiceService serviceService;
        CityService cityService;
        AreaService areaService;
        MadmounDbContext ctx;
        public TermsOfUseApiController(TermsOfUseService TermsOfUseService,WhoWeAreService WhoWeAreService, UserManager<ApplicationUser> usermanager, AdviceService AdviceService, AdvertismentService AdvertismentService, ServiceCategoryService SrviceCategoryService, ServiceService ServiceService, CityService CityService, AreaService AreaService, MadmounDbContext context)
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
            termsOfUseService = TermsOfUseService;
        }
        // GET: api/<TermsOfUseApiController>
        [HttpGet]
        public IEnumerable<TbTermsOfUse> Get()
        {
            HomePageModel model = new HomePageModel();
            model.LstTermsOfUses = termsOfUseService.getAll();
            return model.LstTermsOfUses;
        }

        // GET api/<TermsOfUseApiController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<TermsOfUseApiController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<TermsOfUseApiController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<TermsOfUseApiController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
