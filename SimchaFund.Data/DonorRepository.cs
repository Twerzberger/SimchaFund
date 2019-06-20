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

        public void AddDeposit(Deposit deposit)
        {
            using (var ctx = new SimchaDonorContext(_connectionString))
            {
                ctx.Deposit.Add(deposit);
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
                bool donate = AlreadyDonate(donor);

                if (donate)
                { 
                return (from d in ctx.Deposit
                        join sd in ctx.SimchaDonor on d.DonorId equals sd.DonorId
                        join don in ctx.Donor on sd.DonorId equals don.Id
                        where don.Id == donor.Id
                        select d.Amount - sd.Amount).FirstOrDefault();
                }

                return ctx.Deposit.Where(d => d.Id == donor.Id).Sum(d => d.Amount);

            }
        }

        private bool AlreadyDonate(Donor donor)
        {
            using (var ctx = new SimchaDonorContext(_connectionString))
            {
                return ctx.SimchaDonor.Any(s => s.DonorId == donor.Id);
            }
        }

        public void EditDonor(Donor donor)
        {
            using (var ctx = new SimchaDonorContext(_connectionString))
            {
                ctx.Database.ExecuteSqlCommand(
                    "UPDATE Donor SET FirstName = @firstName, Lastname = @lastName, CellNumber = @cellNumber WHERE Id = @id",                    
                    new SqlParameter("@id", donor.Id), new SqlParameter("@firstName", donor.FirstName),
                    new SqlParameter("@cellNumber", donor.CellNumber), new SqlParameter("@lastName", donor.LastName));
                ctx.SaveChanges();
            }
        }

        
    }
}
