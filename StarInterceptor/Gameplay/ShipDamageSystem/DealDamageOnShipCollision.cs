using Stride.Engine;
using Stride.Physics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarInterceptor.Gameplay.ShipDamageSystem
{
    [ComponentCategory("ShipDamageSystem")]
    public class DealDamageOnShipCollision : AsyncScript
    {
        public override async Task Execute()
        {
            var _physicsComponent = Entity.Get<PhysicsComponent>();
            var _damageOnImpactState = Entity.Get<DamageOnImpactState>();

            while (Game.IsRunning)
            {
                // Wait for the next collision event
                var firstCollision = await _physicsComponent.NewCollision();

                var collidedEntity = firstCollision.ColliderA.Entity == Entity ? firstCollision.ColliderB.Entity : firstCollision.ColliderA.Entity;

                if (collidedEntity.Name == "Spaceship")
                {
                    ShipDamageEventRegistry.DamageToApplyEventKey.Broadcast(_damageOnImpactState.Damage);
                }

                

            }
        }
    }
}
