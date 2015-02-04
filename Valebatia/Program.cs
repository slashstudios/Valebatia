using System;

namespace Valebatia
{
#if WINDOWS || XBOX
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        static void Main(string[] args)
        {
            using (Valebatia game = new Valebatia())
            {
                game.Run();
            }
        }
    }
#endif
}

