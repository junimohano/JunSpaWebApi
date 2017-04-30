using JunSpaWebApi.Models;
using Microsoft.EntityFrameworkCore;

namespace JunSpaWebApi.Data
{
    public class JunSpaContext : DbContext
    {
        public JunSpaContext(DbContextOptions<JunSpaContext> options) : base(options)
        {
        }

        public DbSet<Board> Boards { get; set; }
        public DbSet<Comment> Comments{ get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Board>().ToTable("Board");
            modelBuilder.Entity<Comment>().ToTable("Comment");
        }
    }
}
