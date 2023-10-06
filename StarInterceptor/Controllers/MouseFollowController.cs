using StarInterceptor.Core;
using Stride.Core.Mathematics;
using Stride.Engine;
using Stride.Engine.Design;
using Stride.Input;
using Stride.Physics;

namespace StarInterceptor.Controllers
{
    public class MouseFollowController : SyncScript
    {
        public bool Enabled;

        // Declared public member fields and properties will show in the game studio
        public Speed Speed = new Speed(7f, 1f);
        public float MouseSensitivity = 10.0f;

        Vector3 moveVector = new Vector3(0, 0, 0);

        private GameConfiguration GameConfiguration;
        private CharacterComponent characterComponent;

        public override void Start()
        {
            GameConfiguration = Services.GetService<IGameSettingsService>()?.Settings.Configurations.Get<GameConfiguration>() ?? new GameConfiguration();
            characterComponent = Entity.Components.Get<CharacterComponent>();

        }

        public override void Update()
        {
            if (!Enabled) return;

            //DebugText.Print("speed: " + Speed.ToString(), new Int2(400, 400));

            if (Input.HasMouse)
            {
                MousetLocking();

                if (Input.Mouse.IsPositionLocked)
                {
                    //ResetPosition();

                    float directionX = 0.0f;
                    float directionY = 0.0f;
                    ReadInputDirections(ref directionX, ref directionY);

                    float deltaTime = (float)Game.UpdateTime.Elapsed.TotalSeconds;
                    CalculateMoveVector(directionX, directionY);

                    /*DebugText.Print("moveVector: " + moveVector.ToString(), new Int2(50, 350));
                    DebugText.Print("mouse-delta: " + Input.MouseDelta.ToString(), new Int2(50, 400));
                    DebugText.Print("mouse-position: " + Input.MousePosition.ToString(), new Int2(50, 50));
                    DebugText.Print("ship position: " + Entity.Transform.Position.ToString(), new Int2(50, 100));*/
                    //127.27922
                    //UpdateEntityPosition(deltaTime);
                    UpdateEntityVelocity(deltaTime);
                    UpdateEntityRotation(deltaTime);
                }

            }


        }

        private void UpdateEntityRotation(float deltaTime)
        {
            var rotationDirection = -moveVector.X;
            AngleSingle angleSingle = new AngleSingle(90f * rotationDirection, AngleType.Degree);

            Entity.Transform.Rotation = Quaternion.RotationZ(angleSingle.Radians);
            characterComponent.UpdatePhysicsTransformation();

        }

        private void ResetPosition()
        {
            if (Input.HasKeyboard)
            {
                if (Input.IsKeyPressed(Keys.R))
                {
                    Entity.Transform.Position = new Vector3(0, 0.5f, 0);
                }
            }
        }

        private void UpdateEntityPosition(float deltaTime)
        {
            var currentEntityPosition = Entity.Transform.Position;
            var newEntityPosition = currentEntityPosition + new Vector3(moveVector.X * Speed.StrafeSpeed, moveVector.Y, moveVector.Z * Speed.ForwardSpeed) * deltaTime;

            if (newEntityPosition.Z > 3)
            {
                newEntityPosition.Z = 3;
            }
            else if (newEntityPosition.Z < 3 - GameConfiguration.FieldRestrictions.Y)
            {
                newEntityPosition.Z = 3 - GameConfiguration.FieldRestrictions.Y;
            }

            if (newEntityPosition.X > GameConfiguration.FieldRestrictions.X)
            {
                newEntityPosition.X = GameConfiguration.FieldRestrictions.X;
            }
            else if (newEntityPosition.X < -GameConfiguration.FieldRestrictions.X)
            {
                newEntityPosition.X = -GameConfiguration.FieldRestrictions.X;
            }

            //DebugText.Print("move vector: " + moveVector.ToString(), new Int2(50, 250));

            Entity.Transform.Position = newEntityPosition;
        }

        private void UpdateEntityVelocity(float deltaTime)
        {
            var velocity = new Vector3(moveVector.X * Speed.StrafeSpeed, moveVector.Y, moveVector.Z * Speed.ForwardSpeed) * deltaTime;
/*            if (Entity.Transform.Position.Z > 3 && velocity.Z > 0)
            {
                velocity.Z = 0f;
            }
            else if (Entity.Transform.Position.Z < 3 - GameConfiguration.FieldRestrictions.Y && velocity.Z < 0)
            {
                velocity.Z = 0f;
            }*/

/*            if (Entity.Transform.Position.X > GameConfiguration.FieldRestrictions.X && velocity.X > 0f)
            {
                velocity.X = 0f;
            }
            else if (Entity.Transform.Position.X < -GameConfiguration.FieldRestrictions.X && velocity.X < 0f)
            {
                velocity.X = 0f;
            }*/

            characterComponent.SetVelocity(velocity);
        }

        private void CalculateMoveVector(float directionX, float directionY)
        {
            moveVector += new Vector3(directionX, 0.0f, directionY);
            if (moveVector.X < -1.0f) { moveVector.X = -1f; }
            if (moveVector.X > 1.0f) { moveVector.X = 1f; }
            if (moveVector.Z < -1.0f) { moveVector.Z = -1f; }
            if (moveVector.Z > 1.0f) { moveVector.Z = 1f; }
        }

        private void ReadInputDirections(ref float directionX, ref float directionY)
        {
            if (Input.MouseDelta.X * MouseSensitivity <= 1f && Input.MouseDelta.X * MouseSensitivity >= -1f)
            {
                directionX = Input.MouseDelta.X * MouseSensitivity;
            }
            else if (Input.MouseDelta.X * MouseSensitivity > 1f)
            {
                directionX = 1f;
            }
            else if (Input.MouseDelta.X * MouseSensitivity < -1f)
            {
                directionX = -1f;
            }


            if (Input.MouseDelta.Y * MouseSensitivity <= 1f && Input.MouseDelta.Y * MouseSensitivity >= -1f)
            {
                directionY = Input.MouseDelta.Y * MouseSensitivity;
            }
            else if (Input.MouseDelta.Y * MouseSensitivity > 1f)
            {
                directionY = 1f;
            }
            else if (Input.MouseDelta.Y * MouseSensitivity < -1f)
            {
                directionY = -1f;
            }
        }

        private void MousetLocking()
        {
            if (Input.IsMouseButtonDown(MouseButton.Left))
            {
                Input.LockMousePosition(true);
                Game.IsMouseVisible = false;
            }
            if (Input.IsKeyPressed(Keys.Escape))
            {
                Input.UnlockMousePosition();
                Game.IsMouseVisible = true;
            }
        }
    }
}
