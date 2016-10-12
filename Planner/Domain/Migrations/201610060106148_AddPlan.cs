namespace Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddPlan : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.PlanAllocations",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        WorkTypes = c.String(),
                        PlannedVolume = c.Int(nullable: false),
                        ActualVolume = c.Int(nullable: false),
                        PlanTrainingJobId = c.String(maxLength: 128),
                        PlanManagmentId = c.String(maxLength: 128),
                        PlanMethodicalWorkId = c.String(maxLength: 128),
                        PlanScientificWorkId = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.PlanManagments", t => t.PlanManagmentId)
                .ForeignKey("dbo.PlanMethodicalWorks", t => t.PlanMethodicalWorkId)
                .ForeignKey("dbo.PlanScientificWorks", t => t.PlanScientificWorkId)
                .ForeignKey("dbo.PlanTrainingJobs", t => t.PlanTrainingJobId)
                .Index(t => t.PlanTrainingJobId)
                .Index(t => t.PlanManagmentId)
                .Index(t => t.PlanMethodicalWorkId)
                .Index(t => t.PlanScientificWorkId);
            
            CreateTable(
                "dbo.PlanManagments",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        OrderNumber = c.Int(nullable: false),
                        Content = c.String(),
                        Result = c.String(),
                        DurationTime = c.Int(nullable: false),
                        PlannedVolume = c.Int(nullable: false),
                        ActualVolume = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.PlanMethodicalWorks",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        OrderNumber = c.Int(nullable: false),
                        Content = c.String(),
                        Result = c.String(),
                        DurationTime = c.Int(nullable: false),
                        PlannedVolume = c.Int(nullable: false),
                        ActualVolume = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.PlanScientificWorks",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        OrderNumber = c.Int(nullable: false),
                        Content = c.String(),
                        Result = c.String(),
                        DurationTime = c.Int(nullable: false),
                        PlannedVolume = c.Int(nullable: false),
                        ActualVolume = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.PlanTrainingJobs",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        EducationForm = c.String(),
                        OrderNumber = c.Int(nullable: false),
                        Subject = c.String(),
                        DSD = c.String(),
                        Course = c.Int(nullable: false),
                        CountStudent = c.Int(nullable: false),
                        GroupCode = c.String(),
                        PlannedLectures = c.Int(nullable: false),
                        DoneLectures = c.Int(nullable: false),
                        PlannedPract = c.Int(nullable: false),
                        DonePract = c.Int(nullable: false),
                        PlannedLaboratory = c.Int(nullable: false),
                        DoneLaboratory = c.Int(nullable: false),
                        PlannedSeminar = c.Int(nullable: false),
                        DoneSeminar = c.Int(nullable: false),
                        PlannedIndividual = c.Int(nullable: false),
                        DoneIndividual = c.Int(nullable: false),
                        PlannedConsultation = c.Int(nullable: false),
                        DoneConsultation = c.Int(nullable: false),
                        PlannedExamConsultation = c.Int(nullable: false),
                        DoneExamConsultation = c.Int(nullable: false),
                        PlannedCheckControl = c.Int(nullable: false),
                        DoneCheckControl = c.Int(nullable: false),
                        PlannedCheckLectureControl = c.Int(nullable: false),
                        DoneCheckLectureControl = c.Int(nullable: false),
                        PlannedEAT = c.Int(nullable: false),
                        DoneEAT = c.Int(nullable: false),
                        PlannedCGS = c.Int(nullable: false),
                        DoneCGS = c.Int(nullable: false),
                        PlannedCoursework = c.Int(nullable: false),
                        DoneCoursework = c.Int(nullable: false),
                        PlannedOffsetting = c.Int(nullable: false),
                        DoneOffsetting = c.Int(nullable: false),
                        PlannedSemestrExam = c.Int(nullable: false),
                        DoneSemestrExam = c.Int(nullable: false),
                        PlannedTrainingPract = c.Int(nullable: false),
                        DoneTrainingPract = c.Int(nullable: false),
                        PlannedStateExam = c.Int(nullable: false),
                        DoneStateExam = c.Int(nullable: false),
                        PlannedDiploma = c.Int(nullable: false),
                        DoneDiploma = c.Int(nullable: false),
                        PlannedPostgraduates = c.Int(nullable: false),
                        DonePostgraduates = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.AspNetUsers", "PlanAllocationId", c => c.String(maxLength: 128));
            CreateIndex("dbo.AspNetUsers", "PlanAllocationId");
            AddForeignKey("dbo.AspNetUsers", "PlanAllocationId", "dbo.PlanAllocations", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUsers", "PlanAllocationId", "dbo.PlanAllocations");
            DropForeignKey("dbo.PlanAllocations", "PlanTrainingJobId", "dbo.PlanTrainingJobs");
            DropForeignKey("dbo.PlanAllocations", "PlanScientificWorkId", "dbo.PlanScientificWorks");
            DropForeignKey("dbo.PlanAllocations", "PlanMethodicalWorkId", "dbo.PlanMethodicalWorks");
            DropForeignKey("dbo.PlanAllocations", "PlanManagmentId", "dbo.PlanManagments");
            DropIndex("dbo.PlanAllocations", new[] { "PlanScientificWorkId" });
            DropIndex("dbo.PlanAllocations", new[] { "PlanMethodicalWorkId" });
            DropIndex("dbo.PlanAllocations", new[] { "PlanManagmentId" });
            DropIndex("dbo.PlanAllocations", new[] { "PlanTrainingJobId" });
            DropIndex("dbo.AspNetUsers", new[] { "PlanAllocationId" });
            DropColumn("dbo.AspNetUsers", "PlanAllocationId");
            DropTable("dbo.PlanTrainingJobs");
            DropTable("dbo.PlanScientificWorks");
            DropTable("dbo.PlanMethodicalWorks");
            DropTable("dbo.PlanManagments");
            DropTable("dbo.PlanAllocations");
        }
    }
}
