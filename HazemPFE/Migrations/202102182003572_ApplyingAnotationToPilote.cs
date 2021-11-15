namespace HazemPFE.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class ApplyingAnotationToPilote : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Pilotes", "Nom", c => c.String(nullable: false, maxLength: 255));
            AlterColumn("dbo.Pilotes", "Prenom", c => c.String(nullable: false, maxLength: 255));
            AlterColumn("dbo.Pilotes", "Indicatif_Radio", c => c.String(nullable: false, maxLength: 255));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Pilotes", "Indicatif_Radio", c => c.String());
            AlterColumn("dbo.Pilotes", "Prenom", c => c.String());
            AlterColumn("dbo.Pilotes", "Nom", c => c.String());
        }
    }
}
