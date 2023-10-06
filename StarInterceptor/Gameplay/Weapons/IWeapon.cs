using Stride.Engine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarInterceptor.Gameplay.Weapons
{
    public abstract class Weapon
    {
        public float BaseDelay { get; set; }
        public Prefab Bullet { get; set; }
    }
}
