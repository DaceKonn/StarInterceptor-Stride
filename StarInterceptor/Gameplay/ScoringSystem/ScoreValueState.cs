using StarInterceptor.Core;
using Stride.Engine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarInterceptor.Gameplay.ScoringSystem
{
    [ComponentCategory("ScoringSystem")]
    public class ScoreValueState : SimpleEntityComponent
    {
        public int ScoreValue { get; set; }
    }
}
