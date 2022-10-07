using GeometricFigures;
using System.Numerics;
Console.OutputEncoding = System.Text.Encoding.UTF8;

//*********************VARIABLES*********************

int creatingThisAmountOfShapes = 20;
string userInput = string.Empty;
bool randomizeValues = false, userInputValid = false, pairFound = false;
float[] userFloatValues = new float[3];
Vector3 userVector = Vector3.Zero;

Shape[] ShapesCreated = new Shape[creatingThisAmountOfShapes];
Dictionary<Shape.Shapes, int> shapeCountersDictionary = new Dictionary<Shape.Shapes, int>();
Tuple<float, float, string, float> Calculations = new Tuple<float, float, string, float>(0, 0, string.Empty, 0);

//***********************MAIN************************

do
{
    Console.WriteLine("Do you want to choose the center point of all shapes? Y/N");
    userInput = Console.ReadLine().ToLower();

    if (userInput == "y")
    {
        while (!userInputValid)
        {
            Console.Clear();
            randomizeValues = false;

            Console.WriteLine("Write the center point for the shapes. Example: X Y Z -->  1,2 2,3 3,4 ");
            Console.WriteLine("If you write more than three values the values after the third value will not count.");

            userInput = Console.ReadLine();
            var userValues = userInput.Split(" ");

            for (int i = 0; i < 3; i++)
            {
                try
                {
                    userFloatValues[i] = float.Parse(userValues[i]);
                }
                catch
                {
                    Console.WriteLine("Input var inte i rätt format, testa igen.");
                    Thread.Sleep(750);
                    break;
                }

                if (i == 2)
                {
                    userInputValid = true;
                    userVector = new Vector3(userFloatValues[0], userFloatValues[1], userFloatValues[2]);
                }
            }
        }
    }
    if (userInput == "n")
    {
        userInputValid = true;
        randomizeValues = true;
    }

} while (!userInputValid);

Console.Clear();

ShapesCreated = CreateShapes(creatingThisAmountOfShapes);
Calculations = CalculatingValues(ShapesCreated);
shapeCountersDictionary = Shape.Dictionary();

//Sorting by name
Array.Sort(ShapesCreated, (firstShape, secondShape) => firstShape.Name.Length == secondShape.Name.Length ? firstShape.CompareTo(secondShape) : firstShape.Name.Length - secondShape.Name.Length);

PrintResult(ShapesCreated, shapeCountersDictionary, Calculations);

//**********************METHODS**********************

Shape[] CreateShapes(int amount)
{
    Shape[] shapes = new Shape[amount];

    for (int i = 0; i < creatingThisAmountOfShapes; i++)
    {
        if (randomizeValues)
            shapes[i] = Shape.GenerateShape();
        else
            shapes[i] = Shape.GenerateShape(userVector);
        //shapes[i] = Shape.GenerateShape(new Vector3(4.0f,10.0f,5.0f));
    }

    return shapes;
}

Tuple<float, float, string, float> CalculatingValues(Shape[] shapes)
{
    float totalArea = 0;
    float averageAreaOfAllShapes;
    float circumferenceOfAllTriangles = 0;
    string ShapeWithHighestVolume = string.Empty;
    float HighestVolumeOfAllShapes = 0;
    float TempHighestVolume = 0;


    for (int i = 0; i < shapes.Length; i++)
    {
        totalArea += shapes[i].Area;

        if (shapes[i] is Triangle triangle)
        {
            circumferenceOfAllTriangles += triangle.Circumference();
        }

        if (shapes[i] is Shape3D s3D)
        {
            if (s3D.Volume() > TempHighestVolume)
            {
                HighestVolumeOfAllShapes = s3D.Volume();
                ShapeWithHighestVolume = s3D.Name;
            }
            TempHighestVolume = s3D.Volume();
        }
    }
    averageAreaOfAllShapes = totalArea / shapes.Length;

    return Tuple.Create(averageAreaOfAllShapes, circumferenceOfAllTriangles, ShapeWithHighestVolume, HighestVolumeOfAllShapes);
}

void PrintResult(Shape[] Shapes, Dictionary<Shape.Shapes, int> shapeCounters, Tuple<float, float, string, float> Calculations)
{
    Shape? tempShape = null;

    foreach (Shape shape in Shapes)
    {
        if (tempShape == null)
        {
            Console.WriteLine(new String('-', 25) + shape.Name + new String('-', 25));
            Console.WriteLine(shape);
        }
        else if (shape.Name != tempShape.Name)
        {
            Console.WriteLine();
            Console.WriteLine(new String('-', 25) + shape.Name + new String('-', 25));
            Console.WriteLine(shape);
        }
        else Console.WriteLine(shape);

        tempShape = shape;
    }

    Console.WriteLine("\n" + new String('-', 79) + "\n");
    Console.WriteLine($"• Average area of all shapes is: {Calculations.Item1.ToString("F2", Shape.Culture)}cm. \n");

    if (shapeCounters.ContainsKey(Shape.Shapes.Triangle))
    {
        Console.WriteLine($"• Total circumference of all triangles is: {Calculations.Item2.ToString("F2", Shape.Culture)}cm. \n");
    }

    Console.WriteLine($"• The shape with the biggest volume is a \"{Calculations.Item3}\" and the volume is: {Calculations.Item4.ToString("F2", Shape.Culture)}cm^3\n");

    for (int i = shapeCounters.Count - 1; i >= 0; i--)
    {
        if (shapeCounters.ElementAt(0).Value == shapeCounters.ElementAt(i).Value)
        {
            switch (i)
            {
                case 5:
                    pairFound = true;
                    Console.WriteLine($"• The most common shapes are \"{shapeCounters.ElementAt(0).Key}\", \"{shapeCounters.ElementAt(1).Key}\", \"{shapeCounters.ElementAt(2).Key}\", \"{shapeCounters.ElementAt(3).Key}\", \"{shapeCounters.ElementAt(4).Key}\" and \"{shapeCounters.ElementAt(5).Key}\" with the amount: {shapeCounters.ElementAt(0).Value}");
                    break;
                case 4:
                    pairFound = true;
                    Console.WriteLine($"• The most common shapes are \"{shapeCounters.ElementAt(0).Key}\", \"{shapeCounters.ElementAt(1).Key}\", \"{shapeCounters.ElementAt(2).Key}\", \"{shapeCounters.ElementAt(3).Key}\" and \"{shapeCounters.ElementAt(4).Key}\" with the amount: {shapeCounters.ElementAt(0).Value}");
                    break;
                case 3:
                    pairFound = true;
                    Console.WriteLine($"• The most common shapes are \"{shapeCounters.ElementAt(0).Key}\", \"{shapeCounters.ElementAt(1).Key}\", \"{shapeCounters.ElementAt(2).Key}\" and \"{shapeCounters.ElementAt(3).Key}\" with the amount: {shapeCounters.ElementAt(0).Value}");
                    break;
                case 2:
                    pairFound = true;
                    Console.WriteLine($"• The most common shapes are \"{shapeCounters.ElementAt(0).Key}\", \"{shapeCounters.ElementAt(1).Key}\" and \"{shapeCounters.ElementAt(2).Key}\" with the amount: {shapeCounters.ElementAt(0).Value}");
                    break;
                case 1:
                    pairFound = true;
                    Console.WriteLine($"• The most common shapes are \"{shapeCounters.ElementAt(0).Key}\" and \"{shapeCounters.ElementAt(1).Key}\" with the amount: {shapeCounters.ElementAt(0).Value}");
                    break;
                default:
                    Console.WriteLine($"• The most common shape is a \"{shapeCounters.ElementAt(0).Key}\" with the amount: {shapeCounters.ElementAt(0).Value}");
                    break;
            }
            if (pairFound)
                break;
        }
    }
}