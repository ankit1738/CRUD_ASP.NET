namespace WebApplication1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addClientInProjectModel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Projects", "client", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Projects", "client");
        }
    }
}
