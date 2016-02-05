namespace QuestionnaireMonthly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatetypetofieldorderinquestion : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Questions", "Order", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Questions", "Order", c => c.String());
        }
    }
}
