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
    public class Creatures : Microsoft.Xna.Framework.GameComponent
    {
        // Types Go Here
        public static int tortoiseDefense = 1;
        public class stats
        {
            public static int goosehealth = 100;
            public static int goose_rainbow_health = 500;
        }
        public class positions
        {
            public static Vector2 goosepos = new Vector2(500, 300);
        }
        public class textures
        {
            public static Texture2D tortoise;
            public static Texture2D goose_body;
            public static Texture2D goose_head;
            public static Texture2D goose_rainbow;

        }

        public Creatures(Game game)
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
