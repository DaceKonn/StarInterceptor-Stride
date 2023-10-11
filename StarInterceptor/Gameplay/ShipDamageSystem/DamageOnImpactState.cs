using StarInterceptor.Core;
using Stride.Engine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarInterceptor.Gameplay.ShipDamageSystem
{
    [ComponentCategory("ShipDamageSystem")]
    public class DamageOnImpactState : SimpleEntityComponent
    {
        public int Damage { get; set; }
    }
}
