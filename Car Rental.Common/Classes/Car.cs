using Car_Rental.Common.Enums;
using Car_Rental.Common.Interfaces;

namespace Car_Rental.Common.Classes;

public class Car : IVehicle
{
    public string RegistrationNumber { get; init; }
    public string Make { get; init; }
    public VehicleTypes Type { get; init; }
    public int Odometer { get; set; }
    public double CostPerKm { get; init; }
    public int CostPerDay { get; init; }
    public VehicleStatuses Status { get; set; } = VehicleStatuses.Available;

    public Car(string regNo, string make, VehicleTypes type, int odometer, double costPerKm, int costPerDay) =>
        (RegistrationNumber, Make, Type, Odometer, CostPerKm, CostPerDay) = (regNo, make, type, odometer, costPerKm, costPerDay);

    public void BookVehicle()
    {
        Status = VehicleStatuses.Booked;
    }
    public void ReturnVehicle()
    {
        Status = VehicleStatuses.Available;
    }
}

