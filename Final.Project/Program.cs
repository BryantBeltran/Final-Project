using System;
using Byui.Games.Casting;
using Byui.Games.Directing;
using Byui.Games.Scripting;
using Byui.Games.Services;

namespace Final
{
    public class Program
    {
        static void Main(string[] args)
        {
            Director director = new Director(SceneManager.VideoService);
            director.StartGame();
        }
    }
}
