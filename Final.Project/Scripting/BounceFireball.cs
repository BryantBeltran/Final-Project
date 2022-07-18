using System;
using System.Numerics;
using Byui.Games.Casting;
using Byui.Games.Scripting;
using Byui.Games.Services;


namespace Final.Project
{
    /// <summary>
    /// Moves the actors and clamps them to the screen boundaries. The call to actor.Move() is what updates
    /// their position on the screen.
    /// </summary>
    public class BounceFireball : Byui.Games.Scripting.Action
    {
        Image actor = (Image)scene.GetFirstActor("actors");
        Image fireballs = (Image )scene.GetFirstActor("enemies");
        Actor screen = scene.GetFirstActor("screen");
        List<Actor> fireballs = scene.GetAllActors("fireballs");
    }


    public override void Execute(Scene scene, float deltaTime, IActionCallback callback)
        {  

            try
            {
                Random rnd = new Random();
                int numx = rnd.Next(100, 600);
                int numy = rnd.Next(50, 1200);
                // Actor actor = scene.GetFirstActor("actors");
                Image actor = (Image) scene.GetFirstActor("actors");
                foreach (Actor fireball in scene.GetAllActors("fireballs"))
                {
                    if (actor.Overlaps(fireball))
                    {
                    fireball.MoveTo(numy, numx); 
                    ShootFireballsAction.FireRate =ShootFireballsAction.FireRate - 10;
                    ShootFireballsAction.numFireballs = ShootFireballsAction.numFireballs + 1;
                    // Tell it to randomly move to a location on the screen.
                    }
                }
                foreach (Actor fireball in scene.GetAllActors("fireballs"))
                {
                    if (actor.Overlaps(fireball))
                    { 
                        callback.OnStop();
                    }
                

                }
            }
            catch (Exception exception)
            {
                callback.OnError("Couldn't move actor.", exception);
            }
        }
}