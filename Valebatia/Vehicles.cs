using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;


namespace Valebatia
{
    public class Vehicles : Microsoft.Xna.Framework.GameComponent
    {
        public class jets { }
        public class planes { }
        public class cars { }
        public class offroad { }
        public class underwater { }
        public class space { }

        #region Trash
        public Vehicles(Game game)
            : base(game) { }

        public override void Initialize() { base.Initialize(); }

        public override void Update(GameTime gameTime) { base.Update(gameTime); }
    }
        #endregion
}
