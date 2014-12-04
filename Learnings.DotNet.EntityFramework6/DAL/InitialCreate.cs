using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;

namespace Learnings.DotNet.EntityFramework6.DAL
{
    public partial class InitialCreate : DbMigration
    {
        private readonly string tableCourseName = "dbo.Course";
        private readonly string tableEnrollmentName = "dbo.Enrollment";
        private readonly string tableStudentName = "dbo.Student";

        public override void Up()
        {
            CreateTable(tableCourseName,
                c => new
                {
                    CourseId = c.Int(nullable: false),
                    Title = c.String(),
                    Credits = c.Int(nullable: false)
                })
                .PrimaryKey(t => t.CourseId);

            CreateTable(tableEnrollmentName,
                c => new
                {
                    EnrollmentId = c.Int(nullable: false, identity: true),
                    CourseId = c.Int(nullable: false),
                    StudentId = c.Int(nullable: false)
                })
                .PrimaryKey(t => t.EnrollmentId)
                .ForeignKey(tableCourseName, t => t.CourseId, cascadeDelete: true)
                .ForeignKey(tableStudentName, t => t.StudentId, cascadeDelete: true)
                .Index(t => t.CourseId)
                .Index(t => t.StudentId);

            CreateTable(tableStudentName,
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    LastName = c.String(),
                    FirstMidName = c.String(),
                    EnrollmentDate = c.DateTime(nullable: false)
                })
                .PrimaryKey(t => t.Id);
        }

        public override void Down()
        {
            DropForeignKey(tableEnrollmentName, "StudentId", tableStudentName);
            DropForeignKey(tableEnrollmentName, "CourseId", tableCourseName);

            DropIndex(tableEnrollmentName, new[] { "StudentId" });
            DropIndex(tableEnrollmentName, new[] { "CourseId" });

            DropTable(tableStudentName);
            DropTable(tableEnrollmentName);
            DropTable(tableCourseName);
        }
    }
}