using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;

namespace My_English_Training_Application_Web_Form_.Database_Models
{
    public class DatabaseMigration:DbMigrationsConfiguration<DatabaseContext>
    {
        public DatabaseMigration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = false;
        }
    }
}