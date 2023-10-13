using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Stride.Core.Mathematics;
using Stride.Input;
using Stride.Engine;
using StarInterceptor.Gameplay;
using Stride.Core;
using Stride.Engine.Design;
using Stride.Engine.Processors;
using StarInterceptor.Gameplay.ShipDamageSystem;
using StarInterceptor.Gameplay.ScoringSystem;
using Stride.Engine.Events;
using StarInterceptor.Gameplay.WeaponsSystem;

namespace StarInterceptor.Core.Processors
{
    [ComponentCategory("ProcessorsCore")]
    public class ProcessorRegistryComponent : SyncScript
    {
        public bool EnableLogging = false;

        // Declared public member fields and properties will show in the game studio
        public bool EnableShipDamageApplyProcessor = true;
        public bool EnableScoreApplyProcessor = true;


        public bool EnableShipWeaponsProcessor = true;
        public WeaponsRegistry WeaponsRegistry { get; set; }

        private EventReceiver<int> _scoreToApplyReveiver = new EventReceiver<int>(ScoreEventRegistry.ScoreToApplyKey);
        private EventReceiver<int> _damageToApplyReciever = new EventReceiver<int>(ShipDamageEventRegistry.DamageToApplyEventKey);

        public override void Start()
        {
            // Initialization of the script.
            if (EnableShipDamageApplyProcessor) SceneSystem.SceneInstance.Processors.Add(new ShipDamageApplyProcessor());
            if (EnableScoreApplyProcessor) SceneSystem.SceneInstance.Processors.Add(new ScoreApplyProcessor());
            if (EnableShipWeaponsProcessor) SceneSystem.SceneInstance.Processors.Add(new ShipWeaponsProcessor(WeaponsRegistry));
        }

        public override void Update()
        {
            if (EnableLogging)
            {
                if (_scoreToApplyReveiver.TryReceive(out int score)) Log.Info($"Score event with value: {score}");
                if (_damageToApplyReciever.TryReceive(out int damage)) Log.Info($"Damage event with value: {damage}");
            }
        }
    }
}
