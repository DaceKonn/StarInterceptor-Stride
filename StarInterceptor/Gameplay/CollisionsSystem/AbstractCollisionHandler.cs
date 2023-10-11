using StarInterceptor.Gameplay.Weapons;
using Stride.Core;
using Stride.Core.Serialization.Contents;
using Stride.Engine;
using Stride.Physics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarInterceptor.Gameplay.CollisionsSystem
{
    [ContentSerializer(typeof(DataContentSerializer<AbstractCollisionHandler>))]
    [DataContract("CollisionHandler")]
    public abstract class AbstractCollisionHandler
    {
        public CollisionFilterGroupFlags ReactWith { get; set; }

        internal abstract void HandleCollision(Stride.Games.IGame game, Entity entity, PhysicsComponent collider);

        internal abstract void Initialize(Entity entity);
    }
}
