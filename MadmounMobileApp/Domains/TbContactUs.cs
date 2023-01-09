using System;
using System.Collections.Generic;
using System.Text;

namespace Domains
{
    public partial class TbContactUs
    {
        public Guid ContactUsId { get; set; }
        public string ContactUsName { get; set; }
        public string ContactUsEmail { get; set; }

        public string ContactUsText { get; set; }

      
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string Notes { get; set; }
    }
}
