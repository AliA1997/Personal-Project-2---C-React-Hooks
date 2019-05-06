using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Pomelo.EntityFrameworkCore.MySql;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Garago.Domain;
using Garago.Domain.Chat;

namespace Garago.Data
{
    public class GaragoContext: IdentityDbContext<GaragoUser>
    {
        public GaragoContext(DbContextOptions<GaragoContext> options) : base(options) { }

        public DbSet<GaragoUser> GaragoUsers { get; set; }

        public DbSet<GarageSale> GarageSales { get; set; }

        public DbSet<Product> Products { get; set; }

        public DbSet<GaragoChat> Chats { get; set; }

        public DbSet<ChatMessage> ChatMessages { get; set; }

        public DbSet<Review> Reviews { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            //builder.HasDefaultSchema("garago");
        }

    }

    /// /////////
    ///Define a DBCOntextFactory class that will be responsible for initializing a new instance of your context class inheriting the IDesignTimeDBContextfactory class.
    /// //////////
    public class ApplicationContextDbFactory : IDesignTimeDbContextFactory<GaragoContext>
    {
        //Use the CreateDbContext method passing your args 
        GaragoContext IDesignTimeDbContextFactory<GaragoContext>.CreateDbContext(string[] args)
        {
            //Define yourj options builder that will be used to connect to your database.
            DbContextOptionsBuilder<GaragoContext> optionsBuilder = new DbContextOptionsBuilder<GaragoContext>();

            //THen use my sql to connect to your database.
            optionsBuilder.UseMySql<GaragoContext>("Server=127.0.0.1;Database=garago;Uid=root;Pwd=root;");

            //Then return your DbContext with your DbContextOptions.
            return new GaragoContext(optionsBuilder.Options);
        }
    }
}
