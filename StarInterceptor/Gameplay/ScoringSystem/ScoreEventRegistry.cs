using Stride.Engine.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarInterceptor.Gameplay.ScoringSystem
{
    public static class ScoreEventRegistry
    {
        public static EventKey<int> ScoreToApplyKey = new EventKey<int>("ScoringSystem", "ScoreToApply");
    }
}
