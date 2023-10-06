using Stride.Core.Mathematics;
using Stride.Engine;
using Stride.Input;

namespace StarInterceptor.Controllers
{
    public class ShootingController : SyncScript
    {

        public bool Enabled { get; set; }
        public Prefab Bullet { get; set; }

        public float TimerDelay = 0.2f;


        private float Timer = 0.0f;
        // Declared public member fields and properties will show in the game studio

        public override void Start()
        {
            // Initialization of the script.
        }

        public override void Update()
        {
            
            if (Enabled)
            {
                if (Timer > 0.0f)
                {
                    Timer -= (float)Game.UpdateTime.Elapsed.TotalSeconds;
                    return;
                }

                if (IfShooting())
                {
                    SpawnBullets();
                }
            }
            

            // Do stuff every new frame
        }


        private void SpawnBullets()
        {

            var entity = Bullet.Instantiate()[0];
            entity.Transform.Position = Entity.Transform.Position + new Vector3(0f, 0.5f, -0.2f);
            Entity.Scene.Entities.Add(entity);
            Timer = TimerDelay;

        }

        private bool IfShooting()
        {
            return Input.HasMouse && (Input.Mouse.IsButtonDown(MouseButton.Left) || Input.Mouse.IsButtonPressed(MouseButton.Left));
        }
    }
}
