using StarInterceptor.Core;
using Stride.Core.Mathematics;
using Stride.Engine;
using Stride.Engine.Design;
using System;

namespace StarInterceptor.Gameplay
{
    [ComponentCategory("Spawns")]
    public class SpawnerScript : SyncScript
    {
        public Boolean Enabled { get; set; }

        public Prefab SpawnPrefab;
        public float TimerDelay = 1.5f;


        private float _timer = 0.0f;
        private Random _random = new Random();
        // Declared public member fields and properties will show in the game studio
        GameConfiguration _gameConfiguration;


        public override void Start()
        {
            if (Spawn == null)
            {
                Log.Error("Spawn can't be null!");
            }

            _gameConfiguration = Services.GetService<IGameSettingsService>()?.Settings.Configurations.Get<GameConfiguration>() ?? new GameConfiguration();
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

            if (_timer > 0.0f)
            {
                _timer -= (float)Game.UpdateTime.Elapsed.TotalSeconds;
                return;
            }
            

            float randomX = _random.Next(-_gameConfiguration.FieldRestrictions.X * 100 + 50, _gameConfiguration.FieldRestrictions.X * 100 + 50) / 100f;
            var entity = SpawnPrefab.Instantiate()[0];

            entity.Transform.Position = new Vector3(randomX, 0.5f, 0);
            Entity.AddChild(entity);
            _timer = TimerDelay - _random.Next(0, 12) / 10f;
        }
    }
}
