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

                Shapes.Cuboid => new Cuboid(center: position, size: new Vector3(RandomizeSideLength(), RandomizeSideLength(),RandomizeSideLength())),

                Shapes.Cube => new Cuboid(center: position, width: RandomizeSideLength()),

                Shapes.Sphere => new Sphere(center: position, radius: RandomizeSideLength()),

                Shapes.Triangle => new Triangle(p1: RandomVector2(), p2: RandomVector2(), position),

                _ => throw new Exception("Unreachable shape!"),
            };
        }
        static Shapes WhatShapeToCreate()
        {
            switch (random.Next((int)Shapes.Amount))
            {
                case 0:
                    return Shapes.Circle;
                    break;
                case 1:
                    return Shapes.Rectangle;
                    break;
                case 2:
                    return Shapes.Square;
                    break;
                case 3:
                    return Shapes.Triangle;
                    break;
                case 4:
                    return Shapes.Cube;
                    break;
                case 5:
                    return Shapes.Cuboid;
                    break;
                case 6:
                    return Shapes.Sphere;
                    break;

                default: throw new Exception("Unreachable shape");
            }
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

        //public static Dictionary<Shapes, int> Dictionary()
        //{
        //    Dictionary<Shapes, int> Counter = new Dictionary<Shapes, int>();
        //    for (int i = 0; i < shapeCounter.Length; i++)
        //    {
        //        if (shapeCounter[i] > 0)
        //            Counter.Add((Shapes)i, shapeCounter[i]);
        //    }
        //    return (from entry in Counter orderby entry.Value descending select entry).ToDictionary(pair => pair.Key, pair => pair.Value);
        //}

        public int CompareTo(object? obj)
        {
            return Name.CompareTo((obj as Shape).Name);
        }
    }
}