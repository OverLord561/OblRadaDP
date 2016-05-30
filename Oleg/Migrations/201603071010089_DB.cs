namespace Oleg.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DB : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Novelties", "NoveltyShortContent", c => c.String(maxLength: 1000));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Novelties", "NoveltyShortContent");
        }
    }
}
