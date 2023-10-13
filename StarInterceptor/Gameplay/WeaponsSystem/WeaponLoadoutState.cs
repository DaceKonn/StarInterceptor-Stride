using StarInterceptor.Core;
using Stride.Core;
using Stride.Core.Annotations;
using Stride.Core.Collections;
using Stride.Engine;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarInterceptor.Gameplay.WeaponsSystem
{
    [ComponentCategory("WeaponsSystem")]
    public class WeaponLoadoutState : SimpleEntityComponent
    {
        [Category]
        [MemberCollection(NotNullItems = true)]
        public FastCollection<String> MainWeaponIds = new FastCollection<String>();

        [Category]
        [MemberCollection(NotNullItems = true)]
        public FastCollection<String> SecondaryWeaponIds = new FastCollection<String>();

        [DataMemberIgnore]
        public float MainWeaponPauseTimer { get; set; }
    }
}
