using Stride.Core;
using Stride.Core.Mathematics;

namespace StarInterceptor.Core
{
    [DataContract("GameConfiguration")]
    [Display("Game Configuration")]
    internal class GameConfiguration : Stride.Data.Configuration
    {
        public Int2 FieldRestrictions { get; set; }
    }
}
