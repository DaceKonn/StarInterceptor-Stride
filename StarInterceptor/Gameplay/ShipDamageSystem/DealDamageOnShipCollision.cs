using StarInterceptor.Core;
using StarInterceptor.Gameplay.CollisionsSystem;
using Stride.Core;
using Stride.Engine;
using Stride.Games;
using Stride.Physics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarInterceptor.Gameplay.ShipDamageSystem
{
    [DataContract()]
    [Serializable]
    [ComponentCategory("ShipDamageSystem")]
    public class DealDamageOnShipCollision : AbstractCollisionHandler
    {
        private DamageOnImpactState _damageOnImpactState;

        internal override void Initialize(Entity entity)
        {
            _damageOnImpactState = entity.Get<DamageOnImpactState>();
        }

        internal override void HandleCollision(IGame game, Entity entity, PhysicsComponent collider)
        {
            if (((int)ReactWith & (int)collider.CollisionGroup) != 0)
            {
                ShipDamageEventRegistry.DamageToApplyEventKey.Broadcast(_damageOnImpactState.Damage);
            }
        }
    }
}
