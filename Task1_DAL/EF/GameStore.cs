using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task1_DAL.Content;
using Task1_DAL.Entities;

namespace Task1_DAL.EF
{
    public class GameStore : DbContext
    {
        public DbSet<Game> Games { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<PlatformType> PlatformTypes { get; set; }

        static GameStore()
        {
            Database.SetInitializer<GameStore>(new StoreDbInitializer());
        }

        public GameStore(string connectionString)
: base(connectionString)
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Genre>()
                .HasOptional(p => p.Parent)
                .WithMany()
                .HasForeignKey(k => k.ParentId);

            modelBuilder.Entity<Comment>()
               .HasOptional(p => p.Parent)
               .WithMany(p=>p.CommentResponses)
               .HasForeignKey(k => k.ParentId);

            base.OnModelCreating(modelBuilder);
        }
    }
}
