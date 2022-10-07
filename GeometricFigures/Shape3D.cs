using System.Numerics;

namespace GeometricFigures
{
    public abstract class Shape3D : Shape
    {
        private Vector3 _center;
        private float _area;
        public abstract float Volume();
        public override Vector3 Center => _center;
        public override float Area => _area;

        public override string ToString() => $"{Name} @({Center.X.ToString("F1", Culture)},{Center.Y.ToString("F1", Culture)},{Center.Z.ToString("F1", Culture)})";
    }
}
