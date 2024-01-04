using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Stride.Core.Mathematics;
using Stride.Input;
using Stride.Engine;
using Stride.Physics;

namespace StarInterceptor.Gameplay
{
    public class SpawnRotation : SyncScript
    {
        // Declared public member fields and properties will show in the game studio
        private PhysicsComponent _physicsComponent;
        private Quaternion _rotation;
        private Random Random = new Random();

        public override void Start()
        {
            _physicsComponent = Entity.Components.Get<PhysicsComponent>();

            float angle = Random.Next(0, 100) / 10f;

            _rotation = Quaternion.RotationX(Random.Next(0, 100) / 10000f) *
                Quaternion.RotationY(Random.Next(0, 300) / 10000f) *
                Quaternion.RotationZ(Random.Next(0, 300) / 10000f);
            // Initialization of the script.
        }

        public override void Update()
        {
            Entity.Transform.Rotation *= _rotation;
            _physicsComponent.UpdatePhysicsTransformation();
        }
    }
}
