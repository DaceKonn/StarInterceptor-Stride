using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Stride.Core.Mathematics;
using Stride.Input;
using Stride.Engine;
using StarInterceptor.Gameplay.Weapons;
using Stride.Core;
using Silk.NET.OpenXR;
using Stride.Core.Serialization;
using Stride.Core.Annotations;
using System.ComponentModel;
using Stride.Core.Collections;

namespace StarInterceptor.Gameplay
{
    public class ShipState : SyncScript
    {
        [DataMember(200)]
        [Category]
        [MemberCollection(NotNullItems = true)]
        public FastCollection<WeaponSlot> Weapons = new FastCollection<WeaponSlot>();

        public int Hull { get; set; }


        public override void Start()
        {
          // Initialization of the script.
        }

        public override void Update()
        {
            // Do stuff every new frame
        }
    }

    [DataContract()]
    [Serializable]
    public struct WeaponSlot
    {
        public WeaponSlot(Weapon weapon, bool enabled)
        {
            Weapon = weapon;
            Enabled = enabled;
        }

        public Weapon Weapon { get; set; }
        public Boolean Enabled { get; set; }
    }
}
