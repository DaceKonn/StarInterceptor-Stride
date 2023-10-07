using StarInterceptor.Core;
using Stride.Engine;
using System;
using System.Threading.Tasks;

namespace StarInterceptor.Gameplay
{
    public class CollectibleCollisionHandler : AbstractSyncCollisionHandler
    {
        public int ScoreValue = 10;

        protected override Func<Task> CleanupTask(Entity collidedEntity)
        {
            if (collidedEntity != null && collidedEntity.Name == "Spaceship" && ShipState.Hull >= 0)
            {
                _gameScores.Score += ScoreValue;
            }

            return async () =>
            {
                //await Game.WaitTime(TimeSpan.FromMilliseconds(3000));

                Game.RemoveEntity(Entity);
            };
        }
    }
}
