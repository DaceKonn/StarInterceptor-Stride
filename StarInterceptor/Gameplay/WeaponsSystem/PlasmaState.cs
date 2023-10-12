using StarInterceptor.Core;
using Stride.Engine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarInterceptor.Gameplay.WeaponsSystem
{
    [ComponentCategory("WeaponsSystem")]
    internal class PlasmaState : SimpleEntityComponent
    {
        public float BaseDelay { get; set; }

        public Prefab Projectile { get; set; }
    }
}
