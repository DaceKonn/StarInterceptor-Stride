using StarInterceptor.Core;
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
                _gameScores.Hull--;
            }

            return async () =>
            {
                //await Game.WaitTime(TimeSpan.FromMilliseconds(3000));
                Game.RemoveEntity(Entity);
            };
        }
    }
}
