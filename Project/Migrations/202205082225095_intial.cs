namespace Project.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class intial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Actors",
                c => new
                    {
                        ActorId = c.Int(nullable: false),
                        FirstName = c.String(nullable: false, maxLength: 50),
                        LastName = c.String(nullable: false, maxLength: 50),
                        Age = c.Int(nullable: false),
                        ParticipatedMovies = c.String(),
                    })
                .PrimaryKey(t => t.ActorId)
                .ForeignKey("dbo.Users", t => t.ActorId)
                .Index(t => t.ActorId);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        UserId = c.Int(nullable: false, identity: true),
                        FirstName = c.String(nullable: false, maxLength: 50),
                        LastName = c.String(nullable: false, maxLength: 50),
                        ProfileImage = c.String(),
                        UserName = c.String(),
                        Password = c.String(),
                    })
                .PrimaryKey(t => t.UserId);
            
            CreateTable(
                "dbo.Directors",
                c => new
                    {
                        DirectorId = c.Int(nullable: false),
                        FirstName = c.String(nullable: false, maxLength: 50),
                        LastName = c.String(nullable: false, maxLength: 50),
                        Age = c.Int(nullable: false),
                        ProducedMovies = c.String(),
                    })
                .PrimaryKey(t => t.DirectorId)
                .ForeignKey("dbo.Users", t => t.DirectorId)
                .Index(t => t.DirectorId);
            
            CreateTable(
                "dbo.Movies",
                c => new
                    {
                        MovieId = c.Int(nullable: false),
                        MovieName = c.String(nullable: false, maxLength: 50),
                        MovieImage = c.String(),
                        MovieActors = c.String(),
                        MovieDirectors = c.String(),
                    })
                .PrimaryKey(t => t.MovieId)
                .ForeignKey("dbo.Users", t => t.MovieId)
                .Index(t => t.MovieId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Movies", "MovieId", "dbo.Users");
            DropForeignKey("dbo.Directors", "DirectorId", "dbo.Users");
            DropForeignKey("dbo.Actors", "ActorId", "dbo.Users");
            DropIndex("dbo.Movies", new[] { "MovieId" });
            DropIndex("dbo.Directors", new[] { "DirectorId" });
            DropIndex("dbo.Actors", new[] { "ActorId" });
            DropTable("dbo.Movies");
            DropTable("dbo.Directors");
            DropTable("dbo.Users");
            DropTable("dbo.Actors");
        }
    }
}
