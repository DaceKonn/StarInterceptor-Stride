using StarInterceptor.Gameplay;
using Stride.Engine;
using Stride.Engine.Events;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace StarInterceptor.Core
{
    public abstract class AbstractSyncCollisionHandler : SyncScript
    {
        // Declared public member fields and properties will show in the game studio
        public Trigger Trigger { get; set; }
        protected GameScores GameScores { get; set; }
        private EventReceiver<CollisionEvent> TriggeredEvent;
        private bool activated = false;

        public override void Start()
        {
            TriggeredEvent = (Trigger != null) ? new EventReceiver<CollisionEvent>(Trigger.TriggerEvent) : null;
            GameScores = Entity.Scene.Entities.Where(e => e.Name == "LevelUI").First().Components.Get<GameScores>();
            // Initialization of the script.
        }

        public override void Update()
        {
            CollisionEvent collisionEvent;
            if (!activated && (TriggeredEvent?.TryReceive(out collisionEvent) ?? false))
            {
                //Log.Info($"Colided entity: {collisionEvent.Entity}");
                CollisionStarted(collisionEvent);
            }
            // Do stuff every new frame
        }

        protected void CollisionStarted(CollisionEvent collisionEvent)
        {
            activated = true;

            Script.AddTask(cleanupTask(collisionEvent.Entity));
        }

        protected abstract Func<Task> cleanupTask(Entity collidedEntity);
    }
}
