﻿using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

using System.Web.Mvc;

namespace BL
{
    public class ApplicationUser:IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string CityName { get; set; }
        public Guid? CityId { get; set; }
        public Guid? AreaId { get; set; }


        public Guid? ServiceCategoryId { get; set; }


        public Guid? ServiceId { get; set; }


        public string ServiceName { get; set; }

        public string ServiceCategoryName { get; set; }



        public string AreaName { get; set; }

        public string Gender { get; set; }

        public string RyadahOrNot { get; set; }

        public DateTime? BirthDate { get; set; }

        public string Services { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string Notes { get; set; }


        public string DocumentA { get; set; }


        public string DocumentB { get; set; }


        public string DocumentC { get; set; }


        public string DocumentD { get; set; }

        public int? SerialDocumentA { get; set; }


        public int? SerialDocumentB { get; set; }


        public int? SerialDocumentC { get; set; }


        public int? SerialDocumentD { get; set; }

        public string StateName { get; set; }


        public int? state { get; set; }


        public string Cateegory { get; set; }


        public int? category { get; set; }


        public string PersonalPhoto { get; set; }
        //public IEnumerable<SelectListItem> RoleList { get; set; }
        //public string RoleSelected { get; set; }

        //public DateTime DateCreated { get; set; }
        [NotMapped]
        public string RoleId { get; set; }
        [NotMapped]
        public string Role { get; set; }


        [NotMapped]
        public List<SelectListItem> RoleList { get; set; }


        [NotMapped]
        public List<SelectListItem> RoleList2 { get; set; }
        [NotMapped]
        public List<string> RoleList3 { get; set; }


        [NotMapped]
        public IEnumerable<IdentityRole> RoleListMain { get; set; }
    }
}
