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
    public class Quests : Microsoft.Xna.Framework.GameComponent
    {
        public class items
        {
            // Lord of Time Quest
            public static Texture2D blueboxmanual;
            public static string blueboxmanualdescc = "The Instruction Manual for the Blue Box";
            public static Texture2D blueboxkeys;
            public static string blueboxkeysdesc = "Keys for the Blue Box.";
            // Echolocation Quest
            public static Texture2D echo_cannon;
            public static string echo_cannon_desc = "A cannon that appears to shoot sound waves.";
            public static Texture2D echo_microphone;
            public static string echo_microphone_desc = "A microphone.";
            public static Texture2D echo_amplifier;
            public static string echo_amplifier_desc = "An amplifier.";
            public static Texture2D echo_cabling;
            public static string echo_cabling_desc = "A bundle of cabling.";
            // Wrath of the Trench Quest
            public static Texture2D trench_sub_parts_1;
            public static string trenchsubparts1desc = "A hatch for a submarine.";
            public static Texture2D trench_sub_parts_2;
            public static string trenchsubparts2desc = "An engine for a submarine.";
            public static Texture2D trench_sub_parts_3;
            public static string trenchsubparts3desc = "Scrap metal. This could be used to make a submarine.";
            public static Texture2D trench_sub_parts_4;
            public static string trenchsubparts4desc = "Some torpedoes. Don't drop them!";
            public static Texture2D trench_sub_parts_5;
            public static string trenchsubparts5 = "A tube of high-quality waterproof sealant.";
            public static Texture2D trench_sub;
            public static string trenchsubdesc = "A submarine. Could be used for aquatic travel.";

        }
        public Quests(Game game)
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
