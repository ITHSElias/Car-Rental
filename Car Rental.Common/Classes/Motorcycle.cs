using Car_Rental.Common.Enums;
using Car_Rental.Common.Interfaces;

namespace Car_Rental.Common.Classes;

public class Motorcycle : IVehicle
{
    public string RegistrationNumber { get; init; }
    public string Make { get; init; }
    public VehicleTypes Type { get; } = VehicleTypes.Motorcycle;
    public int Odometer { get; set; }
    public double CostPerKm { get; init; }
    public int CostPerDay { get; init; }
    public VehicleStatuses Status { get; set; } = VehicleStatuses.Available;

    public Motorcycle(string regNo, string make, int odometer, double costPerKm, int costPerDay) =>
        (RegistrationNumber, Make, Odometer, CostPerKm, CostPerDay) = (regNo, make, odometer, costPerKm, costPerDay);

    public void BookVehicle()
    {
        Status = VehicleStatuses.Booked;
    }
    public void ReturnVehicle()
    {
        Status = VehicleStatuses.Available;
    }
}

