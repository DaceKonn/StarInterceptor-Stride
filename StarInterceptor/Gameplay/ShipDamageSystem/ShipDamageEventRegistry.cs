using Stride.Engine.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarInterceptor.Gameplay.ShipDamageSystem
{
    public static class ShipDamageEventRegistry
    {
        public static EventKey<int> DamageToApplyEventKey = new EventKey<int>("ShipDamageSystem", "DamageToApply");
        public static EventKey ShipDestroyed = new EventKey("ShipDamageSystem", "ShipDestroyed");
    }
}
