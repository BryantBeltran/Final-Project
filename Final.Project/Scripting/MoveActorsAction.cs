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
    public class MoveActorAction : Byui.Games.Scripting.Action
    {
        private IKeyboardService _keyboardService;

        public MoveActorAction(IServiceFactory serviceFactory)
        {
            _keyboardService = serviceFactory.GetKeyboardService();
        }

        public override void Execute(Scene scene, float deltaTime, IActionCallback callback)
        {
            try
            {
                // get the actors from the scene
                Actor actor = scene.GetFirstActor("actors");
                Actor screen = scene.GetFirstActor("screen");
                
                // move the actor and restrict it to the screen boundaries
<<<<<<< HEAD
                actor.Move(35); // use a constant pull of 5 in the downward direction
=======
                MovePlayer(actor, scene);

>>>>>>> 1de71cff9abcc213b0a3d9ce53f0d8b8e7181835
                actor.ClampTo(screen); // keep actor inside screen.

            }
            catch (Exception exception)
            {
                callback.OnError("Couldn't move actor.", exception);
            }
        }

        private void MoveGround(Actor actor)
        {
            actor.Move();
        }

        private void MovePlayer(Actor actor, Scene scene) 
        {

            Vector2 change = actor.GetVelocity();
            MoveX(actor, change.X, scene.GetAllActors("actors"));
            MoveY(actor, change.Y, scene.GetAllActors("solids"));

        }
        private void MoveX(Actor actor, float change, List<Actor> solids)
        {
            int move = Convert.ToInt32(Math.Round(change));

            int sign = Math.Sign(move);

            while (move != 0)
            {
                if (!CheckCollision(solids, actor.GetPosition() + new Vector2 (sign, 0)))
                {
                    actor.MoveTo(actor.GetPosition() + new Vector2 (sign, 0));
                    move -= sign;
                }
                else
                {
                    break;
                }
            }
        }

        private void MoveY(Actor actor, float change, List<Actor> solids)
        {
            int move = Convert.ToInt32(Math.Round(change));

            int sign = Math.Sign(move);

            while (move != 0)
            {
                if (!CheckCollision(solids, actor.GetPosition() + new Vector2 (0, sign)))
                {
                    actor.MoveTo(actor.GetPosition() + new Vector2 (0, sign));
                    move -= sign;
                }
                else
                {
                    break;
                }
            }
        }

        private bool CheckCollision(List<Actor> actors, Vector2 point)
        {

            foreach (Actor item in actors)
            {
                if (item.Overlaps(point))
                {
                    return true;
                }
            }
            return false;
        }
    }
}