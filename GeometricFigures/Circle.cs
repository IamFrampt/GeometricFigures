using System.Numerics;

namespace GeometricFigures
{
    public class Circle : Shape2D
    {

        private Vector3 _center;
        private float _circumference, _area, _radius;
        public override string Name => "Circle";
        public override Vector3 Center => _center;
        public override float Area => _area = MathF.Pow(_radius, 2) * MathF.PI;
        public override float Circumference() => _circumference = (_radius * 2) * MathF.PI;

        public Circle(Vector2 center, float radius)
        {
            _radius = radius;
            _center = new Vector3(center.X, center.Y, 0.0f);
        }

        public override string ToString() => base.ToString() + $": r = {_radius.ToString("F2", Culture)}";
    }
}
