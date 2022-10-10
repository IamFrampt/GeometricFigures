using System.Numerics;

namespace GeometricFigures
{
    public class Sphere : Shape3D
    {
        private Vector3 _center;
        private float _area, _volume;
        private float _radius;

        public override string Name => "Sphere";
        public override Vector3 Center => _center;
        public override float Area => _area = MathF.Pow(_radius, 2) * 4 * MathF.PI;
        public override float Volume => _volume = (4 * MathF.PI * MathF.Pow(_radius, 3)) / 3;

        public Sphere(Vector3 center, float radius)
        {
            _center = new Vector3(center.X, center.Y, center.Z);
            _radius = radius;
        }

        public override string ToString() => base.ToString() + $": r = {_radius.ToString("F2", Culture)}";
    }
}
