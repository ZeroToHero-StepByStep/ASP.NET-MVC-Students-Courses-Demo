namespace IC_Assignment.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DeleteForeignKeyOfCourseInCustomersTable : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Customers", "CourseId", "dbo.Courses");
            DropIndex("dbo.Customers", new[] { "CourseId" });
            DropColumn("dbo.Customers", "CourseId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Customers", "CourseId", c => c.Int(nullable: false));
            CreateIndex("dbo.Customers", "CourseId");
            AddForeignKey("dbo.Customers", "CourseId", "dbo.Courses", "Id", cascadeDelete: true);
        }
    }
}
