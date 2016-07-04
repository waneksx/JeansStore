namespace DomainModel
{
    using Entities;
    using Migrations;
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class JeansDbContext : DbContext
    {

        public JeansDbContext()
            : base("name=JeansDbContext")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<JeansDbContext, Configuration>());
            //Database.SetInitializer(new DropCreateDatabaseIfModelChanges<JeansDbContext>());


        }



        public virtual DbSet<Jeans> Jeans { get; set; }        
    }
}
