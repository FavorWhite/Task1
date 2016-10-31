using System.Collections.Generic;
using System.Data.Entity;
using Task1_DAL.EF;
using Task1_DAL.Entities;

namespace Task1_DAL.Content
{
    public class StoreDbInitializer : DropCreateDatabaseAlways<GameStore>
    {
        protected override void Seed(GameStore db)
        {



            Genre RPG = new Genre { Name = "RPG" };
            Genre Strategy = new Genre { Name = "Strategy" };
            Genre Races = new Genre { Name = "Races" };
            Genre Sports = new Genre { Name = "Sports" };
            Genre Action = new Genre { Name = "Action" };
            Genre Adventureaces = new Genre { Name = "Adventureaces" };
            Genre PuzzleSkill = new Genre { Name = "Puzzle & Skill" };

            db.Genres.AddRange(new List<Genre>
            {
                RPG,
                Strategy,
                Races,
                Sports,
                Action,
                Adventureaces,
                PuzzleSkill
            });
            db.SaveChanges();


            Genre RTS = new Genre { Name = "RTS", Parent = Strategy };
            Genre TBS = new Genre { Name = "TBS", Parent = Strategy };
            db.Genres.AddRange(new List<Genre>
            {
                RTS,
                TBS
            });
            db.SaveChanges();

            Genre arcade = new Genre { Name = "arcade", Parent = Races };
            Genre formula = new Genre { Name = "formula", Parent = Races };
            Genre offRoad = new Genre {Name = "off-Road", Parent = Races};
            db.Genres.AddRange(new List<Genre>
            {
                arcade,
                formula,
                offRoad
            });

            Genre FPS = new Genre { Name = "FPS", Parent = Action };
            Genre TPS = new Genre { Name = "TPS", Parent = Action };
            Genre Misc = new Genre { Name = "Misc", Parent = Action };
            db.Genres.AddRange(new List<Genre>
            {
                FPS,
                TPS,
                Misc
            });



            Game Heroes = new Game { Key = "first", Name = "Heroes", Description = "heroes" };
            Game NFS = new Game { Key = "second", Name = "Need for Speed", Description = "NFS" };

            PlatformType mobile = new PlatformType {Type = "mobile"};
            PlatformType browser = new PlatformType { Type = "browser" };
            PlatformType desktop = new PlatformType { Type = "desktop" };
            PlatformType console = new PlatformType { Type = "console" };




            Heroes.Genres.Add(Strategy);
            Heroes.Genres.Add(RTS);
            Heroes.Genres.Add(TBS);
            Heroes.PlatformTypes.Add(mobile);
            Heroes.PlatformTypes.Add(browser);




            NFS.Genres.Add(Races);
            NFS.Genres.Add(arcade);
            NFS.PlatformTypes.Add(desktop);
            NFS.PlatformTypes.Add(console);


            Comment firstHeroes = new Comment
            {
                Name = "firstHeroesAuhor",
                Body = "FirstHeroesComment",
                Game = Heroes,
            };
            Comment secondHeroes = new Comment
            {
                Name = "secondHeroesAuhor",
                Body = "secondHeroesComment",
                Game = Heroes,
                Parent = firstHeroes,
                ParentName = firstHeroes.Name
            };
            firstHeroes.CommentResponses.Add(secondHeroes);
            Comment firstNFS = new Comment
            {
                Name = "firstNFSAuhor",
                Body = "FirstNFSComment",
                Game = NFS,
            };

            

            db.Games.Add(Heroes);
            db.Games.Add(NFS);
            db.Comments.Add(firstHeroes);
            db.Comments.Add(secondHeroes);
            db.Comments.Add(firstNFS);
            db.SaveChanges();
        }
    }
}