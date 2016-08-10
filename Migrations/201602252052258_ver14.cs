namespace WebApplication1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ver14 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.News",
                c => new
                    {
                        siteoneelemId = c.Int(nullable: false),
                        Title = c.String(),
                        Text = c.String(),
                        Anonce = c.String(),
                    })
                .PrimaryKey(t => t.siteoneelemId)
                .ForeignKey("dbo.siteOneElementes", t => t.siteoneelemId)
                .Index(t => t.siteoneelemId);
            
            CreateTable(
                "dbo.Services",
                c => new
                    {
                        siteoneelemId = c.Int(nullable: false),
                        Name = c.String(),
                        Description = c.String(),
                        Price = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.siteoneelemId)
                .ForeignKey("dbo.siteOneElementes", t => t.siteoneelemId)
                .Index(t => t.siteoneelemId);
            
            DropColumn("dbo.siteOneElementes", "Title");
            DropColumn("dbo.siteOneElementes", "Text");
            DropColumn("dbo.siteOneElementes", "Anonce");
            DropColumn("dbo.siteOneElementes", "Name");
            DropColumn("dbo.siteOneElementes", "Description");
            DropColumn("dbo.siteOneElementes", "Price");
            DropColumn("dbo.siteOneElementes", "Discriminator");
        }
        
        public override void Down()
        {
            AddColumn("dbo.siteOneElementes", "Discriminator", c => c.String(nullable: false, maxLength: 128));
            AddColumn("dbo.siteOneElementes", "Price", c => c.Int());
            AddColumn("dbo.siteOneElementes", "Description", c => c.String());
            AddColumn("dbo.siteOneElementes", "Name", c => c.String());
            AddColumn("dbo.siteOneElementes", "Anonce", c => c.String());
            AddColumn("dbo.siteOneElementes", "Text", c => c.String());
            AddColumn("dbo.siteOneElementes", "Title", c => c.String());
            DropForeignKey("dbo.Services", "siteoneelemId", "dbo.siteOneElementes");
            DropForeignKey("dbo.News", "siteoneelemId", "dbo.siteOneElementes");
            DropIndex("dbo.Services", new[] { "siteoneelemId" });
            DropIndex("dbo.News", new[] { "siteoneelemId" });
            DropTable("dbo.Services");
            DropTable("dbo.News");
        }
    }
}
