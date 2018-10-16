namespace WebExperience.Test.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class relations : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Countries",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Assets", t => t.Id)
                .Index(t => t.Id);
            
            CreateTable(
                "dbo.MimeTypes",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Type = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Assets", t => t.Id)
                .Index(t => t.Id);
            
            DropColumn("dbo.Assets", "MimeType_Type");
            DropColumn("dbo.Assets", "Country_Name");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Assets", "Country_Name", c => c.String());
            AddColumn("dbo.Assets", "MimeType_Type", c => c.String());
            DropForeignKey("dbo.MimeTypes", "Id", "dbo.Assets");
            DropForeignKey("dbo.Countries", "Id", "dbo.Assets");
            DropIndex("dbo.MimeTypes", new[] { "Id" });
            DropIndex("dbo.Countries", new[] { "Id" });
            DropTable("dbo.MimeTypes");
            DropTable("dbo.Countries");
        }
    }
}
