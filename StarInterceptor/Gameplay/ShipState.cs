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

namespace StarInterceptor.Gameplay
{
    public class ShipState : SyncScript
    {
        public List<WeaponSlot> Weapons = new List<WeaponSlot>();


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
