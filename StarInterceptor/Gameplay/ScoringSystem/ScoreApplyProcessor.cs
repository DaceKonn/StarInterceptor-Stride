using StarInterceptor.Core;
using StarInterceptor.Core.Processors;
using StarInterceptor.Gameplay.ShipDamageSystem;
using Stride.Engine.Events;
using Stride.Games;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarInterceptor.Gameplay.ScoringSystem
{
    public class ScoreApplyProcessor : SimpleEntityProcessor<CurrentScoreState>
    {
        private EventReceiver<int> _scoreToApplyReveiver = new EventReceiver<int>(ScoreEventRegistry.ScoreToApplyKey);
        private EventReceiver _shipDestroyedReceiver = new EventReceiver(ShipDamageEventRegistry.ShipDestroyed);
        private bool enabled = true;

        public override void Update(GameTime time)
        {
            if (_shipDestroyedReceiver.TryReceive())
            {
                enabled = false;
            }

            if (enabled)
            {
                if (_scoreToApplyReveiver.TryReceive(out int score) && ComponentDatas.Count() == 1)
                {
                    KeyValuePair<CurrentScoreState, CurrentScoreState> keyValuePair = ComponentDatas.First();
                    keyValuePair.Key.Score += score;
                }
                else if (ComponentDatas.Count() != 1)
                {
                    Log.Error($"Exactyl 1 CurrentScoreState needed and allowed in a scene, currently there are: {ComponentDatas.Count()}");
                }
            }
            
            base.Update(time);
        }
    }
}
