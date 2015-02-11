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
    public enum devUID { 
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
    public enum bodyTypes {
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
        

        public class Achievements
        {


            public class lockedAchievements
            {
                // Dolphin Achievement
                public static bool lachvEcholocation = false;
                public static string lachvEcholocationDesc;
                // Timelord Achievement
                public static bool lachvLordofTime = false;
                public static string lachvLordofTimeDesc;
                // Kraken Achievement
                public static bool lachvTrenchWrath = false;
                public static string lachvTrenchWrathDesc;
                // Android Achievement
                public static bool lachvBloodforWires = false;
                public static string lachvBloodforWiresDesc;
                
            }
        }
        

        public class raceNames 
        {
            // Ground Races
            public bool raceHuman = true;
            public bool raceGorilla = true;
            // Aquatic Races
            public bool raceSharkman = true;

            public class hiddenRaceNames
            {
                public bool raceTimelord = false;
                public bool raceAndroid = false;
                public bool raceKraken = false;
                public bool raceDeveloper = false;
                public bool raceDolphin = false;
                
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
        public float startY = 250;
        public float jumpspeed = 0;
        public bool Hardcore = false;
        public bool jumping = false;
        public bool paused = false;
        public bool released = false;
        public bool timelordLivesset = false;
        public Texture2D Background;
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
            font = Content.Load<SpriteFont>("gameName");

            // Textures and Images
            player.texture = Content.Load<Texture2D>("Images/player");
            Background = Content.Load<Texture2D>("Images/background");
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
            
            if (state.IsKeyDown(Keys.Escape))
            {
                paused = true; 
                while (state.IsKeyDown(Keys.Escape))
                {
                    
                }
            }

            else if (state.IsKeyDown(Keys.Escape) && paused)
            {
                while (state.IsKeyDown(Keys.Escape))
                {

                }
                released = false;
                paused = false;
            }
            else if (!paused)
            {

                // Closing Controls
                if (state.IsKeyDown(Keys.PageUp))
                {
                    this.Exit();
                }

                // Movement Controls

                if (state.IsKeyDown(Keys.W))
                {
                    player.position.Y -= 2;
                }
                if (state.IsKeyDown(Keys.A))
                {
                    player.position.X -= 2;
                }
                if (state.IsKeyDown(Keys.S))
                {
                    player.position.Y += 2;
                }
                if (state.IsKeyDown(Keys.D))
                {
                    player.position.X += 2;
                }


                // Achievements
                if ((Valebatia.Achievements.lockedAchievements.lachvLordofTime) == true && !timelordLivesset)
                {
                    Valebatia.Achievements.lockedAchievements.lachvLordofTimeDesc = "You have 13 tries. Don't ruin anyone's life.";
                    timelordLivesset = true;
                    timeLordLives = 13;
                }
                if ((Valebatia.Achievements.lockedAchievements.lachvEcholocation) == true)
                {
                    Valebatia.Achievements.lockedAchievements.lachvEcholocationDesc = "A rare mutation of sharkpeople which can breathe on land and not in water. . . ";
                }
                if ((Valebatia.Achievements.lockedAchievements.lachvTrenchWrath) == true)
                {
                    Valebatia.Achievements.lockedAchievements.lachvTrenchWrathDesc = "Something from the deep is coming. . .";
                }
                if ((Valebatia.Achievements.lockedAchievements.lachvBloodforWires) == true)
                {
                    Valebatia.Achievements.lockedAchievements.lachvBloodforWiresDesc = "Something from the deep is coming. . .";
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

                if (state.IsKeyDown(Keys.P))
                {
                    playerHealth--;
                }
                if (state.IsKeyDown(Keys.O))
                {
                    Valebatia.Achievements.lockedAchievements.lachvLordofTime = true;
                }

                if ((playerHealth) <= 0)
                {
                    playerHealth = 0;
                }

                if ((playerHealth) == 0 && timeLordLives > 0 && Valebatia.Achievements.lockedAchievements.lachvLordofTime)
                {
                    playerHealth = 100;
                    timeLordLives--;
                }
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

                if ((Valebatia.Achievements.lockedAchievements.lachvLordofTime) == true)
                {
                    spriteBatch.DrawString(font, "Timelord Lives: " + timeLordLives, new Vector2(80, 80), Color.Black);
                }

                spriteBatch.Draw(player.texture, player.position, Color.White);

                spriteBatch.End();
                if (paused)
            {
                spriteBatch.Begin();
                spriteBatch.Draw(Background, new Rectangle(0, 0, 800, 480), Color.Black * 0.5f);

                spriteBatch.End();
            }
                base.Draw(gameTime);

        }
        
    }

}