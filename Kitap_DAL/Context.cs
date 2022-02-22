using Kitap_ENTITIES;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kitap_DAL
{
    public class Context:DbContext
    {
        public Context(DbContextOptions<Context>options):base(options)
        {

        }

        public DbSet<Book> Books { get; set; }
        public DbSet<Category> Categories { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book>().ToTable("tbl_Book");         
            modelBuilder.Entity<Category>().ToTable("tbl_Category");
            modelBuilder.Entity<Book>().Property(x => x.BookName).IsRequired().HasMaxLength(40);
            modelBuilder.Entity<Category>().Property(x => x.CategoryName).IsRequired().HasMaxLength(20);
        }

    }
}
