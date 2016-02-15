namespace QuestionnaireMonthly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatedatabase : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Answers", "Question_ID", "dbo.Questions");
            DropForeignKey("dbo.Answers", "User_ID", "dbo.Users");
            DropIndex("dbo.Answers", new[] { "Question_ID" });
            DropIndex("dbo.Answers", new[] { "User_ID" });
            DropColumn("dbo.Answers", "QuestionID");
            DropColumn("dbo.Answers", "UserID");
            RenameColumn(table: "dbo.Answers", name: "Question_ID", newName: "QuestionID");
            RenameColumn(table: "dbo.Answers", name: "User_ID", newName: "UserID");
            AlterColumn("dbo.Answers", "QuestionID", c => c.Long(nullable: false));
            AlterColumn("dbo.Answers", "UserID", c => c.Long(nullable: false));
            AlterColumn("dbo.Answers", "QuestionID", c => c.Long(nullable: false));
            AlterColumn("dbo.Answers", "UserID", c => c.Long(nullable: false));
            CreateIndex("dbo.Answers", "QuestionID");
            CreateIndex("dbo.Answers", "UserID");
            AddForeignKey("dbo.Answers", "QuestionID", "dbo.Questions", "ID", cascadeDelete: true);
            AddForeignKey("dbo.Answers", "UserID", "dbo.Users", "ID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Answers", "UserID", "dbo.Users");
            DropForeignKey("dbo.Answers", "QuestionID", "dbo.Questions");
            DropIndex("dbo.Answers", new[] { "UserID" });
            DropIndex("dbo.Answers", new[] { "QuestionID" });
            AlterColumn("dbo.Answers", "UserID", c => c.Long());
            AlterColumn("dbo.Answers", "QuestionID", c => c.Long());
            AlterColumn("dbo.Answers", "UserID", c => c.Int(nullable: false));
            AlterColumn("dbo.Answers", "QuestionID", c => c.Int(nullable: false));
            RenameColumn(table: "dbo.Answers", name: "UserID", newName: "User_ID");
            RenameColumn(table: "dbo.Answers", name: "QuestionID", newName: "Question_ID");
            AddColumn("dbo.Answers", "UserID", c => c.Int(nullable: false));
            AddColumn("dbo.Answers", "QuestionID", c => c.Int(nullable: false));
            CreateIndex("dbo.Answers", "User_ID");
            CreateIndex("dbo.Answers", "Question_ID");
            AddForeignKey("dbo.Answers", "User_ID", "dbo.Users", "ID");
            AddForeignKey("dbo.Answers", "Question_ID", "dbo.Questions", "ID");
        }
    }
}
