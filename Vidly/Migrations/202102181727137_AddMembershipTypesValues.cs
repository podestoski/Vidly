namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddMembershipTypesValues : DbMigration
    {
        public override void Up()
        {
            Sql("Insert into MembershipTypes(Id,SignUpFee,DurationInMonths,DiscountRate,Name) values(1,0,0,0,'Pay as You Go')");
            Sql("Insert into MembershipTypes(Id,SignUpFee,DurationInMonths,DiscountRate,Name) values(2,15,1,5,'Monthly')");
            Sql("Insert into MembershipTypes(Id,SignUpFee,DurationInMonths,DiscountRate,Name) values(3,45,3,15,'Quarter')");
            Sql("Insert into MembershipTypes(Id,SignUpFee,DurationInMonths,DiscountRate,Name) values(4,180,12,50,'Anual')");
        }

        public override void Down()
        {
        }
    }
}
