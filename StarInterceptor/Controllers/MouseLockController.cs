using Stride.Engine;
using Stride.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarInterceptor.Controllers
{
    public class MouseLockController : SyncScript
    {
        public override void Update()
        {
            MousetLocking();
        }

        private void MousetLocking()
        {
            if (Input.IsMouseButtonDown(MouseButton.Left))
            {
                Input.LockMousePosition(true);
                Game.IsMouseVisible = false;
            }
            if (Input.IsKeyPressed(Keys.Escape))
            {
                Input.UnlockMousePosition();
                Game.IsMouseVisible = true;
            }
        }
    }
}
