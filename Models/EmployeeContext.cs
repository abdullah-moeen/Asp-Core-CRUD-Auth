using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CORE_CRUD.Models
{
    public class EmployeeContext : IdentityDbContext<AppUser, AppRole, int>
    {
        //providing the DbContext Provider through Instance
        //we are passing the Context provider value into application using dependency injection
        public EmployeeContext(DbContextOptions<EmployeeContext> options)
            : base(options)
        {
        }

        public DbSet<Employee> Employees { get; set; }

    }
}
