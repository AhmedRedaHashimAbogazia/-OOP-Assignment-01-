namespace Solution;

public enum TicketTypes
{
    Standard,
    VIP,
    IMAX
}

public class SeatLocation
{
    public char Row { get; set; }
    public int Number { get; set; }
}

class Ticket(string movieName, TicketTypes type, SeatLocation seat, decimal price)
{
    public string MovieName = movieName;
    public TicketTypes Type = type;
    public SeatLocation Seat = seat;
    public decimal TicketPrice { get; } = price;
    public Ticket(string movieName) //constructor chaining
        : this(
            movieName,
            TicketTypes.Standard,
            new SeatLocation { Row = 'A', Number = 1 },
            50m)
    {
    }
    // a. Calculate total after tax
    public decimal CalcTotal(double taxPercent)
    {
        return TicketPrice + (TicketPrice * (decimal)(taxPercent / 100));
    }
    // b. Apply discount
    public decimal ApplyDiscount(double discountAmount)
    {
        if (0 < discountAmount && discountAmount < (double)TicketPrice)
        {
            return TicketPrice - (decimal)discountAmount;
        }
        return TicketPrice;
    }
    // c. Print ticket details
    public void PrintDetails()
    {
        Console.WriteLine($"name: {MovieName},type: {Type},seat: {Seat.Row}{Seat.Number},price: {TicketPrice}");
    }
}