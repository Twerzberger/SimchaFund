using System;
using System.Collections.Generic;
using System.Text;

namespace SimchaFund.Data
{
    public class SimchaDonor
    {
        public int SimchaId { get; set; }
        public int DonorId { get; set; }
        public decimal Amount { get; set; }

        public Donor Donor { get; set; }
        public Simcha Simchas { get; set; }
    }
}
