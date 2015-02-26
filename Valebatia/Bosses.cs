using System;
using System.Windows;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using Microsoft.Xna.Framework.Net;
using Microsoft.Xna.Framework.Storage;
using System.Diagnostics;
using System.Threading;


namespace Valebatia
{
    public class Bosses : Microsoft.Xna.Framework.GameComponent
    {
        // Put Types here
        public static class BossStats
        {
            public static int KrakenLordHealth = 2500;
            public static int KrakenLordDefense = 32;
            public static int GiantHawkBeakedGalapagosTortoiseHealth = 3200;
            public static int GiantHawkBeakedGalapagosTortoiseDefense = 66;
            public static int HugeassMechanicalSharkHealth = 4103; // Oddly Specific
            public static int HugeassMechanicalSharkDefense = 45;
            public static int HugeassMechanicalSharkDefeats = 0;
            public static int MasterPlundererHealth = 1500;
            public static int MasterPlundererDefense = 17;
            
        }
        public static class BossDeathChecklist
        {
            public static bool IsKrakenLordDefeated = false;
            public static bool IsGiantHawkBeakedGalapagosTortoiseDefeated = false;
            public static bool IsHugeassMechanicalSharkDefeated = false;
            public static bool IsMasterPlundererDefeated = false;


        }

        public Bosses(Game game)
            : base(game)
        {

        }

        public override void Initialize()
        {
            base.Initialize();
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            float frameRate = 1 / (float)gameTime.ElapsedGameTime.TotalSeconds;
            KeyboardState state = Keyboard.GetState();
            MouseState mouseState = Mouse.GetState();

            if ((Bosses.BossStats.KrakenLordHealth) <= 0)
            {
                Bosses.BossDeathChecklist.IsKrakenLordDefeated = true;
                Bosses.BossStats.KrakenLordHealth = 0;
            }
            if ((Bosses.BossStats.GiantHawkBeakedGalapagosTortoiseHealth) <= 0)
            {
                Bosses.BossDeathChecklist.IsGiantHawkBeakedGalapagosTortoiseDefeated = true;
                Bosses.BossStats.GiantHawkBeakedGalapagosTortoiseHealth = 0;
            }
            if ((Bosses.BossStats.HugeassMechanicalSharkHealth) <= 0 && Bosses.BossStats.HugeassMechanicalSharkDefeats == 5)
            {
                BossDeathChecklist.IsHugeassMechanicalSharkDefeated = true;
            }
            }
        }
    }