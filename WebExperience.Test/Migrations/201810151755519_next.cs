namespace WebExperience.Test.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class next : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Assets", "MimeType_Type", c => c.String());
            AddColumn("dbo.Assets", "Country_Name", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Assets", "Country_Name");
            DropColumn("dbo.Assets", "MimeType_Type");
        }
    }
}
