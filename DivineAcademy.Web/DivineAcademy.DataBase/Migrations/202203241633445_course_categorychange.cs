namespace DivineAcademy.DataBase.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class course_categorychange : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.CourseNames", "CourseCategory_ID", "dbo.CourseCategories");
            DropIndex("dbo.CourseNames", new[] { "CourseCategory_ID" });
            RenameColumn(table: "dbo.CourseNames", name: "CourseCategory_ID", newName: "CourseCategoryID");
            AddColumn("dbo.CourseNames", "ImageURL", c => c.String());
            AlterColumn("dbo.CourseNames", "CourseCategoryID", c => c.Int(nullable: false));
            CreateIndex("dbo.CourseNames", "CourseCategoryID");
            AddForeignKey("dbo.CourseNames", "CourseCategoryID", "dbo.CourseCategories", "ID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CourseNames", "CourseCategoryID", "dbo.CourseCategories");
            DropIndex("dbo.CourseNames", new[] { "CourseCategoryID" });
            AlterColumn("dbo.CourseNames", "CourseCategoryID", c => c.Int());
            DropColumn("dbo.CourseNames", "ImageURL");
            RenameColumn(table: "dbo.CourseNames", name: "CourseCategoryID", newName: "CourseCategory_ID");
            CreateIndex("dbo.CourseNames", "CourseCategory_ID");
            AddForeignKey("dbo.CourseNames", "CourseCategory_ID", "dbo.CourseCategories", "ID");
        }
    }
}
