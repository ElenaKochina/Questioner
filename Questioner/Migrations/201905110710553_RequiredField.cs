namespace Questioner.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RequiredField : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Questions", "Required", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Questions", "Required");
        }
    }
}
