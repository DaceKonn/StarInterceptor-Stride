using StarInterceptor.Core;
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
    public class WeaponsRegistry : SimpleEntityComponent
    {
        [Category]
        [MemberCollection(NotNullItems = true)]
        public FastCollection<Weapon> Weapons = new FastCollection<Weapon>();
    }
}
