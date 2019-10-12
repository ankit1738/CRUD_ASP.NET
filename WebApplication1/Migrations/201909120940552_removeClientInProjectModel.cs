namespace WebApplication1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class removeClientInProjectModel : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Projects", "client");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Projects", "client", c => c.String());
        }
    }
}
