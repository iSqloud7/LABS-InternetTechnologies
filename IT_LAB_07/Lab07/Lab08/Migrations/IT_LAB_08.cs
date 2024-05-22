namespace Lab08.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class IT_LAB_08 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Doctors",
                c => new
                    {
                        doctorID = c.Int(nullable: false, identity: true),
                        doctor_name = c.String(),
                        hospitalID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.doctorID)
                .ForeignKey("dbo.Hospitals", t => t.hospitalID, cascadeDelete: true)
                .Index(t => t.hospitalID);
            
            CreateTable(
                "dbo.Hospitals",
                c => new
                    {
                        hospitalID = c.Int(nullable: false, identity: true),
                        hospital_name = c.String(),
                        hospital_address = c.String(),
                        hospital_image = c.String(),
                    })
                .PrimaryKey(t => t.hospitalID);
            
            CreateTable(
                "dbo.Patients",
                c => new
                    {
                        patientID = c.Int(nullable: false, identity: true),
                        patient_name = c.String(nullable: false),
                        patient_code = c.Int(nullable: false),
                        patient_gender = c.String(),
                    })
                .PrimaryKey(t => t.patientID);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.PatientDoctors",
                c => new
                    {
                        Patient_patientID = c.Int(nullable: false),
                        Doctor_doctorID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Patient_patientID, t.Doctor_doctorID })
                .ForeignKey("dbo.Patients", t => t.Patient_patientID, cascadeDelete: true)
                .ForeignKey("dbo.Doctors", t => t.Doctor_doctorID, cascadeDelete: true)
                .Index(t => t.Patient_patientID)
                .Index(t => t.Doctor_doctorID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.PatientDoctors", "Doctor_doctorID", "dbo.Doctors");
            DropForeignKey("dbo.PatientDoctors", "Patient_patientID", "dbo.Patients");
            DropForeignKey("dbo.Doctors", "hospitalID", "dbo.Hospitals");
            DropIndex("dbo.PatientDoctors", new[] { "Doctor_doctorID" });
            DropIndex("dbo.PatientDoctors", new[] { "Patient_patientID" });
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.Doctors", new[] { "hospitalID" });
            DropTable("dbo.PatientDoctors");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.Patients");
            DropTable("dbo.Hospitals");
            DropTable("dbo.Doctors");
        }
    }
}
