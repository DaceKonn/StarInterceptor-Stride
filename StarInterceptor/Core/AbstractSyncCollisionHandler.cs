using StarInterceptor.Gameplay.CollisionsSystem;
using StarInterceptor.Gameplay.ScoringSystem;
using Stride.Engine;
using Stride.Engine.Events;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace StarInterceptor.Core
{
    [ComponentCategory("CollisionHelpers")]
    public abstract class AbstractSyncCollisionHandler : SyncScript
    {
        // Declared public member fields and properties will show in the game studio
        public Trigger Trigger { get; set; }
        protected GameScores _gameScores { get; set; }
        private EventReceiver<CollisionEvent> _triggeredEvent;
        private bool _activated = false;

        public override void Start()
        {
            _triggeredEvent = (Trigger != null) ? new EventReceiver<CollisionEvent>(Trigger.TriggerEvent) : null;
            _gameScores = Entity.Scene.Entities.Where(e => e.Name == "LevelUI").First().Components.Get<GameScores>();
            // Initialization of the script.
        }

        public override void Update()
        {
            CollisionEvent collisionEvent;
            if (!_activated && (_triggeredEvent?.TryReceive(out collisionEvent) ?? false))
            {
                //Log.Info($"Colided entity: {collisionEvent.Entity}");
                CollisionStarted(collisionEvent);
            }
            // Do stuff every new frame
        }

        protected void CollisionStarted(CollisionEvent collisionEvent)
        {
            _activated = true;

            Script.AddTask(CleanupTask(collisionEvent.Entity));
        }

        protected abstract Func<Task> CleanupTask(Entity collidedEntity);
    }
}
