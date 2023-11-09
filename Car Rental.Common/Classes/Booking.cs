using Car_Rental.Common.Interfaces;
using Car_Rental.Common.Extensions;

namespace Car_Rental.Common.Classes;

public class Booking : IBooking
{
    public IPerson BookingCustomer { get; init; }
    public IVehicle BookingVehicle { get; init; }
    public int? KmDriven { get; set; }
    public int DaysRented { get; set; }
    public double Cost { get; set; }
    public bool BookingClosed { get; set; }
    public DateOnly InitialDate { get; init; }
    public DateOnly? ClosingDate { get; set; }
    public int Id { get; init; }
    

    public Booking(IPerson bookingCustomer, IVehicle bookingVehicle, bool bookingClosed, DateOnly? initialDate, DateOnly? closingDate, int? kmDriven, int id)                                                                    
    {
        initialDate ??= DateOnly.FromDateTime(DateTime.Today);
        if (closingDate is not null)
            ClosingDate = (DateOnly)closingDate;

        (BookingCustomer, BookingVehicle, BookingClosed, InitialDate, KmDriven, Id) = (bookingCustomer, bookingVehicle, bookingClosed, (DateOnly)initialDate, kmDriven, id);

        BookingVehicle.BookVehicle();

        if(BookingClosed)
        {
            ReturnVehicle((int)KmDriven);
        }
    }

    public double CalculateCost(IVehicle vehicle, int kmDriven, int daysRented)
    {
        return vehicle.CostPerKm * kmDriven + vehicle.CostPerDay * daysRented;
    }
    public void ReturnVehicle(int kmDriven)
    {
        BookingClosed = true;

        ClosingDate ??= DateOnly.FromDateTime(DateTime.Today);
        DateOnly closingDate = (DateOnly)ClosingDate; // DateOnly.DayNumber ville inte fungera med nullable "DateOnly?" och det gick inte att casta... 
        DaysRented = InitialDate.Duration(closingDate);

        KmDriven ??= kmDriven;
        Cost = CalculateCost(BookingVehicle, (int)KmDriven, DaysRented);

        BookingVehicle.Odometer += (int)KmDriven;
        BookingVehicle.ReturnVehicle();
    }
}

