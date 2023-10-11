using StarInterceptor.Core;
using Stride.Core;
using Stride.Engine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarInterceptor.Gameplay.ShipDamageSystem
{
    [ComponentCategory("ShipDamageSystem")]
    public class ShipHullState : SimpleEntityComponent
    {
        private int _currentHullValue = 0;
        private int _starrtingValue = 3;
        
        public int StartingHullValue
        {
            get
            {
                return _starrtingValue;
            }
            set
            {
                _starrtingValue = value;
                _currentHullValue = value;
            }
        }

        [DataMemberIgnore]
        public int CurrentHullValue
        {
            get { return _currentHullValue; }
            set { if (value >= 0 || _currentHullValue != 0) { _currentHullValue = value; } }
        }

    }
}
