using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SimchaFund.Data;

namespace SimchaFund.Web.Models
{
    public class DonorViewModel
    {
        public IEnumerable<Donor> Donor { get; set; }
        //public decimal Amount { get; set; }
    }
}
