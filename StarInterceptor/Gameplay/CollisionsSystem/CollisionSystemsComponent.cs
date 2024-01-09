using StarInterceptor.Core;
using Stride.Core;
using Stride.Core.Annotations;
using Stride.Core.Collections;
using Stride.Engine;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static BulletSharp.Dbvt;

namespace StarInterceptor.Gameplay.CollisionsSystem
{
    [ComponentCategory("CollisionsSystem")]
    public class CollisionSystemsComponent : AsyncScript
    {
        [DataMember(200)]
        [Category]
        [MemberCollection(NotNullItems = true)]
        public FastCollection<AbstractCollisionHandler> CollisionHandlers = new FastCollection<AbstractCollisionHandler>();

        public override async Task Execute()
        {
            var _physicsComponent = Entity.Get<PhysicsComponent>();

            foreach (var handler in CollisionHandlers)
            {
                handler.Initialize(Entity);
            }

            while (Game.IsRunning)
            {
                // Wait for the next collision event
                var firstCollision = await _physicsComponent.NewCollision();

                // Filter collisions based on collision groups
                var filterAhitB = ((int)firstCollision.ColliderA.CanCollideWith) & ((int)firstCollision.ColliderB.CollisionGroup);
                var filterBhitA = ((int)firstCollision.ColliderB.CanCollideWith) & ((int)firstCollision.ColliderA.CollisionGroup);

                //Log.Info($"Collider A: {firstCollision.ColliderA.Entity.Name} ; Collider B: {firstCollision.ColliderB.Entity.Name}");

                if (filterAhitB == 0 || filterBhitA == 0)
                    continue;

                var collider = firstCollision.ColliderA.Entity == Entity ? firstCollision.ColliderB : firstCollision.ColliderA;

                foreach (var handler in CollisionHandlers)
                {
                    handler.HandleCollision(Game, Entity, collider);
                }
            }
        }


    }
}
