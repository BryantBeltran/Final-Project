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
        
    


        public override void Execute(Scene scene, float deltaTime, IActionCallback callback)
            {  
                Image actor = (Image)scene.GetFirstActor("actors");
                Actor screen = scene.GetFirstActor("screen");
                List<Actor> fireballs = scene.GetAllActors("fireballs");
                List<Actor> platforms = scene.GetAllActors("platforms");


                try
                {
                    foreach (Actor fireball in fireballs)
                    {
                        foreach (Actor platform in platforms)
                        {
                            if (fireball.Overlaps(platform))
                            {
                                
                            
                            }
                        }
                    }
                }
                catch (Exception exception)
                {
                    callback.OnError("Couldn't move actor.", exception);
                }
            }
    }
}