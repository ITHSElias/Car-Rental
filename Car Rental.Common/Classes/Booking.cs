using Car_Rental.Common.Interfaces;

namespace Car_Rental.Common.Classes;

public class Booking : IBooking
{
    public IPerson BookingCustomer { get; init; }
    public IVehicle BookingVehicle { get; init; }
    public int KmDriven { get; set; } = 0;
    public int DaysRented { get; set; }
    public double Cost { get; set; }
    public bool BookingClosed { get; set; }
    public DateOnly InitialDate { get; init; }
    public DateOnly ClosingDate { get; set; }


    public Booking(IPerson bookingCustomer, IVehicle bookingVehicle, bool bookingClosed, DateOnly initalDate, DateOnly closingDate, int kmDriven)                                                                    
    {
        (BookingCustomer, BookingVehicle, BookingClosed, InitialDate, ClosingDate, KmDriven) = (bookingCustomer, bookingVehicle, bookingClosed, initalDate, closingDate, kmDriven);

        BookingVehicle.BookVehicle();

        if(BookingClosed)
        {
            ReturnVehicle(BookingVehicle);
        }
    }

    public double CalculateCost(IVehicle vehicle, int kmDriven, int DaysRented)
    {
        return BookingVehicle.CostPerKm * KmDriven + BookingVehicle.CostPerDay * DaysRented;
    }
    void ReturnVehicle(IVehicle vehicle)
    {
        DaysRented = (ClosingDate.DayNumber - InitialDate.DayNumber) + 1;
        BookingVehicle.Odometer += KmDriven;
        Cost = CalculateCost(BookingVehicle, KmDriven, DaysRented);
        BookingVehicle.ReturnVehicle();
    }
}

