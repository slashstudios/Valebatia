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
    public class WeaponStats : Microsoft.Xna.Framework.GameComponent
    {
        // Types go here
        public static int defTestSwordDamage = 1;
        public static int copperSwordDamage = 5;
        public static int currentWeaponDamage = copperSwordDamage;
        public static int enemyDefense = Creatures.tortoiseDefense;
        public static int damagePerAttack = currentWeaponDamage - enemyDefense;

        public WeaponStats(Game game)
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

        }
    }
}
