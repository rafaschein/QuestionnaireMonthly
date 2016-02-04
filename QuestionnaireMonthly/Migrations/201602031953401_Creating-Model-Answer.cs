namespace QuestionnaireMonthly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreatingModelAnswer : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Answers",
                c => new
                    {
                        ID = c.Long(nullable: false, identity: true),
                        QuestionID = c.Int(nullable: false),
                        UserID = c.Int(nullable: false),
                        Response = c.Boolean(nullable: false),
                        Date = c.DateTime(nullable: false),
                        Question_ID = c.Long(),
                        User_ID = c.Long(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Questions", t => t.Question_ID)
                .ForeignKey("dbo.Users", t => t.User_ID)
                .Index(t => t.Question_ID)
                .Index(t => t.User_ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Answers", "User_ID", "dbo.Users");
            DropForeignKey("dbo.Answers", "Question_ID", "dbo.Questions");
            DropIndex("dbo.Answers", new[] { "User_ID" });
            DropIndex("dbo.Answers", new[] { "Question_ID" });
            DropTable("dbo.Answers");
        }
    }
}
