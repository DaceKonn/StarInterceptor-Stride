using Stride.Engine;

namespace StarInterceptor
{
    class StarInterceptorApp
    {
        static void Main(string[] args)
        {
            using (var game = new Game())
            {
                game.Run();
            }
        }
    }
}
