using Solution;

#region Part 1
//Q1 : Explain with code example how class and struct behave differently in C#?
//A1 : In C#, classes are reference types, while structs are value types. 
//This means that when you create an instance of a class, it is stored on the heap and accessed through a reference. 
Student std1 = new()
{
    Name = "Ahmed"
};
Student std2 = std1; // std2 is a reference to the same object as std1
std2.Name = "Ali"; // Modifying std2 also modifies std1 because they reference the same object
Console.WriteLine(std1.Name); // Output: Ali   
Console.WriteLine(std2.Name); // Output: Ali

//On the other hand, when you create an instance of a struct, it is stored on the stack and accessed directly.
Point pt1 = new()
{
    X = 10
};
Point pt2 = pt1; // pt2 is a copy of pt1
pt2.X = 20; // Modifying pt2 does not affect pt1
Console.WriteLine($"pt1.X: {pt1.X}, pt2.X: {pt2.X}");// Output: pt1.X: 10, pt2.X: 20

//Q2 : Explain the difference between public and private access modifiers with an example. 
//A2 : In C#, access modifiers control the visibility of class members. 
//The public access modifier: allows members to be accessed from any code.
//The internal access modifier: allows members to be accessed only within the same assembly.
//The private access modifier: allows members to be accessed only within the same class.
MyClass myObj = new()
{
    PublicField = 10, // Accessible from anywhere
    InternalField = 20 // Accessible only within the same assembly
    // myObj.PrivateField = 30; // This would cause a compile-time error because PrivateField is not accessible from outside the class
};
Console.WriteLine($"PublicField: {myObj.PublicField}, InternalField: {myObj.InternalField}"); // Output: PublicField: 10, InternalField: 20

//Q3 : Describe the steps to create and use a class library in Visual Studio.
//A3 : To create and use a class library in Visual Studio, follow these steps:
//1. Open Visual Studio and create a new project.
//2. Select "Class Library" from the project templates and click "Next".
//3. Name your project and click "Create".
//then call it in your main project by adding a reference to the class library project and using the appropriate namespaces.

//Q4 : What is a class library? Why do we use class libraries?
//A4 : A class library is a collection of precompiled classes, interfaces, and other types that can be used by applications.
//We use class libraries to promote code reuse, modularity, and maintainability.
#endregion

#region Part 2: Movie Ticket Booking System
Console.WriteLine("\n--- Movie Ticket Booking System ---");
//1.Each ticket has a type that can only be one of: Standard, VIP, or IMAX. How would you represent this?
//A1 : With Enum.

//2.You need a type to represent a seat location (Row as a char like 'A', 'B', and Number as an int). 
//Should this be a class or a struct? Create it.
//A2 : It should be a struct because it is a simple data type.

//3.Create a Ticket class with: 
//a.MovieName(public), 
//b.Type (public)
//c.Seat (public)
//d.Price (private). 
//---- Sometimes a ticket is created with all info, sometimes with just the movie	 
//name(default type Standard, seat A1, price 50).Handle both without repeating initialization logic.
/*
public TicketTypes Type { get; set; } = type == default ? TicketTypes.Standard : type;
public SeatLocation Seat { get; set; } = seat ?? new SeatLocation { Row = 'A', Number = 1 };
private decimal Price { get; } = price == default ? 50 : price;
*/


//Create a Console Application. Read the ticket data from the user, then print the following output:
Console.Write("Enter movie name: ");
string movieName = Console.ReadLine() ?? "Avengers";

Console.Write("Enter Ticket Type (0 = Standard , 1 = VIP , 2 = IMAX ): ");
TicketTypes type = Enum.Parse<TicketTypes>(Console.ReadLine() ?? "Standard");

Console.Write("Enter Seat Row (A, B, C...): ");
char row = Console.ReadLine()?.FirstOrDefault() ?? 'A';
row = char.ToUpper(row);

Console.Write("Enter Seat Number: ");
int number = int.Parse(Console.ReadLine() ?? "1");

Console.Write("Enter ticket price: ");
decimal price = decimal.Parse(Console.ReadLine() ?? "50");
decimal totalPrice = price + (price * 0.14m); // Assuming a tax of 14%

Console.Write("Enter Discount Amount: ");
double discountAmount = double.Parse(Console.ReadLine() ?? "0");

Console.WriteLine("\n----- Ticket INFO -----");
Console.WriteLine($"Movie Name: {movieName}");
Console.WriteLine($"Ticket Type: {type}");
Console.WriteLine($"Seat: {row}{number}");
Console.WriteLine($"Price: ${price:F2}");
Console.WriteLine($"Total (14% tax): ${totalPrice:F2}");

Console.WriteLine("===== After Discount =====");
Console.WriteLine($"Discount Before: {discountAmount}");
Ticket ticket = new(movieName, type, new SeatLocation { Row = row, Number = number }, price);
ticket.PrintDetails();
#endregion