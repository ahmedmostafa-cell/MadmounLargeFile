﻿using System;
using System.Collections.Generic;

#nullable disable

namespace Domains
{
    public partial class TbServicesApproved
    {
        public TbServicesApproved()
        {
            TbServiceApprovedImages = new HashSet<TbServiceApprovedImage>();
            TbServiceApprovedMilstones = new HashSet<TbServiceApprovedMilstone>();
        }

        public Guid ServiceApprovedId { get; set; }
        public string ServiceSyntax { get; set; }
        public string SrRepId { get; set; }
        public string SrReqId { get; set; }
        public string SrOffId { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string Notes { get; set; }
        public Guid? ServiceId { get; set; }
        public Guid? CityId { get; set; }
        public Guid? AreaId { get; set; }
        public string ContractPdf { get; set; }
        public string SrApprovedDescription { get; set; }

        public virtual TbArea Area { get; set; }
        public virtual TbCity City { get; set; }
        public virtual TbService Service { get; set; }
        public virtual ICollection<TbServiceApprovedImage> TbServiceApprovedImages { get; set; }
        public virtual ICollection<TbServiceApprovedMilstone> TbServiceApprovedMilstones { get; set; }
    }
}
