using CyllianMonoGame.Other.Camera;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CyllianMonoGame.Config
{
    public static class Global
    {
        public static int Spritesize = 48;

        public static Boolean Debugmode = true; //While in develop, this is usally on

        public static Camera Camera = new Camera();

        public static Vector2 GlobalPosition = new Vector2(0, 0);
    }
}
