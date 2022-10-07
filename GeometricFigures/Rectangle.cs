using System.Numerics;

namespace GeometricFigures
{
    public class Rectangle : Shape2D
    {
        private bool _isSquare;
        private Vector3 _center;
        private float _area, _circumference;
        private float Width, Height;

        public override string Name => IsSquare ? "Square" : "Rectangle"; 
        private bool IsSquare => _isSquare =Width == Height;
        public override Vector3 Center => _center;
        public override float Area => _area = Width * Height;
        public override float Circumference() => _circumference = (Width *2)  + (Height * 2);

        public Rectangle(Vector2 center, Vector2 size)
        {
            Width = size.X;
            Height = size.Y;
            _center = new Vector3(center.X, center.Y, 0.0f);
        }
        public Rectangle(Vector2 center, float width): this(center,Vector2.Zero)
        {
            Width = width;
            Height = width;
        }
        public override string ToString() => base.ToString() + (IsSquare ? $": w:h = {Width.ToString("F2", Culture)}" : $": w = {Width.ToString("F2", Culture)}, h = {Height.ToString("F2", Culture)}");
    }
}