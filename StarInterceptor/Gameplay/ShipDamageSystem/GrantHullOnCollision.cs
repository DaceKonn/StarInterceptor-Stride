using StarInterceptor.Gameplay.CollisionsSystem;
using StarInterceptor.Gameplay.ShipDamageSystem;
using Stride.Core;
using Stride.Engine;
using Stride.Games;
using Stride.Physics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarInterceptor.Gameplay.ScoringSystem
{
    [DataContract()]
    [Serializable]
    [ComponentCategory("ShipDamageSystem")]
    public class GrantHullOnCollision : AbstractCollisionHandler
    {
        private HullOnCollectState _hullOnCollectState;

        internal override void Initialize(Entity entity)
        {
            _hullOnCollectState = entity.Get<HullOnCollectState>();
        }

        internal override void HandleCollision(IGame game, Entity entity, PhysicsComponent collider)
        {
            if (((int)ReactWith & (int)collider.CollisionGroup) != 0)
            {

                ShipDamageEventRegistry.HullToApplyEventKey.Broadcast(_hullOnCollectState.Hull);
            }
        }

        
    }
}