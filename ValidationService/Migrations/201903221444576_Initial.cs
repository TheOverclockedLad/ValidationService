namespace ValidationService.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            Sql(@"CREATE PROCEDURE CountCreditCardsSP
                @expiryDate DATETIME
                @number bigint
                @count tinyint OUTPUT
                AS
                BEGIN
                    SELECT @count = COUNT(Number) FROM CreditCards WHERE Number = @number AND @expiryDate = @expiryDate
                END");

            CreateTable(
                "dbo.CreditCards",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Number = c.Long(nullable: false),
                        ExpiryDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Number, unique: true);
            
        }
        
        public override void Down()
        {
            DropIndex("dbo.CreditCards", new[] { "Number" });
            DropTable("dbo.CreditCards");

            Sql(@"DROP PROCEDURE CountCreditCardsSP");
        }
    }
}