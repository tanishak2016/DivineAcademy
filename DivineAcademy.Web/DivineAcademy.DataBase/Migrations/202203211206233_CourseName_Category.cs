namespace DivineAcademy.DataBase.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CourseName_Category : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CourseCategories",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.CourseNames",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Name = c.String(),
                        Description = c.String(),
                        CourseCategory_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.CourseCategories", t => t.CourseCategory_ID)
                .Index(t => t.CourseCategory_ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CourseNames", "CourseCategory_ID", "dbo.CourseCategories");
            DropIndex("dbo.CourseNames", new[] { "CourseCategory_ID" });
            DropTable("dbo.CourseNames");
            DropTable("dbo.CourseCategories");
        }
    }
}
