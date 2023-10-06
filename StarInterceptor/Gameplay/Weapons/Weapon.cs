using Stride.Core;
using Stride.Core.Serialization;
using Stride.Core.Serialization.Contents;
using Stride.Engine;
using Stride.Physics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarInterceptor.Gameplay.Weapons
{

    [ContentSerializer(typeof(DataContentSerializer<Weapon>))]
    [DataContract("Weapon")]
    public abstract class Weapon
    {

        public float BaseDelay { get; set; }

        public Prefab Bullet { get; set; }
    }
}
