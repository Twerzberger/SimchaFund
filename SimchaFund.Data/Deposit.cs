using System;
using System.Collections.Generic;
using System.Text;

namespace SimchaFund.Data
{
    public class Deposit
    {
        public int Id { get; set; }
        public decimal Amount { get; set; }
        public DateTime DepositDate { get; set; }

        public int DonorId { get; set; }
    }
}
