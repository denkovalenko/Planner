namespace Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PlanConclusion : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.PlanConclusions",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Semester = c.Int(nullable: false),
                        Content = c.String(),
                        Signature = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.AspNetUsers", "PlanConclusionId", c => c.String(maxLength: 128));
            CreateIndex("dbo.AspNetUsers", "PlanConclusionId");
            AddForeignKey("dbo.AspNetUsers", "PlanConclusionId", "dbo.PlanConclusions", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUsers", "PlanConclusionId", "dbo.PlanConclusions");
            DropIndex("dbo.AspNetUsers", new[] { "PlanConclusionId" });
            DropColumn("dbo.AspNetUsers", "PlanConclusionId");
            DropTable("dbo.PlanConclusions");
        }
    }
}
