namespace DivineAcademy.DataBase.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Divine : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.AspNetUsers", "FullName");
            DropColumn("dbo.AspNetUsers", "Address");
            DropColumn("dbo.AspNetUsers", "DateCeated");
            DropColumn("dbo.AspNetUsers", "DateModified");
        }
        
        public override void Down()
        {
            AddColumn("dbo.AspNetUsers", "DateModified", c => c.String());
            AddColumn("dbo.AspNetUsers", "DateCeated", c => c.String());
            AddColumn("dbo.AspNetUsers", "Address", c => c.String(nullable: false));
            AddColumn("dbo.AspNetUsers", "FullName", c => c.String(nullable: false));
        }
    }
}
