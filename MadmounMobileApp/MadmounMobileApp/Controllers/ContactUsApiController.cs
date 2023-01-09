using BL;
using MadmounMobileApp.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MadmounMobileApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactUsApiController : ControllerBase
    {
        IAccountRepository _accountRepository;
        ContactUsService contactUsService;
        WhoWeAreService whoWeAreService;
        UserManager<ApplicationUser> Usermanager;
        AdviceService adviceService;
        AdvertismentService advertismentService;
        ServiceCategoryService srviceCategoryService;
        ServiceService serviceService;
        CityService cityService;
        AreaService areaService;
        MadmounDbContext ctx;
        public ContactUsApiController(IAccountRepository AccountRepository,ContactUsService ContactUsService,WhoWeAreService WhoWeAreService, UserManager<ApplicationUser> usermanager, AdviceService AdviceService, AdvertismentService AdvertismentService, ServiceCategoryService SrviceCategoryService, ServiceService ServiceService, CityService CityService, AreaService AreaService, MadmounDbContext context)
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
            contactUsService = ContactUsService;
            _accountRepository = AccountRepository;
        }
        // GET: api/<ContactUsApiController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<ContactUsApiController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<ContactUsApiController>
        [HttpPost("contactus")]
        public IActionResult ContactUs([FromForm] ContactUsViewPageModel model)
        {
            var result = _accountRepository.ContactUs(model);

            if(result) 
            {
                return Ok("the data is sent");

            }
            else 
            {
                return BadRequest("the data is not sent");
              
            }
        }

        // PUT api/<ContactUsApiController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ContactUsApiController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
