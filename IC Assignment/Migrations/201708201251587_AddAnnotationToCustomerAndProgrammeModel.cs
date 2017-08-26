namespace IC_Assignment.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddAnnotationToCustomerAndProgrammeModel : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Customers", "City", c => c.String(maxLength: 20));
            AlterColumn("dbo.Customers", "Name", c => c.String(maxLength: 20));
            AlterColumn("dbo.Programmes", "Name", c => c.String(nullable: false, maxLength: 50));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Programmes", "Name", c => c.String());
            AlterColumn("dbo.Customers", "Name", c => c.String());
            AlterColumn("dbo.Customers", "City", c => c.String());
        }
    }
}
