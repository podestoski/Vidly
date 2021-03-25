namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddNumberAvailableToMovie : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Rentals", new[] { "customer_Id" });
            DropIndex("dbo.Rentals", new[] { "movie_Id" });
            AddColumn("dbo.Movies", "NumberAvailable", c => c.Int(nullable: false));
            CreateIndex("dbo.Rentals", "Customer_Id");
            CreateIndex("dbo.Rentals", "Movie_Id");

            Sql("Update Movies set NumberAvailable = NumberInStock");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Rentals", new[] { "Movie_Id" });
            DropIndex("dbo.Rentals", new[] { "Customer_Id" });
            DropColumn("dbo.Movies", "NumberAvailable");
            CreateIndex("dbo.Rentals", "movie_Id");
            CreateIndex("dbo.Rentals", "customer_Id");
        }
    }
}
