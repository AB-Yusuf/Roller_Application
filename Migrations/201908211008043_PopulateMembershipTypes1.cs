namespace Roller.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateMembershipTypes1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Customers", "MembershipName_Id", "dbo.MembershipTypes");
            DropIndex("dbo.Customers", new[] { "MembershipName_Id" });
            DropColumn("dbo.Customers", "MembershipName_Id");
            DropColumn("dbo.MembershipTypes", "Name");
        }
        
        public override void Down()
        {
            AddColumn("dbo.MembershipTypes", "Name", c => c.String());
            AddColumn("dbo.Customers", "MembershipName_Id", c => c.Byte());
            CreateIndex("dbo.Customers", "MembershipName_Id");
            AddForeignKey("dbo.Customers", "MembershipName_Id", "dbo.MembershipTypes", "Id");
        }
    }
}