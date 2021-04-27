namespace WindowsFormsApplication1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fsdfsdf : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Clients",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        surname = c.String(),
                        name = c.String(),
                        patr = c.String(),
                        date_of_birth = c.DateTime(nullable: false),
                        p_series = c.Int(nullable: false),
                        p_number = c.Int(nullable: false),
                        phone = c.String(),
                        userId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        dateOfArriving = c.DateTime(nullable: false),
                        dateOfLeaving = c.DateTime(nullable: false),
                        clientId = c.Int(nullable: false),
                        roomId = c.Int(nullable: false),
                        serviceId = c.Int(nullable: false),
                        totalPrice = c.Int(nullable: false),
                        isPaid = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.Positions",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        name = c.String(),
                        salary = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.Rooms",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        category = c.String(),
                        price = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.Services",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        name = c.String(),
                        price = c.Int(nullable: false),
                        description = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.Staffs",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        surname = c.String(),
                        name = c.String(),
                        patr = c.String(),
                        date_of_birth = c.DateTime(nullable: false),
                        p_series = c.Int(nullable: false),
                        p_number = c.Int(nullable: false),
                        phone = c.String(),
                        positionId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Login = c.String(),
                        Password = c.String(),
                        Email = c.String(),
                        Role = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
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
