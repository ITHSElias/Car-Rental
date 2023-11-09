namespace Car_Rental.Common.Interfaces;

public interface IBooking
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

    public double CalculateCost(IVehicle vehicle, int kmDriven, int DaysRented);
    public void ReturnVehicle(int kmDriven);
}