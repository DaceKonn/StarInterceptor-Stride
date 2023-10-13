using StarInterceptor.Core;
using Stride.Core.Mathematics;
using Stride.Engine;
using Stride.Engine.Design;
using Stride.Input;
using Stride.Particles;
using Stride.Particles.Components;
using Stride.Physics;
using System.Diagnostics.Eventing.Reader;

namespace StarInterceptor.Controllers
{
    [ComponentCategory("Controllers")]
    public class MouseFollowController : SyncScript
    {
        public bool Enabled;

        // Declared public member fields and properties will show in the game studio
        public Speed Speed = new Speed(7f, 1f);
        public float MouseSensitivity = 10.0f;

        private Vector3 _moveVector = new Vector3(0, 0, 0);

        private GameConfiguration _gameConfiguration;
        private CharacterComponent _characterComponent;
        private ParticleSystemComponent _leftStrafeParticles;
        private ParticleSystemComponent _rightStrafeParticles;

        public override void Start()
        {
            _gameConfiguration = Services.GetService<IGameSettingsService>()?.Settings.Configurations.Get<GameConfiguration>() ?? new GameConfiguration();
            _characterComponent = Entity.Components.Get<CharacterComponent>();
            _leftStrafeParticles = Entity.FindChild("Left strafe").Components.Get<ParticleSystemComponent>();
            _rightStrafeParticles = Entity.FindChild("Right strafe").Components.Get<ParticleSystemComponent>();


        }

        public override void Update()
        {
            if (!Enabled) return;

            //DebugText.Print("speed: " + Speed.ToString(), new Int2(400, 400));

            if (Input.HasMouse)
            {

                if (Input.Mouse.IsPositionLocked)
                {
                    //ResetPosition();

                    float directionX = 0.0f;
                    float directionY = 0.0f;
                    ReadInputDirections(ref directionX, ref directionY);

                    float deltaTime = (float)Game.UpdateTime.Elapsed.TotalSeconds;
                    CalculateMoveVector(directionX, directionY);
                    UpdateEntityVelocity(deltaTime);
                    UpdateEntityRotation(deltaTime);
                    StrafeEngines();

                }

            }


        }

        private void UpdateEntityRotation(float deltaTime)
        {
            var rotationDirection = -_moveVector.X;
            AngleSingle angleSingle = new AngleSingle(10f * rotationDirection, AngleType.Degree);

            Entity.Transform.Rotation = Quaternion.RotationZ(angleSingle.Radians);
            Entity.Transform.Position.Y = 0.0f;
            _characterComponent.UpdatePhysicsTransformation();

        }

        private void StrafeEngines()
        {
            if (_moveVector.X > 0)
            {
                _leftStrafeParticles.ParticleSystem.Play();
                _rightStrafeParticles.ParticleSystem.StopEmitters();
            } else if (_moveVector.X < 0)
            {
                _leftStrafeParticles.ParticleSystem.StopEmitters();
                _rightStrafeParticles.ParticleSystem.Play();
            } else
            {
                _leftStrafeParticles.ParticleSystem.StopEmitters();
                _rightStrafeParticles.ParticleSystem.StopEmitters();
            }
        }

        private void UpdateEntityVelocity(float deltaTime)
        {
            var velocity = new Vector3(_moveVector.X * Speed.StrafeSpeed, _moveVector.Y, _moveVector.Z * Speed.ForwardSpeed) * deltaTime;
            _characterComponent.SetVelocity(velocity);
        }

        private void CalculateMoveVector(float directionX, float directionY)
        {
            _moveVector += new Vector3(directionX, 0.0f, directionY);
            if (_moveVector.X < -1.0f) { _moveVector.X = -1f; }
            if (_moveVector.X > 1.0f) { _moveVector.X = 1f; }
            if (_moveVector.Z < -1.0f) { _moveVector.Z = -1f; }
            if (_moveVector.Z > 1.0f) { _moveVector.Z = 1f; }
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

        
    }
}
