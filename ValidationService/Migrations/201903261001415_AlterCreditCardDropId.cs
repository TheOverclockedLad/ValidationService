namespace ValidationService.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class AlterCreditCardDropId : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.CreditCards", new[] { "Number" });
            DropPrimaryKey("dbo.CreditCards");
            AddPrimaryKey("dbo.CreditCards", new[] { "Number", "ExpiryDate" });
            DropColumn("dbo.CreditCards", "Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.CreditCards", "Id", c => c.Int(nullable: false, identity: true));
            DropPrimaryKey("dbo.CreditCards");
            AddPrimaryKey("dbo.CreditCards", "Id");
            CreateIndex("dbo.CreditCards", "Number", unique: true);
        }
    }
}
