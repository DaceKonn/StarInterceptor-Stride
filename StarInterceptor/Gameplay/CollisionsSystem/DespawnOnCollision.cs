using StarInterceptor.Core;
using StarInterceptor.Gameplay.ShipDamageSystem;
using Stride.Engine;
using Stride.Physics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarInterceptor.Gameplay.CollisionsSystem
{
    [ComponentCategory("CollisionsSystem")]
    public class DespawnOnCollision : AsyncScript
    {
        public CollisionFilterGroupFlags DespawnOnCollisionWith { get; set; }

        public override async Task Execute()
        {
            var _physicsComponent = Entity.Get<PhysicsComponent>();

            while (Game.IsRunning)
            {
                // Wait for the next collision event
                var firstCollision = await _physicsComponent.NewCollision();

                // Filter collisions based on collision groups
/*                var filterAhitB = ((int)firstCollision.ColliderA.CanCollideWith) & ((int)firstCollision.ColliderB.CollisionGroup);
                var filterBhitA = ((int)firstCollision.ColliderB.CanCollideWith) & ((int)firstCollision.ColliderA.CollisionGroup);

                //Log.Info($"Collider A: {firstCollision.ColliderA.Entity.Name} ; Collider B: {firstCollision.ColliderB.Entity.Name}");

                if (filterAhitB == 0 || filterBhitA == 0)
                    continue;*/

                var collisionGroup = firstCollision.ColliderA.Entity == Entity ? firstCollision.ColliderB.CollisionGroup : firstCollision.ColliderA.CollisionGroup;

                if (((int)DespawnOnCollisionWith & (int)collisionGroup) != 0)
                {
                    Game.RemoveEntity(Entity);
                }
               
            }
        }
    }
}
