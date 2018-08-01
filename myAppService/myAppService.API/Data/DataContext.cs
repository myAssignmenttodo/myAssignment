using Microsoft.EntityFrameworkCore;
using myAppService.API.models;

namespace myAppService.API.Data
{
    public class DataContext : DbContext
    {    
        public DataContext(DbContextOptions<DataContext>  options) : base (options) {}
        public DbSet<Train> Train { get; set; }
        public DbSet<Scheduler> Schedulers { get; set; }
    
    }   
}