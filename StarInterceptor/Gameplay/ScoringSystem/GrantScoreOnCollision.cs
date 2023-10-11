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
    [ComponentCategory("ScoringSystem")]
    public class GrantScoreOnCollision : AbstractCollisionHandler
    {
        private ScoreValueState _scoreValueState;

        internal override void Initialize(Entity entity)
        {
            _scoreValueState = entity.Get<ScoreValueState>();
        }

        internal override void HandleCollision(IGame game, Entity entity, PhysicsComponent collider)
        {
            if (((int)ReactWith & (int)collider.CollisionGroup) != 0)
            {
                
                ScoreEventRegistry.ScoreToApplyKey.Broadcast(_scoreValueState.ScoreValue);
            }
        }

        
    }
}