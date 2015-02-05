#region Using Statements
using System;
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
#endregion

namespace Valebatia
{
    #region Enumerators
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
    #endregion

    public class Valebatia : Microsoft.Xna.Framework.Game
    {
        #region Player Functions
        public struct player 
        {
            public static Vector2 position = Vector2.Zero;
            public static Texture2D texture;
        }
        #endregion

        #region Achievements and Locked Achievements
        public class Achievements
        {


            public class lockedAchievements
            {
                // Dolphin Achievement
                public static int lachvEcholocation = 0;
                public static string lachvEcholocationDesc;
                // Timelord Achievement
                public static int lachvLordofTime = 0;
                public static string lachvLordofTimeDesc;
                // Kraken Achievement
                public static int lachvTrenchWrath = 0;
                public static string lachvTrenchWrathDesc;
                // Andriod Achievement
                public static int lachvWiresforBlood = 0;
                public static string lachvWiresforBloodDesc;
                
            }
        }
        #endregion

        #region Race Names and Hidden Race Names
        public class raceNames 
        {
            // Ground Races
            public int raceHuman = 1;
            public int raceGorilla = 1;
            // Air Races
            public int raceBirdman = 1;
            // Aquatic Races
            public int raceSharkman = 1;

            public class hiddenRaceNames
            {
                public int raceTimelord = 0;
                public int raceAndroid = 0;
                public int raceKraken = 0;
                public int raceDeveloper = 0;
                public int raceDolphin = 0;
                
            }

        }
        #endregion

        #region Types
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        public SpriteFont font;
        public int level = 0;
        public int playerHealth = 100;
        public int playerMana = 100;
        public int playerStamina = 100;
        public int timeLordLives = 13;
        public int exp = 0;
        public string ConnorHeadCode = "cutwovalebatia";
        public float startY = 250/*player.position.Y*/;
        public float jumpspeed = 0;
        public bool Hardcore = false;
        public bool jumping = false;
        public Texture2D Background;
        public Texture2D testTile;
        public Song gen_gps;
        public Song borealis;
        public Song spark;
        public Song kraken;
        #endregion

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

        #region Content Loading
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
        #endregion

        #region Content Unloading 
        protected override void UnloadContent()
        {
            // Unload Content Initiative
        }
        #endregion 

        #region Update Method
        protected override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            float frameRate = 1 / (float)gameTime.ElapsedGameTime.TotalSeconds;
            KeyboardState state = Keyboard.GetState();

            #region Game Closing
            if (state.IsKeyDown(Keys.Escape))
            {
                this.Exit();
            }
            #endregion
            
            #region Movement Controls

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
#endregion

            #region Achievement Stuff
            if ((Valebatia.Achievements.lockedAchievements.lachvLordofTime) == 1)
            {
                Valebatia.Achievements.lockedAchievements.lachvLordofTimeDesc = "You have 13 tries. Don't ruin anyone's life.";
            }
            if ((Valebatia.Achievements.lockedAchievements.lachvEcholocation) == 1)
            {
                Valebatia.Achievements.lockedAchievements.lachvEcholocationDesc = "A rare mutation of sharkpeople which can breath on land and not in water. . . ";
            }
            if ((Valebatia.Achievements.lockedAchievements.lachvTrenchWrath) == 1)
            {
                Valebatia.Achievements.lockedAchievements.lachvTrenchWrathDesc = "Something from the deep is coming. . .";
            }
            if (state.IsKeyDown(Keys.P))
            {
                //Valebatia.Achievements.lockedAchievements.lachvTrenchWrath = 1;
            }

            if ((Valebatia.Achievements.lockedAchievements.lachvWiresforBlood) == 1)
            {
                Valebatia.Achievements.lockedAchievements.lachvWiresforBloodDesc = "Something from the deep is coming. . .";
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

            //Audio Controls
        }
        #endregion
            
        #region Draw Method
        protected override void Draw(GameTime gameTime)
        {
            float frameRate = 1 / (float)gameTime.ElapsedGameTime.TotalSeconds;
            spriteBatch.Begin();
            //spriteBatch.Draw(Background, new Rectangle(0, 0, 800, 480), Color.Blue);
            spriteBatch.DrawString(font, "FPS: " + frameRate, new Vector2(80,30), Color.Black);
            spriteBatch.Draw(player.texture, player.position, Color.White);
            GraphicsDevice.Clear(Color.CornflowerBlue);

            spriteBatch.End();
            base.Draw(gameTime);
        }
        #endregion

    }

}
