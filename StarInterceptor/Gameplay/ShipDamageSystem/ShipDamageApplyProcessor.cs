using Microsoft.VisualBasic.Logging;
using StarInterceptor.Core.Processors;
using Stride.Engine;
using Stride.Engine.Events;
using Stride.Games;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarInterceptor.Gameplay.ShipDamageSystem
{
    public class ShipDamageApplyProcessor : SimpleEntityProcessor<ShipHullState>
    {
        private EventReceiver<int> _damageToApplyReciever = new EventReceiver<int>(ShipDamageEventRegistry.DamageToApplyEventKey);

        public override void Update(GameTime time)
        {
            if (_damageToApplyReciever.TryReceive(out int damage) && ComponentDatas.Count() == 1)
            {
                KeyValuePair<ShipHullState, ShipHullState> keyValuePair = ComponentDatas.First();
                keyValuePair.Key.CurrentHullValue -= damage;

                if (keyValuePair.Key.CurrentHullValue == 0)
                {
                    ShipDamageEventRegistry.ShipDestroyed.Broadcast();
                }
            } else if (ComponentDatas.Count() != 1) {
                Log.Error($"Exactyl 1 ShipHullState needed and allowed in a scene, currently there are: {ComponentDatas.Count()}");
            }
            base.Update(time);
        }
    }
}
