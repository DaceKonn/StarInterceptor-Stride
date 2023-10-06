using StarInterceptor.Core;
using Stride.Engine;
using System;
using System.Threading.Tasks;

namespace StarInterceptor.Gameplay
{
    public class CollectibleCollisionHandler : AbstractSyncCollisionHandler
    {
        public int ScoreValue = 10;

        protected override Func<Task> cleanupTask(Entity collidedEntity)
        {
            if (collidedEntity != null && collidedEntity.Name == "Spaceship" && GameScores.Hull >= 0)
            {
                GameScores.Score += ScoreValue;
            }

            return async () =>
            {
                //await Game.WaitTime(TimeSpan.FromMilliseconds(3000));

                Game.RemoveEntity(Entity);
            };
        }
    }
}
