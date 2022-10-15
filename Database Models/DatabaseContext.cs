using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace My_English_Training_Application_Web_Form_.Database_Models
{
    public class DatabaseContext : DbContext
    {
        public DbSet<Lectures> lectures { get; set; }
        public DbSet<PhrasesOrWords> phrasesOrWords { get; set; }
        public DbSet<Examples> examples { get; set; }
        //public DbSet<Post> Posts { get; set; }
        public DatabaseContext() : base("Data Source=Winner;Initial Catalog=MyEnglishTrainer;Integrated Security=True")
        {
            Database.SetInitializer<DatabaseContext>(new MigrateDatabaseToLatestVersion<DatabaseContext, DatabaseMigration>());
            //Database.SetInitializer<DatabaseContext>(new CreateDatabaseIfNotExists<DatabaseContext>());
        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}