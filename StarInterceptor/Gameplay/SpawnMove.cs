using StarInterceptor.Core;
using Stride.Engine;
using System.Linq;

namespace StarInterceptor.Gameplay
{
    public class SpawnMove : SyncScript
    {
        // Declared public member fields and properties will show in the game studio
        public float Speed = 0.0f;
        Entity Despawner;


        public override void Start()
        {
            Despawner = Entity.Scene.Entities.FirstOrDefault(ent => ent.Name == "Despawner");
            // Initialization of the script.
        }

        public override void Update()
        {
            float deltaTime = (float)Game.UpdateTime.Elapsed.TotalSeconds;
            var movement = Speed * deltaTime;

            Entity.Transform.Position.Z += movement;

            if (Entity.Transform.Position.Z < -10 || Entity.Transform.Position.Z > 20)
            {
                Game.RemoveEntity(Entity);
            }
            // Do stuff every new frame
        }
    }
}
