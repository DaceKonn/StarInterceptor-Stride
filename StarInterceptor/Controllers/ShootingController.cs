using StarInterceptor.Gameplay;
using Stride.Core.Mathematics;
using Stride.Engine;
using Stride.Input;
using System.Linq;

namespace StarInterceptor.Controllers
{
    [ComponentCategory("Controllers")]
    public class ShootingController : SyncScript
    {

        public bool Enabled { get; set; }
        public ShipState ShipState { get; set; }


        private float _timer = 0.0f;
        // Declared public member fields and properties will show in the game studio

        public override void Start()
        {
            // Initialization of the script.
        }

        public override void Update()
        {
            
            if (Enabled)
            {
                if (_timer > 0.0f)
                {
                    _timer -= (float)Game.UpdateTime.Elapsed.TotalSeconds;
                    return;
                }

                if (IfShooting() && ShipState.Weapons.Any() && _timer <= 0.0f)
                {
                    SpawnBullets();
                }
            }
            

            // Do stuff every new frame
        }


        private void SpawnBullets()
        {

            var entity = ShipState.Weapons[0].Weapon.Bullet.Instantiate()[0];
            entity.Transform.Position = Entity.Transform.Position + new Vector3(0f, 0.5f, -0.2f);
            Entity.Scene.Entities.Add(entity);
            _timer = ShipState.Weapons[0].Weapon.BaseDelay;

        }

        private bool IfShooting()
        {
            return Input.HasMouse && (Input.Mouse.IsButtonDown(MouseButton.Left) || Input.Mouse.IsButtonPressed(MouseButton.Left));
        }
    }
}
