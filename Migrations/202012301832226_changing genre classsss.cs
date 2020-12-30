namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changinggenreclasssss : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Movies", "GenreId", "dbo.Genres");
            DropPrimaryKey("dbo.Genres");
            AddColumn("dbo.Genres", "GenreId", c => c.Byte(nullable: false));
            AddPrimaryKey("dbo.Genres", "GenreId");
            AddForeignKey("dbo.Movies", "GenreId", "dbo.Genres", "GenreId", cascadeDelete: true);
            DropColumn("dbo.Genres", "Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Genres", "Id", c => c.Byte(nullable: false));
            DropForeignKey("dbo.Movies", "GenreId", "dbo.Genres");
            DropPrimaryKey("dbo.Genres");
            DropColumn("dbo.Genres", "GenreId");
            AddPrimaryKey("dbo.Genres", "Id");
            AddForeignKey("dbo.Movies", "GenreId", "dbo.Genres", "Id", cascadeDelete: true);
        }
    }
}
