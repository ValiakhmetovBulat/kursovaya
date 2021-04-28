namespace WindowsFormsApplication1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fsdfsdf : DbMigration
    {
        public override void Up()
        {
            
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Users");
            DropTable("dbo.Staffs");
            DropTable("dbo.Services");
            DropTable("dbo.Rooms");
            DropTable("dbo.Positions");
            DropTable("dbo.Orders");
            DropTable("dbo.Clients");
        }
    }
}
