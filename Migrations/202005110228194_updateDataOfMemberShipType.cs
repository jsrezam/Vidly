namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateDataOfMemberShipType : DbMigration
    {
        public override void Up()
        {
            Sql("UPDATE MemberShipTypes SET NAME ='Pay as You Go' WHERE ID = 1");
            Sql("UPDATE MemberShipTypes SET NAME ='Monthly' WHERE ID = 2");
            Sql("UPDATE MemberShipTypes SET NAME ='Quarterly' WHERE ID = 3");
            Sql("UPDATE MemberShipTypes SET NAME ='Annual' WHERE ID = 4");
        }
        
        public override void Down()
        {
        }
    }
}
