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
            Genre Moba = new Genre { Name = "MOBA" };

            db.Genres.AddRange(new List<Genre>
            {
                RPG,
                Strategy,
                Races,
                Sports,
                Action,
                Adventureaces,
                PuzzleSkill,
                Moba
            });
            //db.SaveChanges();


            Genre RTS = new Genre { Name = "RTS", Parent = Strategy };
            Genre TBS = new Genre { Name = "TBS", Parent = Strategy };
            db.Genres.AddRange(new List<Genre>
            {
                RTS,
                TBS
            });
            Strategy.SubGenres.Add(RTS);
            Strategy.SubGenres.Add(TBS);
          

            Genre arcade = new Genre { Name = "arcade", Parent = Races };
            Genre formula = new Genre { Name = "formula", Parent = Races };
            Genre offRoad = new Genre { Name = "off-Road", Parent = Races };
            db.Genres.AddRange(new List<Genre>
            {
                arcade,
                formula,
                offRoad
            });
            Races.SubGenres.Add(arcade);
            Races.SubGenres.Add(formula);
            Races.SubGenres.Add(offRoad);

            Genre FPS = new Genre { Name = "FPS", Parent = Action };
            Genre TPS = new Genre { Name = "TPS", Parent = Action };
            Genre Misc = new Genre { Name = "Misc", Parent = Action };
            db.Genres.AddRange(new List<Genre>
            {
                FPS,
                TPS,
                Misc
            });
            Action.SubGenres.Add(FPS);
            Action.SubGenres.Add(TPS);
            Action.SubGenres.Add(Misc);

            db.SaveChanges();


            Game Heroes = new Game
            {
                Key = "heroes",
                Name = "Heroes7",
                Description =
                    "Our story takes place during a war of succession. The Empress’ murder has left a realm in flames with many hungry rivals ready to seize the throne by force. The Duke Ivan then calls together a prestigious council of six trusted advisors to restore order and end the conflict that set ablaze Ashan’s lands."
            };//publisher :
            Game NFS = new Game
            {
                Key = "nfs",
                Name = "Need for Speed",
                Description =
                    "Need For Speed: Most Wanted for Android - the long-awaited racing from EA Games got on your device! You will be pleased with the effects of the collision, implemented with the help of new physics now emergencies look even more realistic. Scratches on the body, broken glass, and lights, all this is also present in the Need for Speed ​​Most Wanted for Android!"
            };//publisher :EA Games
            Game Titanfall2 = new Game
            {
                Key = "titanfall2",
                Name = "Titanfall 2",
                Description =
                    "Respawn Entertainment returns with the highly anticipated sequel Titanfall 2.Featuring a captivating single player campaign along with an expanded multiplayer mode,Titanfall 2 delivers a fast - paced thrilling experience for action fans."
            };//publisher : 365games
            Game Overwatch = new Game
            {
                Key = "overwatch",
                Name = "Overwatch",
                Description =
                    "Soldiers. Scientists. Adventurers. Oddities.In a time of global crisis, an international task force of heroes banded together to restore peace to a war-torn world: Overwatch. It ended the crisis and helped to maintain peace in the decades that followed, inspiring an era of exploration, innovation, and discovery. But after many years, Overwatch's influence waned, and it was eventually disbanded."
            };//publisher :Blizzard
            Game Battlefield1 = new Game
            {
                Key = "battlefield1",
                Name = "Battlefield 1",
                Description =
                    "Fight your way through epic battles ranging from tight urban combat in a besieged French city to the heavily defended mountain forts in the Italian Alps, or frantic combats in the deserts of Arabia. Discover a world at war through an adventure-filled campaign, or join in epic multiplayer battles with up to 64 players, and adapt your tactics to the earth-shattering destruction and dynamic weather. Fight as infantry, lead horse charges or take control of amazing vehicles on land, air and sea, from tanks and biplanes to the gigantic Behemoths – some of the largest vehicles in Battlefield history."
            };//publisher :EA Geames
            Game MirrorsEdgeCatalyst = new Game
            {
                Key = "mirrorsEdgeCatalyst",
                Name = "Mirror's Edge Catalyst",
                Description =
                    "Mirror’s Edge Catalyst raises the action-adventure bar through fluid, first person action and immerses players in Faith’s origin story as she fights for freedom within the city of Glass."
            };//publisher :EA Geames
            Game FIFA17 = new Game
            {
                Key = "FIFA17",
                Name = "FIFA 17",
                Description =
                    "Immerse yourself in the beautiful game like never before in FIFA 17 on PS4. Now powered by the Frostbite engine, FIFA 17 delivers a more in-depth and authentic football experience than ever before. With improvements at both ends of the pitch, FIFA 17 gives you more control in both attack and defence, allowing you to create realistic and unforgettable games."
            };//publisher :EA Games
            Game DarkSoulsIII = new Game
            {
                Key = "darkSoulsIII",
                Name = "Dark Souls III",
                Description =
                   "Miyazaki continue their critically-acclaimed and genre-defining series with Dark Souls III. Fans and newcomers alike will get lost in the games hallmark rewarding gameplay and immersive graphics. "
            };//publisher :FromSoftware
            Game Dishonored2 = new Game
            {
                Key = "dishonored2",
                Name = "Dishonored 2",
                Description =
                               "Reprise your role as a supernatural assassin in Dishonored 2, the highly anticipated follow up to Arkane Studios’ 2012 Game of the Year!The Assassins - Play as Emily Kaldwin or Corvo Attano,each with their own sets of powers.Neutralise your enemies in stealth or eliminate using your weapons or powers Supernatural Powers -Choose from nearly infinite combinations of violence, nonlethal combat, powers and weapons to accomplish your objectives. Imaginative World -Karnaca, The Jewel of The South, is a character in its own right, rich with story, architecture and eclectic characters.Epic Missions -Take on signature missions, such as the Dust District, ravaged by dust storms and warring factions, and a madman’s mansion made of shifting walls, deadly traps and clockwork soldiers. "
            };//publisher :Arcane





            PlatformType mobile = new PlatformType { Type = "mobile" };
            PlatformType browser = new PlatformType { Type = "browser" };
            PlatformType desktop = new PlatformType { Type = "desktop" };
            PlatformType console = new PlatformType { Type = "console" };


            FIFA17.Genres.Add(Sports);
            FIFA17.PlatformTypes.Add(console);

            DarkSoulsIII.Genres.Add(Action);
            DarkSoulsIII.PlatformTypes.Add(console);

            Dishonored2.Genres.Add(Action);
            Dishonored2.PlatformTypes.Add(console);


            Titanfall2.Genres.Add(Action);
            Titanfall2.PlatformTypes.Add(desktop);


            Battlefield1.Genres.Add(Action);
            Battlefield1.PlatformTypes.Add(desktop);

            MirrorsEdgeCatalyst.Genres.Add(Action);
            MirrorsEdgeCatalyst.PlatformTypes.Add(desktop);

            Overwatch.Genres.Add(Action);
            Overwatch.Genres.Add(Moba);
            Overwatch.PlatformTypes.Add(console);

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


            db.Games.AddRange(new List<Game>
            {
                Heroes,
                NFS,
                Titanfall2,
                Battlefield1,
                MirrorsEdgeCatalyst,
                Overwatch,
                DarkSoulsIII,
                Dishonored2,
                FIFA17
            });
            db.Comments.Add(firstHeroes);
            db.Comments.Add(secondHeroes);
            db.Comments.Add(firstNFS);
            db.SaveChanges();
        }
    }
}