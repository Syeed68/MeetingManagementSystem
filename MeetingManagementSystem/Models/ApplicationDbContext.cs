using MeetingManagementSystem.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace MeetingManagementSystem.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions option):base(option)
        {

        }
        public DbSet<Customer> Customer { get; set; }
    }
}
