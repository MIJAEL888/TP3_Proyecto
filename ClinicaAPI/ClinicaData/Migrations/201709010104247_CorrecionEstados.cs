namespace ClinicaData.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CorrecionEstados : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Solicitud", "Estado", c => c.Int(nullable: false));
            AlterColumn("dbo.Cama", "Estado", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Cama", "Estado", c => c.String());
            DropColumn("dbo.Solicitud", "Estado");
        }
    }
}
