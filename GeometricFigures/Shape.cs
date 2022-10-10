using System.Globalization;
using System.Numerics;

namespace GeometricFigures
{
    public abstract class Shape : IComparable
    {
        public enum Shapes
        {
            Circle,
            Rectangle,
            Square,
            Triangle,
            Cube,
            Cuboid,
            Sphere,
            Amount,
        }

        public static CultureInfo Culture = CultureInfo.CreateSpecificCulture("es-US");
        static Random random = new Random();

        private static float minCoordinate = -100f;
        private static float maxCoordinate = 100f;

        public abstract string Name { get; }
        public abstract Vector3 Center { get; }
        public abstract float Area { get; }

        public static Shape GenerateShape()
        {
            return WhatShapeToCreate() switch
            {
                Shapes.Circle => new Circle(center: RandomVector2(), radius: RandomizeSideLength()),

                Shapes.Rectangle => new Rectangle(center: RandomVector2(), size: new Vector2(x: RandomizeSideLength(), y: RandomizeSideLength())),

                Shapes.Square => new Rectangle(center: RandomVector2(), width: RandomizeSideLength()),

                Shapes.Triangle => new Triangle(p1: RandomVector2(), p2: RandomVector2(), p3: RandomVector2()),

                Shapes.Cube => new Cuboid(center: RandomVector3(), width: RandomizeSideLength()),

                Shapes.Cuboid => new Cuboid(center: RandomVector3(), size: new Vector3(x: RandomizeSideLength(), y: RandomizeSideLength(), z: RandomizeSideLength())),

                Shapes.Sphere => new Sphere(center: RandomVector3(), radius: RandomizeSideLength()),

                _ => throw new Exception("Unreachable shape!"),
            };
        }
        public static Shape GenerateShape(Vector3 position) 
        {
            return WhatShapeToCreate() switch
            {
                Shapes.Circle => new Circle(center: new Vector2(position.X, position.Y), radius: RandomizeSideLength()),

                Shapes.Rectangle => new Rectangle(center: new Vector2(position.X, position.Y), size: new Vector2(RandomizeSideLength(), RandomizeSideLength())),

                Shapes.Square => new Rectangle(center: new Vector2(position.X, position.Y), width: RandomizeSideLength()),

                Shapes.Cuboid => new Cuboid(center: position, size: new Vector3(RandomizeSideLength(), RandomizeSideLength(), RandomizeSideLength())),

                Shapes.Cube => new Cuboid(center: position, width: RandomizeSideLength()),

                Shapes.Sphere => new Sphere(center: position, radius: RandomizeSideLength()),

                Shapes.Triangle => new Triangle(p1: RandomVector2(), p2: RandomVector2(), position),

                _ => throw new Exception("Unreachable shape!"),
            };
        }
        static Shapes WhatShapeToCreate()
        {
            return (random.Next((int)Shapes.Amount)) switch
            {
                0 => Shapes.Circle,
                1 => Shapes.Rectangle,
                2 => Shapes.Square,
                3 => Shapes.Triangle,
                4 => Shapes.Cube,
                5 => Shapes.Cuboid,
                6 => Shapes.Sphere,
                _ => throw new Exception("Unreachable shape"),
            };
        }

        private static Vector2 RandomVector2()
        {
            return new Vector2(MathF.Round(random.NextSingle() * (maxCoordinate - minCoordinate) + minCoordinate, 2), MathF.Round(random.NextSingle() * (maxCoordinate - minCoordinate) + minCoordinate, 2));
        }

        private static Vector3 RandomVector3()
        {
            return new Vector3(RandomVector2(), MathF.Round(random.NextSingle() * (maxCoordinate - minCoordinate) + minCoordinate, 2));
        }

        private static float RandomizeSideLength()
        {
            float value = MathF.Round(random.NextSingle() * 100 + 1, 2);
            return value;
        }
        public int CompareTo(object? obj)
        {
            return Name.CompareTo((obj as Shape).Name);
        }
    }
}