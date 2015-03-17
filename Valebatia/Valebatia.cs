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
            
            public static Vector2 position = new Vector2(100,300);
            public static Texture2D texture;
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
        public bool iskeydown = true;
        public bool iskeydownregen = true;
        public Texture2D dirt;
        public Texture2D background;
        public Texture2D tortoise;
        public Texture2D itemToolbar;
        public Texture2D raceSelect;
        public Texture2D blacktile;
        public Song gen_gps;
        public Song borealis;
        public Song spark;
        public Song kraken;
        public Song tokyo;
        public int tortoiseHealth = 100;
        public int tortoiseDefense = 15;
        public int sharkhealthtemp = 0;
        public int sharkdeathtemp = 0;
        public Vector2 tortoisePosition = new Vector2(200,200);
        MouseState mousepos = Mouse.GetState();
        public Valebatia()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            this.Window.Title = "Valebatia";
            this.IsMouseVisible = true; 
            this.Components.Add(new GamerServicesComponent(this));
        }
        

        protected override void Initialize()
        {
            base.Initialize();
        }

        protected override void LoadContent()
        {
            blacktile = Content.Load<Texture2D>("Images/Tiles/blacksquare");
            // Fonts and Graphics
            spriteBatch = new SpriteBatch(this.GraphicsDevice);
            this.font = Content.Load<SpriteFont>("spriteFont");

            // GUI
            itemToolbar = Content.Load<Texture2D>("Images/GUI/itemtoolbar");
            raceSelect = Content.Load<Texture2D>("Images/GUI/race_select");

            // Audio and Sound
            gen_gps = Content.Load<Song>("Music/general_gps");
            borealis = Content.Load<Song>("Music/Borealis");
            spark = Content.Load<Song>("Music/Spark");
            kraken = Content.Load<Song>("Music/The Kraken");
            tokyo = Content.Load<Song>("Music/tokyo");

            // Armor Textures
            Armors.Copper.chestplate = Content.Load<Texture2D>("Images/Armors/Copper/copperchestplate");

            // Race Textures
            player.texture = Content.Load<Texture2D>("Images/Races/player");
            Races.sharkpersonsprite = Content.Load<Texture2D>("Images/Races/sharkrace");
            Races.plantracesprite = Content.Load<Texture2D>("Images/Races/race_plant");

            // Creature Textures
            Creatures.textures.tortoise = Content.Load<Texture2D>("Images/Creatures/tortoise");
            Creatures.textures.goose_head = Content.Load<Texture2D>("Images/Creatures/goose_head");
            Creatures.textures.goose_body = Content.Load<Texture2D>("Images/Creatures/goose_body");
            Creatures.textures.goose_rainbow = Content.Load<Texture2D>("Images/Creatures/goose_rainbow");

            // Items 
                // Misc Items
            Items.misc.penguin_paint_blue = Content.Load<Texture2D>("Images/Items/Misc/spraypaint_blue");
            Items.misc.penguin_paint_red = Content.Load<Texture2D>("Images/Items/Misc/spraypaint_red");
            Items.misc.penguin_paint_yellow = Content.Load<Texture2D>("Images/Items/Misc/spraypaint_yellow");
        }
            
        protected override void UnloadContent() { }
            
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

                #region Player Movement
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
                if (state.IsKeyDown(Keys.W) && state.IsKeyDown(Keys.LeftShift))
                {
                    Valebatia.player.position.Y -= 4;
                }
                if (state.IsKeyDown(Keys.A) && state.IsKeyDown(Keys.LeftShift))
                {
                    Valebatia.player.position.X -= 4;
                }
                if (state.IsKeyDown(Keys.S) && state.IsKeyDown(Keys.LeftShift))
                {
                    Valebatia.player.position.Y += 4;
                }
                if (state.IsKeyDown(Keys.D) && state.IsKeyDown(Keys.LeftShift))
                {
                    Valebatia.player.position.X += 4;
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

                #region Player Boundaries
                if ((player.position.Y) <= 0)
                {
                    player.position.Y = 0;
                }
                if ((player.position.X) <= 0)
                {
                    player.position.X = 0;
                }
                if ((player.position.X) >= 778)
                {
                    player.position.X = 778;
                }
                if ((player.position.Y) >= 448)
                {
                    player.position.Y = 448;
                }

                #endregion

                #region Race Selection
                if ((mousepos.X < 50 && mousepos.X > 0 && mousepos.Y < 50 && mousepos.Y > 0) && mouseState.LeftButton == ButtonState.Pressed)
                {
                   Races.human = true;
                   Races.plantrace = false;
                   Races.sharkperson = false;
                   Races.lockedRaces.android = false;
                   Races.lockedRaces.developer = false;
                   Races.lockedRaces.dolphin = false;
                   Races.lockedRaces.timeLord = false;
                }
                if ((mousepos.X < 100 && mousepos.X > 50 && mousepos.Y < 100 && mousepos.Y > 50) && mouseState.LeftButton == ButtonState.Pressed)
                {

                    Races.human = false;
                    Races.plantrace = true;
                    Races.sharkperson = false;
                    Races.lockedRaces.android = false;
                    Races.lockedRaces.developer = false;
                    Races.lockedRaces.dolphin = false;
                    Races.lockedRaces.timeLord = false;
                }
                if ((mousepos.X < 100 && mousepos.X > 50 && mousepos.Y < 100 && mousepos.Y > 50) && mouseState.LeftButton == ButtonState.Pressed)
                {

                    Races.human = false;
                    Races.plantrace = true;
                    Races.sharkperson = false;
                    Races.lockedRaces.android = false;
                    Races.lockedRaces.developer = false;
                    Races.lockedRaces.dolphin = false;
                    Races.lockedRaces.timeLord = false;
                }
                #endregion

                #region Developer Stuff
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

                #region Timelord Stuff
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
                #endregion

                if (state.IsKeyDown(Keys.U))
                {
                    tortoiseHealth =  tortoiseHealth - WeaponStats.damagePerAttack;
                }
                if ((tortoiseHealth) <= 0)
                {
                    tortoiseHealth = 0;
                }
                if (state.IsKeyDown(Keys.End))
                {
                    Creatures.stats.goosehealth = 0;
                }
                #endregion

                #region HMS Stuff

                if (Bosses.BossStats.HugeassMechanicalSharkHealth <= 0)
                {
                    Bosses.BossStats.HugeassMechanicalSharkHealth = 0;
                }
                if (Bosses.BossStats.HugeassMechanicalSharkHealth == 0)
                {
                    Bosses.BossStats.HugeassMechanicalSharkDefeats = Bosses.BossStats.HugeassMechanicalSharkDefeats + 1;
                    sharkhealthtemp = 1;
                }

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
            //spriteBatch.DrawString(font, "FPS: " + frameRate, new Vector2(300, 30), Color.Black);
            spriteBatch.DrawString(font, "Health:  " + playerHealth, new Vector2(300, 55), Color.Black);
            if (Achievements.lockedAchievements.lachvLordofTime == true)
            {
                spriteBatch.DrawString(font, "Timelord Lives: " + timeLordLives, new Vector2(300, 80), Color.Black);
            }
            spriteBatch.Draw(blacktile, new Vector2(490, 240), Color.White);
            if ((tortoiseHealth) > 0)
            {
                spriteBatch.Draw(Creatures.textures.tortoise, tortoisePosition, Color.White);
            }
            spriteBatch.Draw(Creatures.textures.goose_body, Creatures.positions.goosepos, Color.White);
            if ((Creatures.stats.goosehealth) == 100)
            {
                spriteBatch.Draw(Creatures.textures.goose_head, Creatures.positions.goosepos, Color.White);
            }
            spriteBatch.Draw(Creatures.textures.goose_rainbow, new Vector2(400, 150), Color.White);
            spriteBatch.Draw(raceSelect, new Vector2(0, 0), Color.White);
            spriteBatch.Draw(player.texture, player.position, Color.White);
            if (Races.human == true)
            {
                spriteBatch.Draw(player.texture, player.position, Color.White);
            }
            if (Races.sharkperson == true)
            {
                spriteBatch.Draw(Races.sharkpersonsprite, player.position, Color.White);
            }
            if (Races.plantrace == true)
            {
                spriteBatch.Draw(Races.plantracesprite, player.position, Color.White);
            }
            /*if (paused == true)
            {
             * 
                spriteBatch.Draw(background, new Rectangle(0, 0, 800, 480), Color.Black * 0.5f);
            }
             */
            base.Draw(gameTime);
            spriteBatch.End();
            if (state.IsKeyDown(Keys.D1))
            {
                spriteBatch.Begin(SpriteSortMode.Immediate, BlendState.Additive);
                spriteBatch.Draw(Items.misc.penguin_paint_red, new Vector2(500, 250), Color.White);
                spriteBatch.End();
            }
             if (state.IsKeyDown(Keys.D2))
             {
                spriteBatch.Begin(SpriteSortMode.Immediate, BlendState.Additive);
                spriteBatch.Draw(Items.misc.penguin_paint_blue, new Vector2(500, 250), Color.White);
                spriteBatch.End();
             }
             if (state.IsKeyDown(Keys.D3))
             {
                spriteBatch.Begin(SpriteSortMode.Immediate, BlendState.Additive);
                spriteBatch.Draw(Items.misc.penguin_paint_yellow, new Vector2(500, 250), Color.White);
                spriteBatch.End();
             }
        }


    }
}