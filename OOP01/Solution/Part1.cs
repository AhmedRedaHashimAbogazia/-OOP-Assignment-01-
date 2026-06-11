namespace Solution;

public class Student
{
    public string? Name;
}

public struct Point
{
    public double X;
    public double Y;
}

public class MyClass
{
    public int PublicField = 0; // Accessible from anywhere
    internal int InternalField = 0; // Accessible only within the same assembly
    private int PrivateField = 0; // Accessible only within this class
}