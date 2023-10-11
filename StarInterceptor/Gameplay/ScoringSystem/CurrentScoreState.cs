using StarInterceptor.Core;
using Stride.Core;
using Stride.Engine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarInterceptor.Gameplay.ScoringSystem
{
    [ComponentCategory("ScoringSystem")]
    public class CurrentScoreState : SimpleEntityComponent
    {
        [DataMemberIgnore]
        public int Score { get; set; } = 0;
    }
}
