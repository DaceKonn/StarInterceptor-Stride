using StarInterceptor.Core;
using Stride.Engine;
using System;
using System.Threading.Tasks;

namespace StarInterceptor.Gameplay
{
    public class BulletCollisionHandler : AbstractSyncCollisionHandler
    {
        protected override Func<Task> CleanupTask(Entity collidedEntity)
        {
            return async () =>
            {
                //await Game.WaitTime(TimeSpan.FromMilliseconds(3000));

                Game.RemoveEntity(Entity);
            };
        }
    }
}
