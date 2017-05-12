namespace TaskManager.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class delstatus : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Tasks", "Status", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Tasks", "Status", c => c.Int(nullable: false));
        }
    }
}
