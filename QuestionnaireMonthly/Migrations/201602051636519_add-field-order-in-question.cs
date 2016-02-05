namespace QuestionnaireMonthly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addfieldorderinquestion : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Questions", "Order", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Questions", "Order");
        }
    }
}
