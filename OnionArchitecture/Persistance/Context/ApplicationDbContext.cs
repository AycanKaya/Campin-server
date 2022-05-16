using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Interfaces;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Application.Context
{
    public class ApplicationDbContext : DbContext, IApplicationDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Customer> Customer { get; set; }
        DbSet<Customer> IApplicationDbContext.Customers { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public async Task<int> SaveChanges()
        {
            return await base.SaveChangesAsync();
        }

        Task<int> IApplicationDbContext.SaveChanges()
        {
            throw new NotImplementedException();
        }

        Task<int> IApplicationDbContext.SaveChangesAsync()
        {
            throw new NotImplementedException();
        }
    }
}
