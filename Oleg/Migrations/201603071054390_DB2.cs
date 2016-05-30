namespace Oleg.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DB2 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Novelties", "NoveltyContent", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Novelties", "NoveltyContent", c => c.String(maxLength: 1000));
        }
    }
}
