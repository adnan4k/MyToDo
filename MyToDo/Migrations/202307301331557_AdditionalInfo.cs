namespace MyToDo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AdditionalInfo : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ToDoes", "Title", c => c.String());
            AddColumn("dbo.ToDoes", "Status", c => c.Boolean(nullable: false));
            AddColumn("dbo.ToDoes", "DueDate", c => c.DateTime(nullable: false));
            DropColumn("dbo.ToDoes", "IsDone");
        }
        
        public override void Down()
        {
            AddColumn("dbo.ToDoes", "IsDone", c => c.Boolean(nullable: false));
            DropColumn("dbo.ToDoes", "DueDate");
            DropColumn("dbo.ToDoes", "Status");
            DropColumn("dbo.ToDoes", "Title");
        }
    }
}
