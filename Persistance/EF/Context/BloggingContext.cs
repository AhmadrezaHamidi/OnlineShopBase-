using Domain.Auth;
using Domain.Entitites;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace Application.EF.Context
{
    public class BloggingContext : DbContext
    {
        //public BloggingContext()
        //{

        //}
        public BloggingContext(DbContextOptions<BloggingContext> options)
            : base(options)
        { }

        public DbSet<Blog> Blogs { get; set; }
        public DbSet<Post> Posts { get; set; }

        protected override  void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            //optionsBuilder.ApplyConfigurationsFromAssembly(typeof(UserConfig).Assembly);
        }
        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    //    modelBuilder.Entity<Blog>()
        //    //  .Property(b => b.Url)
        //    //  .IsRequired();

        //    //    // تنظیمات خاص برای Post
        //    //    modelBuilder.Entity<Post>()
        //    //        .Property(p => p.Title)
        //    //        .IsRequired();

        //    // مثال از رابطه بین Blog و Post

        //    //modelBuilder.EnableAutoHistory(null);
        //}
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    if (!optionsBuilder.IsConfigured)
        //    {
        //        optionsBuilder.UseSqlServer("Server= 192.168.2.9 ;Database=AhmadTest ; User Id=YozDBUser; Password=YozDBUser!_!13970603; Encrypt=False");
        //    }
        //}
    }
}
