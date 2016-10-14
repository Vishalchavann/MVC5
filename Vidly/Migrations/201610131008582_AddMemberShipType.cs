namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddMemberShipType : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.MemberShipTypes",
                c => new
                    {
                        ID = c.Byte(nullable: false),
                        SignUpFees = c.Short(nullable: false),
                        DurationInMonths = c.Byte(nullable: false),
                        DiscountRate = c.Byte(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            AddColumn("dbo.Customers", "MemberShipTypeID", c => c.Byte(nullable: false));
            CreateIndex("dbo.Customers", "MemberShipTypeID");
            AddForeignKey("dbo.Customers", "MemberShipTypeID", "dbo.MemberShipTypes", "ID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Customers", "MemberShipTypeID", "dbo.MemberShipTypes");
            DropIndex("dbo.Customers", new[] { "MemberShipTypeID" });
            DropColumn("dbo.Customers", "MemberShipTypeID");
            DropTable("dbo.MemberShipTypes");
        }
    }
}
