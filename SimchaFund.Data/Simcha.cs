using System;
using System.Collections.Generic;
using System.Text;

namespace SimchaFund.Data
{
    public class Simcha
    {
        public int Id { get; set; }
        public string SimchaName { get; set; }
        public DateTime SimchaDate { get; set; }

        public List<SimchaDonor> SimchaDonors { get; set; }
    }
}
