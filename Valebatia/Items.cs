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
    public class Items : Microsoft.Xna.Framework.GameComponent
    {
        // Types Go Here
        public class misc {
                public static Texture2D circuit_chameleon;
                public static Texture2D penguin_paint_red;
                public static Texture2D penguin_paint_blue;
                public static Texture2D penguin_paint_yellow;
                public static Texture2D moustache_pencil;
        }
        public class tools {
            public class axes {
                public static Texture2D copper;
                public static Texture2D steel;
                public static Texture2D iron;
                public static Texture2D jade;
                public static Texture2D dragon;
            }
            public class pickaxes {
                public static Texture2D copper;
                public static Texture2D steel;
                public static Texture2D iron;
                public static Texture2D jade;
                public static Texture2D dragon;
            }
        }
        public class weapons {
            public class ammunition {
                public static Texture2D arrow_wood;
                public static Texture2D arrow_steel;
                public static Texture2D arrow_joke;
                public static Texture2D arrow_rubberduck;
                public static Texture2D arrow_uranium;
                public static Texture2D arrow_plutonium;
            }
            public class swords {
                public static Texture2D copper;
                public static Texture2D iron;
                public static Texture2D steel;
                public static Texture2D jade;
                public static Texture2D dragon;
            }
            public class misc {
                public static Texture2D schwabbicus_gavel;
                public static Texture2D skewer_katlyn;
                public static Texture2D big_zappy_thing;
                public static Texture2D doomsday_ignitous;
            }
            public class ranged {
                public class bows {
                    public static Texture2D longbow;
                    public static Texture2D crossbow;
                    public static Texture2D recurvebow;
                }
                public class launchers {
                    public static Texture2D grenade_mk1;
                    public static Texture2D grenade_mk2;
                    public static Texture2D grenade_mk3;
                    public static Texture2D rocket_mk1;
                    public static Texture2D rocket_mk2;
                    public static Texture2D rocket_mk3;
                }
                public class guns {
                    public static Texture2D rifle_assault;
                    public static Texture2D rifle_sniper;
                    public static Texture2D rifle_carbine;
                    public static Texture2D shotgun;
                    public static Texture2D hk_mathus;
                }
                public class super {
                    public static Texture2D deathray_pinecone;
                    public static Texture2D mg_paperairplane;

                }
            }
            public class explosive {
                public static Texture2D bomb;
                public static Texture2D grenade;
                public static Texture2D nuke;

            }

        }
        public class consumables
        {
            public class foods {
                // Meats
                public static Texture2D beef_uncooked;
                public static Texture2D beef_cooked;
                public static Texture2D chicken_uncooked;
                public static Texture2D chicken_cooked;
                public static Texture2D pork_uncooked;
                public static Texture2D pork_cooked;
                public static Texture2D lobster_uncooked;
                public static Texture2D lobster_cooked;
                public static Texture2D duck_uncooked;
                public static Texture2D duck_cooked;
                // Fruits
                public static Texture2D apple;
                public static Texture2D pear;
                public static Texture2D watermelon;
                // Drinks
                public static Texture2D rum;
                public static Texture2D rum_aged;
                public static Texture2D coffee;
                public static Texture2D coffee_dark;
                public static Texture2D coffee_cold;
                // Stuff That Will Injure You If Consumed
                public static Texture2D pepper_ghost;
                public static Texture2D pepper_carolina_reaper;
                public static Texture2D pepper_jalapeno;
                public static Texture2D pepper_death;
            }
            public class potions {
                public static Texture2D empty_bottle;
                public static Texture2D bottle_blue;
                public static Texture2D bottle_green;
                public static Texture2D bottle_red;
            }
        }

        public Items(Game game): base(game){} 
        public override void Initialize() { base.Initialize(); }
        public override void Update(GameTime gameTime) { base.Update(gameTime); }
    }
}
