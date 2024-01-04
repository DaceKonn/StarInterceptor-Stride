using StarInterceptor.Core.Processors;
using Stride.Engine.Events;
using Stride.Games;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarInterceptor.Gameplay.ShipDamageSystem
{
    internal class HullCollectibleApplyProcessor : SimpleEntityProcessor<ShipHullState>
    {
        private EventReceiver<int> _hullToApplyReciever = new EventReceiver<int>(ShipDamageEventRegistry.HullToApplyEventKey);

        public override void Update(GameTime time)
        {
            if (_hullToApplyReciever.TryReceive(out int hull) && ComponentDatas.Count() == 1)
            {
                KeyValuePair<ShipHullState, ShipHullState> keyValuePair = ComponentDatas.First();
                if (keyValuePair.Key.CurrentHullValue > 0)
                {
                    keyValuePair.Key.CurrentHullValue += hull;
                }
            }
            else if (ComponentDatas.Count() != 1)
            {
                Log.Error($"Exactyl 1 ShipHullState needed and allowed in a scene, currently there are: {ComponentDatas.Count()}");
            }
            base.Update(time);
        }
    }
}
