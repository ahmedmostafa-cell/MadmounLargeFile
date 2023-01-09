using System;
using System.Collections.Generic;
using System.Text;

namespace Domains
{
    public partial class TbTermsOfUse
    {
        public Guid TermsOfUseId { get; set; }
        public string TermsOfUseTitle { get; set; }
        public string TermsOfUseDescription { get; set; }

        public string TermsOfUseImage { get; set; }

        public string TermsOfUseToWhom { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string Notes { get; set; }
    }
}
