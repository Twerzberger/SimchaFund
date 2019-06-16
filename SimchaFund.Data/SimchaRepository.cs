using System;
using System.Collections.Generic;
using System.Text;

namespace SimchaFund.Data
{
    public class SimchaRepository
    {
        private string _connectionString;

        public SimchaRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public void AddSimcha(Simcha simcha)
        {
            using (var ctx = new SimchaDonorContext(_connectionString))
            {
                ctx.Simcha.Add(simcha);
                ctx.SaveChanges();
            }
        }
    }
}
