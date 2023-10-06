using StarInterceptor.Core;
using Stride.Core.Mathematics;
using Stride.Engine;
using Stride.Engine.Design;
using System;

namespace StarInterceptor.Gameplay
{
    public class SpawnerScript : SyncScript
    {
        public Boolean Enabled { get; set; }

        public Prefab SpawnPrefab;
        public float TimerDelay = 1.5f;

        private float Timer = 0.0f;
        private Random Random = new Random();
        // Declared public member fields and properties will show in the game studio
        GameConfiguration GameConfiguration;


        public override void Start()
        {
            if (Spawn == null)
            {
                Log.Error("Spawn can't be null!");
            }

            GameConfiguration = Services.GetService<IGameSettingsService>()?.Settings.Configurations.Get<GameConfiguration>() ?? new GameConfiguration();
            // Initialization of the script.
        }

        public override void Update()
        {
            if (Enabled) Spawn();
            // Do stuff every new frame
        }

        private void Spawn()
        {
            //DebugText.Print("Spawns: " + Entity.GetChildren().Count(), new Int2(800, 50));

            if (Timer > 0.0f)
            {
                Timer -= (float)Game.UpdateTime.Elapsed.TotalSeconds;
                return;
            }

            float randomX = Random.Next(-GameConfiguration.FieldRestrictions.X * 100 + 50, GameConfiguration.FieldRestrictions.X * 100 + 50) / 100f;
            var entity = SpawnPrefab.Instantiate()[0];
            entity.Transform.Position = new Vector3(randomX, 0.5f, 0);
            Entity.AddChild(entity);
            Timer = TimerDelay - Random.Next(0, 12) / 10f;
        }
    }
}
