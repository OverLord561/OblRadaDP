namespace Oleg.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UserComments : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.UserComments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        LeadershipId = c.Int(nullable: false),
                        UserNickName = c.String(),
                        LabelText = c.String(nullable: false),
                        E_mail = c.String(nullable: false),
                        Name = c.String(nullable: false),
                        Date = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.UserComments");
        }
    }
}
