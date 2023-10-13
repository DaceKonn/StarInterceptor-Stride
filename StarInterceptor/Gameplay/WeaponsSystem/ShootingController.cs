using StarInterceptor.Gameplay;
using Stride.Core.Mathematics;
using Stride.Engine;
using Stride.Input;
using System.Linq;

namespace StarInterceptor.Gameplay.WeaponsSystem
{
    [ComponentCategory("WeaponsSystem")]
    public class ShootingController : SyncScript
    {

        public override void Start()
        {
            // Initialization of the script.
        }

        public override void Update()
        {
            if (IfShooting())
            {
                ShipWeaponsEventRegistry.ShipWeaponsFiredEvent.Broadcast(WeaponSlot.Main);
            }
        }

        private bool IfShooting()
        {
            return Input.HasMouse && (Input.Mouse.IsButtonDown(MouseButton.Left) || Input.Mouse.IsButtonPressed(MouseButton.Left));
        }
    }
}
