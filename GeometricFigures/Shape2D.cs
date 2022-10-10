using System.Numerics;

namespace GeometricFigures
{
    public abstract class Shape2D : Shape
    {
        public abstract float Circumference { get; }

        public override string ToString() => $"{Name} @({Center.X.ToString("F1", Culture)},{Center.Y.ToString("F1", Culture)})";
    }
}