namespace Oleg.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Answers : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.UserComments", "Answer", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.UserComments", "Answer");
        }
    }
}
