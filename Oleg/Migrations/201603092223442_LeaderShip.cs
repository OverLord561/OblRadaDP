namespace Oleg.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class LeaderShip : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Leaderships",
                c => new
                    {
                        LeadershipId = c.Int(nullable: false, identity: true),
                        LeadershipName = c.String(),
                        LeadershipPost = c.String(),
                        LeadershipBiography = c.String(),
                        LeadershipPhoto = c.String(),
                        LeadershipDeclaration = c.String(),
                    })
                .PrimaryKey(t => t.LeadershipId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Leaderships");
        }
    }
}
