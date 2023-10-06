using Stride.Core;
using System;
using System.Runtime.InteropServices;

namespace StarInterceptor.Core
{
    [DataContract("speedStruct")]
    [Serializable]
    [DataStyle(DataStyle.Compact)]
    [StructLayout(LayoutKind.Sequential, Pack = 2)]
    public struct Speed// : IEquatable<Vector3>, IFormattable
    {
        public Speed(float strafeSpeed, float forwardSpeed)
        {
            StrafeSpeed = strafeSpeed;
            ForwardSpeed = forwardSpeed;
        }

        [DataMember(0)]
        public float StrafeSpeed { get; set; }

        [DataMember(1)]
        public float ForwardSpeed { get; set; }

        public override string ToString()
        {
            return $"[Strafe Speed: {StrafeSpeed}; Foward Speed: {ForwardSpeed}]";
        }
    }
}
