using System;
using System.Numerics;
using Byui.Games.Casting;
using Byui.Games.Scripting;
using Byui.Games.Services;


namespace Final.Project
{
    /// <summary>
    /// Steers an actor in a direction corresponding to keyboard input. Note, this does not update 
    /// the actor's position, just steers it in a certain direction. See MoveActorAction to see how
    /// the actor's position is actually updated.
    /// </summary>
    public class SteerActorAction : Byui.Games.Scripting.Action
    {
        private IKeyboardService _keyboardService;
        private IAudioService _audioService;
        private ISettingsService _settingsService;
        

        public SteerActorAction(IServiceFactory serviceFactory)
        {
            _keyboardService = serviceFactory.GetKeyboardService();
            _audioService = serviceFactory.GetAudioService();
            _settingsService = serviceFactory.GetSettingsService();
        }

        public override void Execute(Scene scene, float deltaTime, IActionCallback callback)
        {
            try
            {

                Image actor = (Image)scene.GetFirstActor("actors");
                Vector2 current_velocity = actor.GetVelocity();

                int maxSpeed = 10;
                int gravity = 1;


                // declare direction variables
                int directionX = 0;
                int directionY = 0;

                // determine vertical or y-axis direction
                // if (_keyboardService.IsKeyDown(KeyboardKey.W))
                // {
                //     directionY += -1;
                // }
                if (_keyboardService.IsKeyDown(KeyboardKey.S))
                {
                    directionY += 1;
                }
                

                // determine horizontal or x-axis direction
                if (_keyboardService.IsKeyDown(KeyboardKey.A))
                {
                    directionX += -1;
                    int framesPerSecond = 60;
                    float durationInSeconds = 0.2f;
                    string[] filePathsWalkL = new string[3];
                    filePathsWalkL[0] = "Assets/JumpL (1).png";
                    filePathsWalkL[1] = "Assets/JumpL (2).png";
                    filePathsWalkL[2] = "Assets/JumpL (3).png";
                    actor.Animate(filePathsWalkL,durationInSeconds,framesPerSecond);
                }
                else if (_keyboardService.IsKeyDown(KeyboardKey.D))
                {
                    directionX += 1;
                    int framesPerSecond = 60;
                    float durationInSeconds = 0.2f;
                    string[] filePathsWalkR = new string[3];
                    filePathsWalkR[0] = "Assets/Jump (1).png";
                    filePathsWalkR[1] = "Assets/Jump (2).png";
                    filePathsWalkR[2] = "Assets/Jump (3).png";
                    actor.Animate(filePathsWalkR,durationInSeconds,framesPerSecond);
                }
                else if (current_velocity.X != 0)
                {
                    directionX -= Math.Sign(current_velocity.X);
                }

                if (_keyboardService.IsKeyDown(KeyboardKey.Space) && actor.isGrounded)
                {      
                    directionY += -22;
                    actor.isGrounded = false;
                    // string bounceSound = _settingsService.GetString("bounceSound");
                    // _audioService.PlaySound(bounceSound);        
                    float durationInSeconds = 0.2f;
                    int framesPerSecond = 60;
                    string[] filePathsJump = new string[3];
                    filePathsJump[0] = "Assets/Jump (1).png";
                    filePathsJump[1] = "Assets/Jump (2).png";
                    filePathsJump[2] = "Assets/Jump (3).png";
                    actor.Animate(filePathsJump,durationInSeconds,framesPerSecond);
                    string bounceSound = _settingsService.GetString("bounceSound");
                    _audioService.PlaySound(bounceSound);

                }

                if (_keyboardService.IsKeyReleased(KeyboardKey.Space)) {
                    float durationInSeconds = 0.4f;
                    int framesPerSecond = 60;
            string[] filePaths = new string[4];
            filePaths[0] = "Assets/idle (1).png";
            filePaths[1] = "Assets/idle (2).png";
            filePaths[2] = "Assets/idle (3).png";
            filePaths[3] = "Assets/idle (4).png";
            actor.Animate(filePaths,durationInSeconds,framesPerSecond);
                }
                 if (_keyboardService.IsKeyReleased(KeyboardKey.D)) {
                    float durationInSeconds = 0.4f;
                    int framesPerSecond = 60;
            string[] filePaths = new string[4];
            filePaths[0] = "Assets/idle (1).png";
            filePaths[1] = "Assets/idle (2).png";
            filePaths[2] = "Assets/idle (3).png";
            filePaths[3] = "Assets/idle (4).png";
            actor.Animate(filePaths,durationInSeconds,framesPerSecond);
                }

                 if (_keyboardService.IsKeyReleased(KeyboardKey.A)) {
                    float durationInSeconds = 0.4f;
                    int framesPerSecond = 60;
            string[] filePaths = new string[4];
            filePaths[0] = "Assets/idle (1).png";
            filePaths[1] = "Assets/idle (2).png";
            filePaths[2] = "Assets/idle (3).png";
            filePaths[3] = "Assets/idle (4).png";
            actor.Animate(filePaths,durationInSeconds,framesPerSecond);
                }
                //add gravity
                {
                    directionY += gravity;
                }

                // steer the actor in the desired direction
                
                
                Vector2 newVelocity = current_velocity + new Vector2(directionX, directionY);
                newVelocity.X = Math.Clamp(newVelocity.X,  -maxSpeed, maxSpeed);

                actor.Steer(newVelocity);
            }
            catch (Exception exception)
            {
                callback.OnError("Couldn't steer actor.", exception);
            }
        }
    }
}