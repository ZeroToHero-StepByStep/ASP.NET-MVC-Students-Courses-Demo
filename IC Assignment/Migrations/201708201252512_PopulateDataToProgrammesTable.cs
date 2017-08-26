namespace IC_Assignment.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateDataToProgrammesTable : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Programmes (Name) VALUES ('FatBurn')");
            Sql("INSERT INTO Programmes (Name) VALUES ('MuscleBuild')");
            Sql("INSERT INTO Programmes (Name) VALUES ('Regular')");
            Sql("INSERT INTO Programmes (Name) VALUES ('Aerobic')");
        }
        
        public override void Down()
        {
        }
    }
}
