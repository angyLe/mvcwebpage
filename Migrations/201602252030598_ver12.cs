namespace WebApplication1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ver12 : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.news", newName: "siteOneElementes");
            DropForeignKey("dbo.news", "siteOneElemId", "dbo.siteOneElements");
            DropForeignKey("dbo.Services", "siteOneElem_siteOneElemId", "dbo.siteOneElements");
            DropIndex("dbo.siteOneElementes", new[] { "siteOneElemId" });
            DropIndex("dbo.Services", new[] { "siteOneElem_siteOneElemId" });
            DropPrimaryKey("dbo.siteOneElementes");
            AddColumn("dbo.siteOneElementes", "Name", c => c.String());
            AddColumn("dbo.siteOneElementes", "Description", c => c.String());
            AddColumn("dbo.siteOneElementes", "Price", c => c.Int());
            AddColumn("dbo.siteOneElementes", "Discriminator", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.siteOneElementes", "siteoneelemId", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.siteOneElementes", "siteoneelemId");
            AddForeignKey("dbo.imageLinks", "siteOneElemId", "dbo.siteOneElementes", "siteoneelemId", cascadeDelete: true);
            DropColumn("dbo.siteOneElementes", "newsId");
            //DropTable("dbo.siteOneElements");
            DropTable("dbo.Services");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Services",
                c => new
                    {
                        ServiceId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                        ServiceImage = c.String(),
                        Price = c.Int(nullable: false),
                        OneElemId = c.Int(nullable: false),
                        siteOneElem_siteOneElemId = c.Int(),
                    })
                .PrimaryKey(t => t.ServiceId);
            
            CreateTable(
                "dbo.siteOneElements",
                c => new
                    {
                        siteOneElemId = c.Int(nullable: false, identity: true),
                    })
                .PrimaryKey(t => t.siteOneElemId);
            
            AddColumn("dbo.siteOneElementes", "newsId", c => c.Int(nullable: false, identity: true));
            DropForeignKey("dbo.imageLinks", "siteOneElemId", "dbo.siteOneElementes");
            DropPrimaryKey("dbo.siteOneElementes");
            AlterColumn("dbo.siteOneElementes", "siteoneelemId", c => c.Int(nullable: false));
            DropColumn("dbo.siteOneElementes", "Discriminator");
            DropColumn("dbo.siteOneElementes", "Price");
            DropColumn("dbo.siteOneElementes", "Description");
            DropColumn("dbo.siteOneElementes", "Name");
            AddPrimaryKey("dbo.siteOneElementes", "newsId");
            CreateIndex("dbo.Services", "siteOneElem_siteOneElemId");
            CreateIndex("dbo.siteOneElementes", "siteOneElemId");
            AddForeignKey("dbo.Services", "siteOneElem_siteOneElemId", "dbo.siteOneElements", "siteOneElemId");
            AddForeignKey("dbo.news", "siteOneElemId", "dbo.siteOneElements", "siteOneElemId", cascadeDelete: true);
            RenameTable(name: "dbo.siteOneElementes", newName: "news");
        }
    }
}
