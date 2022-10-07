using System.Numerics;
using System.Security.Cryptography;

namespace GeometricFigures
{
    public class Triangle : Shape2D
    {
        private Vector2 _center;
        private Vector2 P1,P2,P3;
        private float _area, _circumference, _semiperimeter;
        private float _abSide, _bcSide, _caSide;

        public override string Name => "Triangle";
        public override Vector3 Center => new Vector3(_center,0);
        public override float Circumference() => _circumference = BCSide + CASide + ABSide;
        public override float Area => _area = MathF.Sqrt(Semiperimeter * (Semiperimeter - BCSide) * (Semiperimeter - CASide) * (Semiperimeter - ABSide));
        private float Semiperimeter => _semiperimeter = Circumference() / 2;
        private float ABSide => _abSide = Vector2.Distance(P1, P2);
        private float BCSide => _bcSide= Vector2.Distance(P2, P3);
        private float CASide => _caSide = Vector2.Distance(P1, P3);

        public Triangle(Vector2 p1, Vector2 p2, Vector2 p3)
        {
            P1 = p1;
            P2 = p2;
            P3 = p3;
            _center = new Vector2(((P1.X + P2.X + P3.X) / 3), ((P1.Y + P2.Y + P3.Y) / 3));
        }

        public Triangle(Vector2 p1, Vector2 p2, Vector3 center) : this(p1,p2,Vector2.Zero)
        {
            _center = new Vector2(center.Y,center.Y);
            P3 = new Vector2((3* _center.X) - P1.X - P2.X, (3 * _center.Y) - P1.Y - P2.Y);
        }

        public override string ToString() => base.ToString() + $": p1({P1.X.ToString("F2", Culture)},{P1.Y.ToString("F2", Culture)}), p2({P2.X.ToString("F2", Culture)},{P2.Y.ToString("F2", Culture)}), p3({P3.X.ToString("F2", Culture)},{P3.Y.ToString("F2", Culture)})";
    }
}
