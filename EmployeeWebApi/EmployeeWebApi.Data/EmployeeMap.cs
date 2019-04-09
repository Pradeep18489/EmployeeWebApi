using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeWebApi.Data
{
    public class EmployeeMap : EntityTypeConfiguration<Employee>
    {

        public EmployeeMap()
        {
            // Primary Key
            this.Property(t => t.EmployeeId).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            // Properties
            this.Property(t => t.EmployeeId)
                .IsRequired();

            // Table & Column Mappings
            this.ToTable("Employee");
            this.Property(t => t.FirstName).HasColumnName("FirstName");
            this.Property(t => t.LastName).HasColumnName("LastName");
            this.Property(t => t.Email).HasColumnName("Email");
        }
    }
}
