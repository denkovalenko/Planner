namespace Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PlanChange : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.PlanChanges",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Semester = c.Int(nullable: false),
                        TypesfJobs = c.String(),
                        Changes = c.String(),
                        PlannedVolume = c.Int(nullable: false),
                        ActualVolume = c.Int(nullable: false),
                        Base = c.String(),
                        Signature = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.AspNetUsers", "PlanChangeId", c => c.String(maxLength: 128));
            CreateIndex("dbo.AspNetUsers", "PlanChangeId");
            AddForeignKey("dbo.AspNetUsers", "PlanChangeId", "dbo.PlanChanges", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUsers", "PlanChangeId", "dbo.PlanChanges");
            DropIndex("dbo.AspNetUsers", new[] { "PlanChangeId" });
            DropColumn("dbo.AspNetUsers", "PlanChangeId");
            DropTable("dbo.PlanChanges");
        }
    }
}
