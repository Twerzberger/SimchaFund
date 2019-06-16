﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using SimchaFund.Data;
using SimchaFund.Web.Models;

namespace SimchaFund.Web.Controllers
{
    public class DonorController : Controller
    {
        private string _connectionString;

        public DonorController(IConfiguration configuration )
        {
            _connectionString = configuration.GetConnectionString("ConStr");
        }

        public IActionResult Index()
        {
            var rep = new DonorRepository(_connectionString);
            var donors = rep.AllDonors();
            foreach (var don in donors)
            {
                don.Ballance = rep.GetBalanceForDonor(don);                
            }
            var vm = new DonorViewModel
            {
                Donor = donors
            };
            return View(vm);
        }

        public IActionResult NewDonor(Donor donor, decimal amount)
        {
            var rep = new DonorRepository(_connectionString);
            rep.AddNewDonor(donor);

            var deposit = new Depsit
            {
                DonorId = donor.Id,
                Amount = amount,
                DepositDate = donor.DateCreated
            };

            rep.AddDeposit(deposit);

            return Redirect("/");
        }

        
    }
}