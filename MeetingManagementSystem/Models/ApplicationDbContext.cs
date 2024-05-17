using MeetingManagementSystem.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace MeetingManagementSystem.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions option):base(option)
        {

        }
        public DbSet<CorporateCustomer> CorporateCustomer { get; set; }
        public DbSet<IndivisualCustomer> IndivisualCustomer { get; set; }
        public DbSet<ProductService> ProductService { get;set; }
    }
}
