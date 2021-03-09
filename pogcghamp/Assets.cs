using System;
using System.Collections.Generic;
using System.Text;
using Raylib_cs;

namespace pogcghamp
{
    public class Assets
    {
        public static Texture2D xhair;

        public static void LoadAssets()
        {
            xhair = Raylib.LoadTexture("./textures/xhair.png");
        }
    }
}
