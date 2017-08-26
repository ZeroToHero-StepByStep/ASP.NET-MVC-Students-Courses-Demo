namespace IC_Assignment.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddManyToManyRelationshipBetweenCustomersAndCourses : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CustomersCourses",
                c => new
                    {
                        CustomerId = c.Int(nullable: false),
                        CourseId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.CustomerId, t.CourseId })
                .ForeignKey("dbo.Customers", t => t.CustomerId, cascadeDelete: true )
                .ForeignKey("dbo.Courses", t => t.CourseId, cascadeDelete: true)
                .Index(t => t.CustomerId)
                .Index(t => t.CourseId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CustomersCourses", "CourseId", "dbo.Courses");
            DropForeignKey("dbo.CustomersCourses", "CustomerId", "dbo.Customers");
            DropIndex("dbo.CustomersCourses", new[] { "CourseId" });
            DropIndex("dbo.CustomersCourses", new[] { "CustomerId" });
            DropTable("dbo.CustomersCourses");
        }
    }
}
