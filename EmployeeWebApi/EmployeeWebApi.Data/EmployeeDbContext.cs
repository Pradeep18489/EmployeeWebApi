using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeWebApi.Data
{
    public class EmployeeDbContext : DbContext
    {
        public EmployeeDbContext() : base(ConfigurationManager.ConnectionStrings["EmployeeDb"].ConnectionString)
        {
            Database.SetInitializer(new CreateDatabaseIfNotExists<EmployeeDbContext>());
        }

        public IDbSet<Employee> Employees { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new EmployeeMap());

            base.OnModelCreating(modelBuilder);
        }
    }
}
