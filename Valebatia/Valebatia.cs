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
        public string ConnorHeadCode = "cutwovalebatia";
        public string ircChannel = "#valebatia";
        public string savegame = "savegame.vbsg";
        public float startY = 250;
        public float jumpspeed = 0;
        public bool hardcore = false;
        public bool jumping = false;
        public bool paused = false;
        public bool released = false;
        public bool timelordLivesset = false;
        public Texture2D background;
        public Texture2D testTile;
        public Song gen_gps;
        public Song borealis;
        public Song spark;
        public Song kraken;


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
            /// Content Load Initiative

            spriteBatch = new SpriteBatch(this.GraphicsDevice);
            // Fonts and Text
            font = Content.Load<SpriteFont>("spriteFont");

            // Textures and Images
            player.texture = Content.Load<Texture2D>("Images/player");
            background = Content.Load<Texture2D>("Images/background");
            testTile = Content.Load<Texture2D>("Images/tile");

            // Audio and Sound
            gen_gps = Content.Load<Song>("Music/general_gps");
            borealis = Content.Load<Song>("Music/Borealis");
            spark = Content.Load<Song>("Music/Spark");
            kraken = Content.Load<Song>("Music/The Kraken");
            //MediaPlayer.Play(kraken);
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


                #region Achievements
                if ((Achievements.lockedAchievements.lachvLordofTime) == true && !timelordLivesset)
                {
                    Valebatia.raceNames.hiddenRaceNames.raceTimelord = true;
                    timelordLivesset = true;
                    timeLordLives = 13;
                }
                if ((Achievements.lockedAchievements.lachvEcholocation) == true)
                {
                    Valebatia.raceNames.hiddenRaceNames.raceDolphin = true;
                }
                if ((Achievements.lockedAchievements.lachvTrenchWrath) == true)
                {
                    Valebatia.raceNames.hiddenRaceNames.raceKraken = true;
                }
                if ((Achievements.lockedAchievements.lachvBloodforWires) == true)
                {
                    Valebatia.raceNames.hiddenRaceNames.raceAndroid = true;
                }
                #endregion

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
                if (state.IsKeyDown(Keys.P))
                {
                    playerHealth--;
                }
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
        }


        // Draw Method
        protected override void Draw(GameTime gameTime)
        {
            float frameRate = 1 / (float)gameTime.ElapsedGameTime.TotalSeconds;
            KeyboardState state = Keyboard.GetState();
            spriteBatch.Begin();
            spriteBatch.DrawString(font, "FPS: " + frameRate, new Vector2(80, 30), Color.Black);
            spriteBatch.DrawString(font, "Health:  " + playerHealth, new Vector2(80, 55), Color.Black);
            GraphicsDevice.Clear(Color.CornflowerBlue);

            if ((Achievements.lockedAchievements.lachvLordofTime) == true)
            {
                spriteBatch.DrawString(font, "Timelord Lives: " + timeLordLives, new Vector2(80, 80), Color.Black);
            }
            if (state.IsKeyDown(Keys.U))
            {
                spriteBatch.DrawString(font, ircChannel, new Vector2(80, 105), Color.Black);
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