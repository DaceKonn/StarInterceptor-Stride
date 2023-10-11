using StarInterceptor.Core;
using StarInterceptor.Gameplay.ShipDamageSystem;
using Stride.Engine;
using System;
using System.Threading.Tasks;

namespace StarInterceptor.Gameplay
{
    public class ObstacleCollisionHandler : AbstractSyncCollisionHandler
    {
        protected override Func<Task> CleanupTask(Entity collidedEntity)
        {
            if (collidedEntity != null && collidedEntity.Name == "Spaceship")
            {
                //ShipState.Hull--;
                ShipDamageEventRegistry.DamageToApplyEventKey.Broadcast(1);
            }

            return async () =>
            {
                //await Game.WaitTime(TimeSpan.FromMilliseconds(3000));
                Game.RemoveEntity(Entity);
            };
        }
    }
}
