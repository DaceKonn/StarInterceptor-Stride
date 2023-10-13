using Stride.Core;
using Stride.Core.Serialization.Contents;
using Stride.Engine;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarInterceptor.Gameplay.WeaponsSystem
{
    [ContentSerializer(typeof(DataContentSerializer<Weapon>))]
    [DataContract("Weapon")]
    public class Weapon
    {
        [DataMember(0)]
        public String Id { get; set; }

        [DataMember(1)]
        public WeaponSlot Slot {  get; set; }

        [DataMember(2)]
        public Prefab Projectile { get; set; }

        [DataMember(3)]
        public float ProjectileSpeed { get; set; }

        [DataMember(4)]
        public float DelayBetweenShots { get; set; }
    }
}
