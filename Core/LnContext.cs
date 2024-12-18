using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FnPrDotnet
{
    public class LnContext : DbContext
    {
        public DbSet<TermType> TermTypes { get; set; }
        
        public DbSet<Term> Terms { get; set; }
        
        public DbSet<UserDictionaryStatus> UserDictionaryStatuses { get; set; }
        public DbSet<UserDictionary> UserDictionarys { get; set; }
        
        public DbSet<UserStatus> UserStatuses { get; set; }
        public DbSet<User> Users { get; set; }
        
        public DbSet<TestType> TestTypes { get; set; }
        public DbSet<Test> Tests { get; set; }
        
        public DbSet<Result> Results { get; set; }
        public DbSet<WordList> WordLists { get; set; }
        
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=localhost,1433;Database=LearnLanguageDB;User Id=sa;Password=Admin123!123;TrustServerCertificate=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //term config
            modelBuilder.Entity<Term>()
                .HasOne(t => t.TermType)
                .WithMany(t => t.terms)
                .HasForeignKey(t => t.termTypeId)
                .OnDelete(DeleteBehavior.ClientSetNull);
            
            modelBuilder.Entity<WordList>()
                .HasMany(w => w.UserDictionary)
                .WithMany(ud => ud.WordList);
            modelBuilder.Entity<User>()
                .HasMany(u => u.WordList)
                .WithOne(w => w.user)
                .HasForeignKey(w => w.createdBy)
                .OnDelete(DeleteBehavior.ClientSetNull); // Prevent cascading deletes*/
        }

    }
}
