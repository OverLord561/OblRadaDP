namespace Oleg.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Vacansions : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Jobs",
                c => new
                    {
                        JobId = c.Int(nullable: false, identity: true),
                        FactoryId = c.Int(nullable: false),
                        JobName = c.String(),
                        JobRequirements = c.String(),
                        JobDuties = c.String(),
                        JobConditions = c.String(),
                    })
                .PrimaryKey(t => t.JobId)
                .ForeignKey("dbo.Factories", t => t.FactoryId, cascadeDelete: true)
                .Index(t => t.FactoryId);
            
            CreateTable(
                "dbo.Factories",
                c => new
                    {
                        FactoryId = c.Int(nullable: false, identity: true),
                        FactoryName = c.String(),
                        FactoryAdress = c.String(),
                        FactoryTelephone = c.String(),
                        FacctoryBoss = c.String(),
                        FactoryType = c.String(),
                    })
                .PrimaryKey(t => t.FactoryId);
            
        }
        
        public override void Down()
        {
            DropIndex("dbo.Jobs", new[] { "FactoryId" });
            DropForeignKey("dbo.Jobs", "FactoryId", "dbo.Factories");
            DropTable("dbo.Factories");
            DropTable("dbo.Jobs");
        }
    }
}
