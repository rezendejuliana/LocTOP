namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateMembershipType : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO MemberShipTypes(Id,Name, SignUpFee,DurationInMonths,DiscountRate) VALUES (1,Initial Plan,0,0,0)");
            Sql("INSERT INTO MemberShipTypes(Id,Name, SignUpFee,DurationInMonths,DiscountRate) VALUES (2,Secondary Plan,30,1,10)");
            Sql("INSERT INTO MemberShipTypes(Id,Name ,SignUpFee,DurationInMonths,DiscountRate) VALUES (3,Third Plan,90,3,15)");
            Sql("INSERT INTO MemberShipTypes(Id,Name ,SignUpFee,DurationInMonths,DiscountRate) VALUES (4,Top Plan,300,12,20)");
        }
        
        public override void Down()
        {
        }
    }
}
