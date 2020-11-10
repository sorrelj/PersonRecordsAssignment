using Microsoft.EntityFrameworkCore;
using Project_Assignment.Models;

namespace Project_Assignment.Data
{
    // person records db context
    public class PersonRecordsContext : DbContext
    {
        public PersonRecordsContext(DbContextOptions<PersonRecordsContext> options) : base(options)
        {
        }

        public DbSet<Person> Person { get; set; }
    }
}
