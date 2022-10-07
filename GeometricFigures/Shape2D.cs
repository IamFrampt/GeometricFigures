using System.Numerics;

namespace GeometricFigures
{
    public abstract class Shape2D : Shape
    {
        private Vector3 _center;
        private float _area;

        public abstract float Circumference();

        public override string ToString() => $"{Name} @({Center.X.ToString("F1", Culture)},{Center.Y.ToString("F1", Culture)})";
    }
}