namespace ClinicaData.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddUsuarioRol : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.RolUsuario",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nombre = c.String(),
                        Codigo = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Usuario", "NombreUsuario", c => c.String());
            AddColumn("dbo.Usuario", "CorreoUsuario", c => c.String());
            AddColumn("dbo.Usuario", "IdRolUsuario", c => c.Int(nullable: true));
            AddColumn("dbo.Usuario", "IdPersona", c => c.Int(nullable: true));
            CreateIndex("dbo.Usuario", "IdRolUsuario");
            CreateIndex("dbo.Usuario", "IdPersona");
            AddForeignKey("dbo.Usuario", "IdPersona", "dbo.Persona", "Id", cascadeDelete: false);
            AddForeignKey("dbo.Usuario", "IdRolUsuario", "dbo.RolUsuario", "Id", cascadeDelete: false);
            DropColumn("dbo.Usuario", "Nombre");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Usuario", "Nombre", c => c.String());
            DropForeignKey("dbo.Usuario", "IdRolUsuario", "dbo.RolUsuario");
            DropForeignKey("dbo.Usuario", "IdPersona", "dbo.Persona");
            DropIndex("dbo.Usuario", new[] { "IdPersona" });
            DropIndex("dbo.Usuario", new[] { "IdRolUsuario" });
            DropColumn("dbo.Usuario", "IdPersona");
            DropColumn("dbo.Usuario", "IdRolUsuario");
            DropColumn("dbo.Usuario", "CorreoUsuario");
            DropColumn("dbo.Usuario", "NombreUsuario");
            DropTable("dbo.RolUsuario");
        }
    }
}
