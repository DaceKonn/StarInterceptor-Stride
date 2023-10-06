using Stride.Core;
using Stride.Core.Serialization;
using Stride.Engine;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarInterceptor.Gameplay.Weapons
{
    [DataContract()]
    [Serializable]
    public class Laser : Weapon
    {
        public new float BaseDelay { get; set; } = 0.2f;
    }
}
