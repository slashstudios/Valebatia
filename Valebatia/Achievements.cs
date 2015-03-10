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
    public class Achievements : Microsoft.Xna.Framework.GameComponent
    {
        // Achievements Go Here
        public static bool AllAchievementsUnlocked = false;
        public static bool WasBetaTesterOrDebugger = false;
        public static bool TortoiseTipper = false;

            public class lockedAchievements
            {
                // Dolphin Achievement
                public static bool lachvEcholocation = false;
                // Timelord Achievement
                public static bool lachvLordofTime = false;
                // Kraken Achievement
                public static bool lachvTrenchWrath = false;
                // Android Achievement
                public static bool lachvBloodforWires = false;

            }


        public Achievements(Game game)
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

        }
    }
}
