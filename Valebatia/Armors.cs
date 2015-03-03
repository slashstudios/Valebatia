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
    public class Armors : Microsoft.Xna.Framework.GameComponent
    {
        // Types
        public static class Copper { 
            public static Texture2D helmet;
            public static int helmetdefense;
            public static Texture2D chestplate;
            public static int chestplatedefense;
            public static Texture2D leggings;
            public static int leggingsdefense;
            public static Texture2D boots;
            public static int bootsdefense;
        }
        public static class Steel { 
            public static Texture2D helmet;
            public static int helmetdefense;
            public static Texture2D chestplate;
            public static int chestplatedefense;
            public static Texture2D leggings;
            public static int leggingsdefense;
            public static Texture2D boots;
            public static int bootsdefense;
        }
        public static class Titanium { 
            public static Texture2D helmet;
            public static int helmetdefense;
            public static Texture2D chestplate;
            public static int chestplatedefense;
            public static Texture2D leggings;
            public static int leggingsdefense;
            public static Texture2D boots;
            public static int bootsdefense;
        }
        public static class Lead { 
            public static Texture2D helmet;
            public static int helmetdefense;
            public static Texture2D chestplate;
            public static int chestplatedefense;
            public static Texture2D leggings;
            public static int leggingsdefense;
            public static Texture2D boots;
            public static int bootsdefense;
        }
        public static class Uranium235 { 
            public static Texture2D helmet;
            public static int helmetdefense;
            public static Texture2D chestplate;
            public static int chestplatedefense;
            public static Texture2D leggings;
            public static int leggingsdefense;
            public static Texture2D boots;
            public static int bootsdefense;
        }
        public static class Plutonium240 { 
            public static Texture2D helmet;
            public static int helmetdefense;
            public static Texture2D chestplate;
            public static int chestplatedefense;
            public static Texture2D leggings;
            public static int leggingsdefense;
            public static Texture2D boots;
            public static int bootsdefense;
        }
        public static class Phantom { 
            public static Texture2D helmet;
            public static int helmetdefense;
            public static Texture2D chestplate;
            public static int chestplatedefense;
            public static Texture2D leggings;
            public static int leggingsdefense;
            public static Texture2D boots;
            public static int bootsdefense;
        }
        public static class Jade { 
            public static Texture2D helmet;
            public static int helmetdefense;
            public static Texture2D chestplate;
            public static int chestplatedefense;
            public static Texture2D leggings;
            public static int leggingsdefense;
            public static Texture2D boots;
            public static int bootsdefense;
        } /*
        public static class  {} 
        public static class  {}
        public static class  {}
        public static class  {}
        public static class  {}
        public static class  {} */
        public static class Dragon { 
            public static Texture2D helmet;
            public static int helmetdefense;
            public static Texture2D chestplate;
            public static int chestplatedefense;
            public static Texture2D leggings;
            public static int leggingsdefense;
            public static Texture2D boots;
            public static int bootsdefense;
        }
        public static class Developer { 
            public static Texture2D helmet;
            public static int helmetdefense;
            public static Texture2D chestplate;
            public static int chestplatedefense;
            public static Texture2D leggings;
            public static int leggingsdefense;
            public static Texture2D boots;
            public static int bootsdefense;
        }

        public Armors(Game game)
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
