using System.Numerics;

namespace GeometricFigures
{
    public abstract class Shape3D : Shape
    {
        public abstract float Volume { get; }

        public override string ToString() => $"{Name} @({Center.X.ToString("F1", Culture)},{Center.Y.ToString("F1", Culture)},{Center.Z.ToString("F1", Culture)})";
    }
}
