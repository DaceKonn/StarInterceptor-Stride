using Stride.Engine.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarInterceptor.Gameplay.WeaponsSystem
{
    public static class ShipWeaponsEventRegistry
    {
        public static EventKey<WeaponSlot> ShipWeaponsFiredEvent { get; } = new EventKey<WeaponSlot>();
    }
}
