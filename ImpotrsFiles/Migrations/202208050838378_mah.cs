namespace ImpotrsFiles.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mah : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Employeds",
                c => new
                    {
                        Emp_Id = c.Int(nullable: false, identity: true),
                        Emp_name = c.Int(nullable: false),
                        Emp_Age = c.Int(nullable: false),
                        Emp_Salary = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Emp_Id);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        User_Id = c.Int(nullable: false, identity: true),
                        User_name = c.String(),
                        User_Age = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.User_Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Users");
            DropTable("dbo.Employeds");
        }
    }
}
