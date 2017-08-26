namespace IC_Assignment.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RenameProgrammeModelToCourseModel : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Programmes", newName: "Courses");
            RenameColumn(table: "dbo.Customers", name: "ProgrammeId", newName: "CourseId");
            RenameIndex(table: "dbo.Customers", name: "IX_ProgrammeId", newName: "IX_CourseId");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.Customers", name: "IX_CourseId", newName: "IX_ProgrammeId");
            RenameColumn(table: "dbo.Customers", name: "CourseId", newName: "ProgrammeId");
            RenameTable(name: "dbo.Courses", newName: "Programmes");
        }
    }
}
