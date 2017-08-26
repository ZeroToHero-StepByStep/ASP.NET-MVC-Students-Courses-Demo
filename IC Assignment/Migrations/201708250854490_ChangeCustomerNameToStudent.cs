namespace IC_Assignment.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeCustomerNameToStudent : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Customers", newName: "Students");
            DropForeignKey("dbo.CustomersCourses", "CustomerId", "dbo.Customers");
            DropForeignKey("dbo.CustomersCourses", "CourseId", "dbo.Courses");
            DropIndex("dbo.CustomersCourses", new[] { "CustomerId" });
            DropIndex("dbo.CustomersCourses", new[] { "CourseId" });
            CreateTable(
                "dbo.StudentsCourses",
                c => new
                    {
                        StudentId = c.Int(nullable: false),
                        CourseId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.StudentId, t.CourseId })
                .ForeignKey("dbo.Students", t => t.StudentId, cascadeDelete: true)
                .ForeignKey("dbo.Courses", t => t.CourseId, cascadeDelete: true)
                .Index(t => t.StudentId)
                .Index(t => t.CourseId);
            
            //keep previous data from CustomersCourses Table before dropping 
            Sql("INSERT INTO StudentsCourses (StudentId,CourseId) SELECT CustomerId,CourseId FROM CustomersCourses");

            DropTable("dbo.CustomersCourses");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.CustomersCourses",
                c => new
                    {
                        CustomerId = c.Int(nullable: false),
                        CourseId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.CustomerId, t.CourseId });
            
            DropForeignKey("dbo.StudentsCourses", "CourseId", "dbo.Courses");
            DropForeignKey("dbo.StudentsCourses", "StudentId", "dbo.Students");
            DropIndex("dbo.StudentsCourses", new[] { "CourseId" });
            DropIndex("dbo.StudentsCourses", new[] { "StudentId" });

            //keep previous data from CustomersCourses Table before dropping
            Sql("INSERT INTO CustomersCourses (CustomerId,CourseId) SELECT StudentId,CourseId FROM StudentsCourses");

            DropTable("dbo.StudentsCourses");
            CreateIndex("dbo.CustomersCourses", "CourseId");
            CreateIndex("dbo.CustomersCourses", "CustomerId");
            AddForeignKey("dbo.CustomersCourses", "CourseId", "dbo.Courses", "Id", cascadeDelete: true);
            AddForeignKey("dbo.CustomersCourses", "CustomerId", "dbo.Customers", "Id", cascadeDelete: true);
            RenameTable(name: "dbo.Students", newName: "Customers");
        }
    }
}
