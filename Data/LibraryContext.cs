using Library.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library.Data
{
    public class LibraryContext : DbContext

    {
        public DbSet<User> Users { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<BookExample> BookExamples { get; set; }
        public DbSet<BookUser> BookUsers { get; set; }



        public LibraryContext(DbContextOptions<LibraryContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelbuilder)
        {
            // skapa composite primary key
            // UserId och BookId är tillsammans alltså primary key
            modelbuilder.Entity<BookUser>()
                .HasKey(bu => new { bu.UserId, bu.BookId });

            // säga till EF vad relationen mellan BookUser och User är
            // sätta att UserId är foreign key 
            modelbuilder.Entity<BookUser>()
                .HasOne(bu => bu.User)
                .WithMany(u => u.BookUsers)
                .HasForeignKey(bu => bu.UserId);
            //.OnDelete(DeleteBehavior.Restrict)


            // säga till EF vad relationen mellan BookUser och Book är
            // sätta att BookId är foreign key 
            modelbuilder.Entity<BookUser>()
                .HasOne(bu => bu.Book)
                .WithMany(b => b.BookUsers)
                .HasForeignKey(bu => bu.BookId);
            //.OnDelete(DeleteBehavior.Restrict)
        }
    }


}

