using StarInterceptor.Gameplay.ShipDamageSystem;
using Stride.Engine;
using Stride.Physics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarInterceptor.Gameplay.ScoringSystem
{
    [ComponentCategory("ScoringSystem")]
    public class GrantScoreOnCollision : AsyncScript
    {
        public CollisionFilterGroupFlags ScoreOnCollisionWith { get; set; }

        public override async Task Execute()
        {
            var _physicsComponent = Entity.Get<PhysicsComponent>();
            var _scoreValueState = Entity.Get<ScoreValueState>();

            while (Game.IsRunning)
            {
                // Wait for the next collision event
                var firstCollision = await _physicsComponent.NewCollision();

                var collisionGroup = firstCollision.ColliderA.Entity == Entity ? firstCollision.ColliderB.CollisionGroup : firstCollision.ColliderA.CollisionGroup;

                if (((int)ScoreOnCollisionWith & (int)collisionGroup) != 0)
                {
                    ScoreEventRegistry.ScoreToApplyKey.Broadcast(_scoreValueState.ScoreValue);
                }
            }
        }
    }
}