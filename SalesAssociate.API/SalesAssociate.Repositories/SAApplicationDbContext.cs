using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SalesAssociate.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace SalesAssociate.Repositories
{
    public class SAApplicationDbContext :DbContext
    {
        public SAApplicationDbContext(DbContextOptions<SAApplicationDbContext> options)
           : base(options)
        {
            // This is where you can use the Fluent API to have finer control over the database setup.
            // Anything you can do with data annotations on the entity models can also be done with the
            // fluent API.
        }

        public DbSet<Car> Cars => Set<Car>();

    }
}
