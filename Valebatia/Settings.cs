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
    public class Settings : Microsoft.Xna.Framework.GameComponent
    {
        // Types Go Here
        public static bool hardmode = false;
        public static bool fullscreen = false;
        public static bool isDeveloper = true;

        public Settings(Game game)
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

            if ((hardmode) == true)
            {
                Bosses.BossStats.GiantHawkBeakedGalapagosTortoiseDefense = Bosses.BossStats.GiantHawkBeakedGalapagosTortoiseDefense * 2;
                Bosses.BossStats.GiantHawkBeakedGalapagosTortoiseHealth = Bosses.BossStats.GiantHawkBeakedGalapagosTortoiseHealth * 2;
                Bosses.BossStats.KrakenLordDefense = Bosses.BossStats.KrakenLordDefense * 2;
                Bosses.BossStats.KrakenLordHealth = Bosses.BossStats.KrakenLordHealth * 2;
            }
        }
    }
}
