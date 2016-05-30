namespace Oleg.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Novelties",
                c => new
                    {
                        NoveltyId = c.Int(nullable: false, identity: true),
                        NoveltyTitle = c.String(nullable: false),
                        NoveltyContent = c.String(maxLength: 1000),
                        NoveltyDate = c.DateTime(nullable: false),
                        NoveltyPhoto = c.String(),
                    })
                .PrimaryKey(t => t.NoveltyId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Novelties");
        }
    }
}
