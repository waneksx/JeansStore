namespace DomainModel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _220716_Size_quantity : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Sizes", "Quantity_QuantityId", "dbo.JeansQuantities");
            DropIndex("dbo.Sizes", new[] { "Quantity_QuantityId" });
            AddColumn("dbo.Sizes", "Quantity", c => c.Int(nullable: false));
            DropColumn("dbo.Sizes", "Quantity_QuantityId");
            DropTable("dbo.JeansQuantities");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.JeansQuantities",
                c => new
                    {
                        QuantityId = c.Int(nullable: false, identity: true),
                        Value = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.QuantityId);
            
            AddColumn("dbo.Sizes", "Quantity_QuantityId", c => c.Int(nullable: false));
            DropColumn("dbo.Sizes", "Quantity");
            CreateIndex("dbo.Sizes", "Quantity_QuantityId");
            AddForeignKey("dbo.Sizes", "Quantity_QuantityId", "dbo.JeansQuantities", "QuantityId", cascadeDelete: true);
        }
    }
}
