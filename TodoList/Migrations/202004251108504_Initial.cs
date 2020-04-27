namespace TodoList.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Employees",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                        BirthDay = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Stories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        StoryPoints = c.Int(nullable: false),
                        Title = c.String(),
                        Description = c.String(),
                        CreateDate = c.DateTime(nullable: false),
                        EmployeeId = c.Int(nullable: false),
                        Employee_Id = c.Int(),
                        Employee_Id1 = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Employees", t => t.EmployeeId)
                .ForeignKey("dbo.Employees", t => t.Employee_Id)
                .ForeignKey("dbo.Employees", t => t.Employee_Id1)
                .Index(t => t.EmployeeId)
                .Index(t => t.Employee_Id)
                .Index(t => t.Employee_Id1);
            
            CreateTable(
                "dbo.StoryTasks",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Estimation = c.Int(nullable: false),
                        Title = c.String(),
                        Description = c.String(),
                        CreateDate = c.DateTime(nullable: false),
                        EmployeeId = c.Int(nullable: false),
                        StoryId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Employees", t => t.EmployeeId)
                .ForeignKey("dbo.Stories", t => t.StoryId)
                .Index(t => t.EmployeeId)
                .Index(t => t.StoryId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.StoryTasks", "StoryId", "dbo.Stories");
            DropForeignKey("dbo.StoryTasks", "EmployeeId", "dbo.Employees");
            DropForeignKey("dbo.Stories", "Employee_Id1", "dbo.Employees");
            DropForeignKey("dbo.Stories", "Employee_Id", "dbo.Employees");
            DropForeignKey("dbo.Stories", "EmployeeId", "dbo.Employees");
            DropIndex("dbo.StoryTasks", new[] { "StoryId" });
            DropIndex("dbo.StoryTasks", new[] { "EmployeeId" });
            DropIndex("dbo.Stories", new[] { "Employee_Id1" });
            DropIndex("dbo.Stories", new[] { "Employee_Id" });
            DropIndex("dbo.Stories", new[] { "EmployeeId" });
            DropTable("dbo.StoryTasks");
            DropTable("dbo.Stories");
            DropTable("dbo.Employees");
        }
    }
}
