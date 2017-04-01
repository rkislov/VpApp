namespace VpApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Activs",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        CabNumber = c.String(nullable: false, maxLength: 50),
                        DepartmentId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Departments", t => t.DepartmentId, cascadeDelete: true)
                .Index(t => t.DepartmentId);
            
            CreateTable(
                "dbo.Departments",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Positions",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(nullable: false, maxLength: 50),
                        Colichestvo = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Roles",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Telefons",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Tel = c.String(),
                        UserId = c.Guid(),
                        User_Id = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.User_Id)
                .ForeignKey("dbo.Users", t => t.UserId)
                .Index(t => t.UserId)
                .Index(t => t.User_Id);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(nullable: false, maxLength: 50),
                        Login = c.String(nullable: false, maxLength: 50),
                        Password = c.String(nullable: false, maxLength: 50),
                        PositionId = c.Guid(),
                        DepartmentId = c.Guid(),
                        RoleId = c.Guid(nullable: false),
                        Telefon_Id = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Departments", t => t.DepartmentId)
                .ForeignKey("dbo.Positions", t => t.PositionId)
                .ForeignKey("dbo.Roles", t => t.RoleId, cascadeDelete: true)
                .ForeignKey("dbo.Telefons", t => t.Telefon_Id)
                .Index(t => t.PositionId)
                .Index(t => t.DepartmentId)
                .Index(t => t.RoleId)
                .Index(t => t.Telefon_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Telefons", "UserId", "dbo.Users");
            DropForeignKey("dbo.Telefons", "User_Id", "dbo.Users");
            DropForeignKey("dbo.Users", "Telefon_Id", "dbo.Telefons");
            DropForeignKey("dbo.Users", "RoleId", "dbo.Roles");
            DropForeignKey("dbo.Users", "PositionId", "dbo.Positions");
            DropForeignKey("dbo.Users", "DepartmentId", "dbo.Departments");
            DropForeignKey("dbo.Activs", "DepartmentId", "dbo.Departments");
            DropIndex("dbo.Users", new[] { "Telefon_Id" });
            DropIndex("dbo.Users", new[] { "RoleId" });
            DropIndex("dbo.Users", new[] { "DepartmentId" });
            DropIndex("dbo.Users", new[] { "PositionId" });
            DropIndex("dbo.Telefons", new[] { "User_Id" });
            DropIndex("dbo.Telefons", new[] { "UserId" });
            DropIndex("dbo.Activs", new[] { "DepartmentId" });
            DropTable("dbo.Users");
            DropTable("dbo.Telefons");
            DropTable("dbo.Roles");
            DropTable("dbo.Positions");
            DropTable("dbo.Departments");
            DropTable("dbo.Activs");
        }
    }
}
