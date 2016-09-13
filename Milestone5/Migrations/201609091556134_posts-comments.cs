namespace Milestone5.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class postscomments : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Comments",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        PostID = c.Int(nullable: false),
                        Title = c.String(nullable: false, maxLength: 50),
                        AuthorName = c.String(maxLength: 50),
                        AuthorWebsite = c.String(nullable: false),
                        PublishDate = c.DateTime(nullable: false),
                        Text = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Posts", t => t.PostID, cascadeDelete: true)
                .Index(t => t.PostID);
            
            CreateTable(
                "dbo.Posts",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false, maxLength: 50),
                        AuthorName = c.String(nullable: false, maxLength: 50),
                        AuthorWebsite = c.String(nullable: false),
                        PublishDate = c.DateTime(nullable: false),
                        Text = c.String(nullable: false),
                        ImageUrl = c.String(),
                        VideoUrl = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Comments", "PostID", "dbo.Posts");
            DropIndex("dbo.Comments", new[] { "PostID" });
            DropTable("dbo.Posts");
            DropTable("dbo.Comments");
        }
    }
}
