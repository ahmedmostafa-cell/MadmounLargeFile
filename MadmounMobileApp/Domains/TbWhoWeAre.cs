using System;
using System.Collections.Generic;
using System.Text;

namespace Domains
{
    public partial class TbWhoWeAre
    {
        public Guid WhoWeAreId { get; set; }
        public string WhoWeAreTitle { get; set; }
        public string WhoWeAreDescription { get; set; }

        public string WhoWeAreImage { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string Notes { get; set; }
    }
}
