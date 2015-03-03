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
    public class Races : Microsoft.Xna.Framework.GameComponent
    {
        public static int selectedRace = 1;
        // Types Go Here
        public static bool human = true;
        public static Texture2D humansprite;
        public static bool sharkperson = true;
        public static Texture2D sharkpersonsprite;
        public static bool plantrace = true;
        public static Texture2D plantracesprite;


        public class lockedRaces
        {
            public static bool timeLord = false;
            public static Texture2D timelordsprite;
            public static bool dolphin = false;
            public static Texture2D dolphinsprite;
            public static bool android = false;
            public static Texture2D androidsprite;
            public static bool developer = false;

        }
        public Races(Game game)
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
