namespace WebApplication1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class IntialMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ImageLinks",
                c => new
                    {
                        ImageLinkId = c.Int(nullable: false, identity: true),
                        Link = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.ImageLinkId);
            
            CreateTable(
                "dbo.News",
                c => new
                    {
                        NewsId = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Text = c.String(),
                        Annonce = c.String(),
                        ImageLinkId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.NewsId)
                .ForeignKey("dbo.ImageLinks", t => t.ImageLinkId, cascadeDelete: true)
                .Index(t => t.ImageLinkId);
            
            CreateTable(
                "dbo.ProjectCategories",
                c => new
                    {
                        ProjectCategoryId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.ProjectCategoryId);
            
            CreateTable(
                "dbo.Projects",
                c => new
                    {
                        ProjectId = c.Int(nullable: false, identity: true),
                        ProjectDescription = c.String(nullable: false),
                        Customer = c.String(nullable: false),
                        Price = c.Double(nullable: false),
                        Date = c.DateTime(nullable: false),
                        ImageLinkId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ProjectId)
                .ForeignKey("dbo.ImageLinks", t => t.ImageLinkId, cascadeDelete: true)
                .Index(t => t.ImageLinkId);
            
            CreateTable(
                "dbo.Services",
                c => new
                    {
                        ServiceId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Description = c.String(nullable: false),
                        Price = c.Double(nullable: false),
                        ImageLinkId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ServiceId)
                .ForeignKey("dbo.ImageLinks", t => t.ImageLinkId, cascadeDelete: true)
                .Index(t => t.ImageLinkId);
            
            CreateTable(
                "dbo.ProjectProjectCategories",
                c => new
                    {
                        Project_ProjectId = c.Int(nullable: false),
                        ProjectCategory_ProjectCategoryId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Project_ProjectId, t.ProjectCategory_ProjectCategoryId })
                .ForeignKey("dbo.Projects", t => t.Project_ProjectId, cascadeDelete: true)
                .ForeignKey("dbo.ProjectCategories", t => t.ProjectCategory_ProjectCategoryId, cascadeDelete: true)
                .Index(t => t.Project_ProjectId)
                .Index(t => t.ProjectCategory_ProjectCategoryId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Services", "ImageLinkId", "dbo.ImageLinks");
            DropForeignKey("dbo.ProjectProjectCategories", "ProjectCategory_ProjectCategoryId", "dbo.ProjectCategories");
            DropForeignKey("dbo.ProjectProjectCategories", "Project_ProjectId", "dbo.Projects");
            DropForeignKey("dbo.Projects", "ImageLinkId", "dbo.ImageLinks");
            DropForeignKey("dbo.News", "ImageLinkId", "dbo.ImageLinks");
            DropIndex("dbo.ProjectProjectCategories", new[] { "ProjectCategory_ProjectCategoryId" });
            DropIndex("dbo.ProjectProjectCategories", new[] { "Project_ProjectId" });
            DropIndex("dbo.Services", new[] { "ImageLinkId" });
            DropIndex("dbo.Projects", new[] { "ImageLinkId" });
            DropIndex("dbo.News", new[] { "ImageLinkId" });
            DropTable("dbo.ProjectProjectCategories");
            DropTable("dbo.Services");
            DropTable("dbo.Projects");
            DropTable("dbo.ProjectCategories");
            DropTable("dbo.News");
            DropTable("dbo.ImageLinks");
        }
    }
}
