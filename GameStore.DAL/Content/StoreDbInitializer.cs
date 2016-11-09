using System.Collections.Generic;
using System.Data.Entity;
using GameStore.DAL.Entities;
using GameStore.DAL.EF;

namespace GameStore.DAL.Content
{
    public class StoreDbInitializer : DropCreateDatabaseAlways<EF.GameStore>
    {
        protected override void Seed(EF.GameStore db)
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



            Game Heroes = new Game {Key = "heroes", Name = "Heroes7", Description = "Our story takes place during a war of succession. The Empress’ murder has left a realm in flames with many hungry rivals ready to seize the throne by force. The Duke Ivan then calls together a prestigious council of six trusted advisors to restore order and end the conflict that set ablaze Ashan’s lands."};
            Game NFS = new Game
            {
                Key = "nfs",
                Name = "Need for Speed",
                Description =
                    "Need For Speed: Most Wanted for Android - the long-awaited racing from EA Games got on your device! You will be pleased with the effects of the collision, implemented with the help of new physics now emergencies look even more realistic. Scratches on the body, broken glass, and lights, all this is also present in the Need for Speed ​​Most Wanted for Android!"
            };
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