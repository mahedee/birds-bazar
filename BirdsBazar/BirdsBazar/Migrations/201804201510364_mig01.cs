namespace BirdsBazar.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig01 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.PostInfoes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Details = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.PostInfoes");
        }
    }
}
