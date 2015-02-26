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
    // Enumerators
    public enum HMSstages
    {
        Copper,
        Galvanized_Iron,
        Carbon,
        Titanium,
        Depleted_Uranium
        
    }
    public enum devUID
    {
        epicdragonfour,
        shadeslayer,
        two_cat0,
        cupid_titanium,
        kk_sherlokiwitz,
        dinostep,
        tryad,
        scorpion3k,
        warhawk92,
        starhunter117,
        kamikaze909,
    }
    public enum bodyTypes
    {
        Lanky,
        Average,
        Muscular,
        Shark,
        Timelord,
        Dolphin,
        Android,
        Kraken
    }


    public class Valebatia : Microsoft.Xna.Framework.Game
    {
        // Player Functions
        public struct player
        {
            
            public static Vector2 position;
            public static Texture2D texture;
        }




        
        public class raceNames
        {
            // Ground Races
            public static bool raceHuman = true;
            public static bool raceGorilla = true;
            // Aquatic Races
            public static bool raceSharkman = true;

            public class hiddenRaceNames
            {
                public static bool raceTimelord = false;
                public static bool raceAndroid = false;
                public static bool raceKraken = false;
                public static bool raceDeveloper = false;
                public static bool raceDolphin = false;

            }

        }

        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        public SpriteFont font;
        public int playerHealth = 100;
        public int playerMana = 100;
        public int playerStamina = 100;
        public int timeLordLives = 13;
        public int itemBar = 1;
        public string ConnorHeadCode = "cutwovalebatia";
        public string savegame = "savegame.vbsg";
        public float startY = 250;
        public float jumpspeed = 0;
        public float tortoiseSpeed = 1f;
        public bool jumping = false;
        public bool paused = false;
        public bool released = false;
        public bool timelordLivesset = false;
        public Texture2D background;
        public Texture2D tortoise;
        public Texture2D itemToolbar;
        public Song gen_gps;
        public Song borealis;
        public Song spark;
        public Song kraken;
        public int tortoiseHealth = 100;
        public int tortoiseDefense = 15;
        public int sharkhealthtemp = 0;
        public int sharkdeathtemp = 0;
        public Vector2 tortoisePosition;

        public Valebatia()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            this.Window.Title = "Valebatia";
            this.IsMouseVisible = true;
        }
        protected override void Initialize()
        {
            base.Initialize();

        }

        protected override void LoadContent()
        {
            // Content Load Initiative
            spriteBatch = new SpriteBatch(this.GraphicsDevice);

            // Fonts and Text
            font = Content.Load<SpriteFont>("spriteFont");

            // Textures and Images
            player.texture = Content.Load<Texture2D>("Images/player");
            background = Content.Load<Texture2D>("Images/background");
            tortoise = Content.Load<Texture2D>("Images/tortoise");
            itemToolbar = Content.Load<Texture2D>("Images/itemtoolbar");

            // Audio and Sound
            gen_gps = Content.Load<Song>("Music/general_gps");
            borealis = Content.Load<Song>("Music/Borealis");
            spark = Content.Load<Song>("Music/Spark");
            kraken = Content.Load<Song>("Music/The Kraken");

            // Type Definitions
            tortoisePosition = new Vector2(200,200);
        }


        protected override void UnloadContent()
        {
            // Unload Content Initiative
        }

        
        protected override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            float frameRate = 1 / (float)gameTime.ElapsedGameTime.TotalSeconds;
            KeyboardState state = Keyboard.GetState();
            MouseState mouseState = Mouse.GetState();

                // Closing Controls
                if (state.IsKeyDown(Keys.PageUp))
                {
                    this.Exit();
                }
                
                // Movement Controls
                if (state.IsKeyDown(Keys.W))
                {
                    Valebatia.player.position.Y -= 2;
                }
                if (state.IsKeyDown(Keys.A))
                {
                    Valebatia.player.position.X -= 2;
                }
                if (state.IsKeyDown(Keys.S))
                {
                    Valebatia.player.position.Y += 2;
                }
                if (state.IsKeyDown(Keys.D))
                {
                    Valebatia.player.position.X += 2;
                }

                #region Jump Physics
                if (jumping)
                {

                    player.position.Y += jumpspeed; // Makes it go upwards
                    jumpspeed += 1;
                    if (player.position.Y >= startY)
                    //If it's farther than ground
                    {
                        jumping = false;
                        player.position.Y = startY;
                    }
                }
                else
                {
                    if (state.IsKeyDown(Keys.Space))
                    {
                        jumping = true;
                        startY = player.position.Y;
                        jumpspeed = -5; //Give the player upward thrust
                    }
                }
                #endregion

                // Player Functions
                if ((player.position.Y) <= 0)
                {
                    player.position.Y = 0;
                }
                if ((player.position.X) <= 0)
                {
                    player.position.X = 0;
                }
                if ((player.position.X) == 480)
                {
                    player.position.X = 480;
                }
                if (state.IsKeyDown(Keys.P))
                {
                    playerHealth--;
                }

                // Moves the Tortoise
                tortoisePosition.X = tortoisePosition.X += 1.75f;
                if ((tortoisePosition.X) >= 800)
                {
                    tortoisePosition.X = 0;
                }
                
                // Developer Testing Stuff
                if (state.IsKeyDown(Keys.O))
                {
                    Achievements.lockedAchievements.lachvLordofTime = true;
                }
                if ((playerHealth) <= 0)
                {
                    playerHealth = 0;
                }
                if ((playerHealth) == 0 && timeLordLives > 0 && Achievements.lockedAchievements.lachvLordofTime)
                {
                    playerHealth = 100;
                    timeLordLives--;
                }
                if (state.IsKeyDown(Keys.U))
                {
                    tortoiseHealth =  tortoiseHealth - WeaponStats.damagePerAttack;
                }
                if ((tortoiseHealth) <= 0)
                {
                    tortoiseHealth = 0;
                }
                if (Bosses.BossStats.HugeassMechanicalSharkHealth <= 0)
                {
                    Bosses.BossStats.HugeassMechanicalSharkHealth = 0;
                }
                if (Bosses.BossStats.HugeassMechanicalSharkHealth == 0)
                {
                    Bosses.BossStats.HugeassMechanicalSharkDefeats = Bosses.BossStats.HugeassMechanicalSharkDefeats + 1;
                    sharkhealthtemp = 1;
                }



            #region HMS Stuff

                if ((Bosses.BossStats.HugeassMechanicalSharkDefeats) == 1 && sharkhealthtemp == 1)
                {
                    sharkhealthtemp = 0;
                    Bosses.BossStats.HugeassMechanicalSharkHealth = 4103;
                    Bosses.BossStats.HugeassMechanicalSharkDefense = 45;
                    Bosses.BossStats.HugeassMechanicalSharkHealth = Bosses.BossStats.HugeassMechanicalSharkHealth * 2;
                    Bosses.BossStats.HugeassMechanicalSharkDefense = Bosses.BossStats.HugeassMechanicalSharkDefense * 3 / 2;
                }
                if ((Bosses.BossStats.HugeassMechanicalSharkDefeats) == 2 && sharkhealthtemp == 1)
                {
                    sharkhealthtemp = 0;
                    Bosses.BossStats.HugeassMechanicalSharkHealth = 4103;
                    Bosses.BossStats.HugeassMechanicalSharkDefense = 45;
                    Bosses.BossStats.HugeassMechanicalSharkHealth = Bosses.BossStats.HugeassMechanicalSharkHealth * 4;
                    Bosses.BossStats.HugeassMechanicalSharkDefense = Bosses.BossStats.HugeassMechanicalSharkDefense * 6 / 2;
                }
                if ((Bosses.BossStats.HugeassMechanicalSharkDefeats) == 3 && sharkhealthtemp == 1)
                {
                    sharkhealthtemp = 0;
                    Bosses.BossStats.HugeassMechanicalSharkHealth = 4103;
                    Bosses.BossStats.HugeassMechanicalSharkDefense = 45;
                    Bosses.BossStats.HugeassMechanicalSharkHealth = Bosses.BossStats.HugeassMechanicalSharkHealth * 6;
                    Bosses.BossStats.HugeassMechanicalSharkDefense = Bosses.BossStats.HugeassMechanicalSharkDefense * 9 / 2;
                }
                if ((Bosses.BossStats.HugeassMechanicalSharkDefeats) == 4 && sharkhealthtemp == 1)
                {
                    sharkhealthtemp = 0;
                    Bosses.BossStats.HugeassMechanicalSharkHealth = 4103;
                    Bosses.BossStats.HugeassMechanicalSharkDefense = 45;
                    Bosses.BossStats.HugeassMechanicalSharkHealth = Bosses.BossStats.HugeassMechanicalSharkHealth * 8;
                    Bosses.BossStats.HugeassMechanicalSharkDefense = Bosses.BossStats.HugeassMechanicalSharkDefense * 12 / 2;
                }
                if ((Bosses.BossStats.HugeassMechanicalSharkDefeats) == 5 && sharkhealthtemp == 1)
                {
                    sharkhealthtemp = 0;
                    Bosses.BossStats.HugeassMechanicalSharkHealth = 4103;
                    Bosses.BossStats.HugeassMechanicalSharkDefense = 45;
                    Bosses.BossStats.HugeassMechanicalSharkHealth = Bosses.BossStats.HugeassMechanicalSharkHealth * 10;
                    Bosses.BossStats.HugeassMechanicalSharkDefense = Bosses.BossStats.HugeassMechanicalSharkDefense * 15 / 2;
                }
                if ((Bosses.BossStats.HugeassMechanicalSharkDefeats) == 6 && sharkhealthtemp == 1)
                {
                    sharkhealthtemp = 0;
                    Bosses.BossStats.HugeassMechanicalSharkHealth = 4103;
                    Bosses.BossStats.HugeassMechanicalSharkDefense = 45;
                    Bosses.BossStats.HugeassMechanicalSharkHealth = Bosses.BossStats.HugeassMechanicalSharkHealth * 15;
                    Bosses.BossStats.HugeassMechanicalSharkDefense = Bosses.BossStats.HugeassMechanicalSharkDefense * 10 / 2;
                    sharkdeathtemp = 1;
                }
                if ((Bosses.BossStats.HugeassMechanicalSharkDefeats) > 5)
                {
                    Bosses.BossStats.HugeassMechanicalSharkDefeats = 5;
                    Bosses.BossStats.HugeassMechanicalSharkHealth = 0;
                }

                if (state.IsKeyDown(Keys.I) && sharkdeathtemp == 0)
                {
                    Bosses.BossStats.HugeassMechanicalSharkHealth = Bosses.BossStats.HugeassMechanicalSharkHealth - 150;
                }
            #endregion
        }


        // Draw Method
        protected override void Draw(GameTime gameTime)
        {
            float frameRate = 1 / (float)gameTime.ElapsedGameTime.TotalSeconds;
            KeyboardState state = Keyboard.GetState();
            spriteBatch.Begin();
            GraphicsDevice.Clear(Color.CornflowerBlue);
            spriteBatch.DrawString(font, "FPS: " + frameRate, new Vector2(80, 30), Color.Black);
            spriteBatch.DrawString(font, "Health:  " + playerHealth, new Vector2(80, 55), Color.Black);
            spriteBatch.DrawString(font, "HMS health: " + Bosses.BossStats.HugeassMechanicalSharkHealth, new Vector2(80, 155), Color.Black);
            // spriteBatch.DrawString(font, "Defeats: " + Bosses.BossStats.HugeassMechanicalSharkDefeats, new Vector2(80, 175), Color.Black);
            if ((Achievements.lockedAchievements.lachvLordofTime) == true)
            {
                spriteBatch.DrawString(font, "Timelord Lives: " + timeLordLives, new Vector2(80, 130), Color.Black);
            }
            if ((tortoiseHealth) > 0)
            {
                spriteBatch.Draw(tortoise, tortoisePosition, Color.White);
                spriteBatch.DrawString(font, "Tortoise Health: " + tortoiseHealth, new Vector2(80, 80), Color.Black);
            }
            spriteBatch.Draw(player.texture, player.position, Color.White);
            /*if (paused == true)
            {
                spriteBatch.Draw(background, new Rectangle(0, 0, 800, 480), Color.Black * 0.5f);
            }
             */
            base.Draw(gameTime);
            spriteBatch.End();
        }


    }
}