using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace SimchaFund.Data
{
    public class DonorRepository
    {
        private string _connectionString;

        public DonorRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public void AddNewDonor(Donor donor)
        {
            using (var ctx = new SimchaDonorContext(_connectionString))
            {
                ctx.Donor.Add(donor);
                ctx.SaveChanges();
            }
        }

        public void AddDeposit(Depsit depsit)
        {
            using (var ctx = new SimchaDonorContext(_connectionString))
            {
                ctx.Deposit.Add(depsit);
                ctx.SaveChanges();
            }
        }

        public IEnumerable<Donor> AllDonors()
        {
            using (var ctx = new SimchaDonorContext(_connectionString))
            {
                return ctx.Donor.ToList();
            }
        }

        public decimal GetBalanceForDonor(Donor donor)
        {
            using (var ctx = new SimchaDonorContext(_connectionString))
            {
                return (from d in ctx.Deposit
                        join sd in ctx.SimchaDonor on d.DonorId equals sd.DonorId
                        join don in ctx.Donor on sd.DonorId equals don.Id
                        where don.Id == donor.Id
                        select d.Amount - sd.Amount).FirstOrDefault();

                #region sql
                //ctx.Database.ExecuteSqlCommand(
                //    @"select sum(de.Amount) - sum(sd.Amount) from deposit de
                //        join SimchaDonor sd
                //        on de.DonorId = sd.DonorId
                //        join Donor d
                //        on d.Id = sd.DonorId
                //        where d.Id = @donor.Id",
                //    new SqlParameter("@donor.Id", donor.Id));
                //conn.Open();
                //SqlDataReader reader = cmd.ExecuteReader();
                #endregion
            }
        }
    }
}
