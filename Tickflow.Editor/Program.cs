﻿using System;

namespace Tickflow.Editor
{
    public static class Program
    {
        [STAThread]
        static void Main()
        {
            using (var game = new TickflowEditor())
            {
                game.Run();
            }
        }
    }
}