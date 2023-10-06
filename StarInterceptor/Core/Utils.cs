using Stride.Engine;
using Stride.Games;
using System;
using System.Threading.Tasks;

namespace StarInterceptor.Core
{
    public static class Utils
    {
        /// <summary>
        /// Removes an entity, together with its children, from the Game's scene graph
        /// </summary>
        /// <param name="game">The game instance containing the entity</param>
        /// <param name="entity">Entity to remove</param>
        public static void RemoveEntity(this IGame game, Entity entity)
        {
            var parent = entity.GetParent();
            if (parent != null)
            {
                parent.RemoveChild(entity);
                return;
            }

            ((Game)game).SceneSystem.SceneInstance.RootScene.Entities.Remove(entity);
        }

        public static async Task WaitTime(this IGame game, TimeSpan time)
        {
            var g = (Game)game;
            var goal = game.UpdateTime.Total + time;
            while (game.UpdateTime.Total < goal)
            {
                await g.Script.NextFrame();
            }
        }
    }
}
