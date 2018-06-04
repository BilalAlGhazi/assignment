using Microsoft.EntityFrameworkCore;
using Activity.API.Models;

namespace Activity.API.Data{
    public class DataContext:DbContext{
        public DataContext(DbContextOptions<DataContext> options): base(options){ }
        public DbSet<Participant> Participants { get; set; } 
    }
}