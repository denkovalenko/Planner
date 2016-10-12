namespace Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PlanRemark : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.PlanRemarks",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Date = c.DateTime(nullable: false),
                        Remark = c.String(),
                        Signature = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.AspNetUsers", "PlanRemarkId", c => c.String(maxLength: 128));
            CreateIndex("dbo.AspNetUsers", "PlanRemarkId");
            AddForeignKey("dbo.AspNetUsers", "PlanRemarkId", "dbo.PlanRemarks", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUsers", "PlanRemarkId", "dbo.PlanRemarks");
            DropIndex("dbo.AspNetUsers", new[] { "PlanRemarkId" });
            DropColumn("dbo.AspNetUsers", "PlanRemarkId");
            DropTable("dbo.PlanRemarks");
        }
    }
}
