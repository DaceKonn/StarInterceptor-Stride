using StarInterceptor.Core;
using StarInterceptor.Gameplay.ShipDamageSystem;
using Stride.Core;
using Stride.Engine;
using Stride.Physics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarInterceptor.Gameplay.CollisionsSystem
{
    [DataContract()]
    [Serializable]
    [ComponentCategory("CollisionsSystem")]
    public class DespawnOnCollision : AbstractCollisionHandler
    {
        internal override void HandleCollision(Stride.Games.IGame game, Entity entity, PhysicsComponent collider)
        {
            if (((int)ReactWith & (int)collider.CollisionGroup) != 0)
            {
                game.RemoveEntity(entity);
            }
        }

        internal override void Initialize(Entity entity)
        {
        }
    }
}
