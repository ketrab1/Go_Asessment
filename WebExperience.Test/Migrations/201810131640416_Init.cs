namespace WebExperience.Test.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Assets",
                c => new
                    {
                        AssetId = c.Guid(nullable: false),
                        FileName = c.String(),
                        CreatedBy = c.String(),
                        Email = c.String(),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.AssetId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Assets");
        }
    }
}
