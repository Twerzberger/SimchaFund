using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace SimchaFund.Data
{
    public class Donor
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string CellNumber { get; set; }
        public DateTime DateCreated { get; set; }

        [NotMapped]
        public decimal Ballance { get; set; }


        public List<Depsit> Depsits { get; set; }
        public List<SimchaDonor> SimchaDonors { get; set; }

       
    }
}
