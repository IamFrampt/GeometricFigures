using System.Numerics;

namespace GeometricFigures
{
    public class Cuboid : Shape3D
    {
        private bool _isCube;
        private Vector3 _center;
        private float _volume, _area;
        private float Width, Height, Length;

        public override string Name => IsCube ? "Cube" : "Cuboid";
        private bool IsCube => _isCube = Width == Height && Width == Length;
        public override Vector3 Center => _center;
        public override float Area => _area;
        public override float Volume => _volume;

        public Cuboid(Vector3 center, Vector3 size)
        {
            Width = size.X;
            Height = size.Y;
            Length = size.Z;

            _area = (2 * Width * Height) + (2 * Length * Height) + (2 * Width * Length);

            _volume = Width * Height * Length;

            _center = new Vector3(center.X, center.Y, center.Z);
        }

        public Cuboid(Vector3 center, float width) : this(center, Vector3.Zero)
        {
            Width = width;
            Height = width;
            Length = width;

            _area = 6 * MathF.Pow(width, 2);
            _volume = MathF.Pow(width, 3);
        }

        public override string ToString() => base.ToString() + (IsCube ? $": w:h:l = {Width.ToString("F2", Culture)}" : $": w = {Width.ToString("F2", Culture)}, h = {Height.ToString("F2", Culture)}, l = {Length.ToString("F2", Culture)}");
    }
}