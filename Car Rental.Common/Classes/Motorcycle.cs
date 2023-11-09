using Car_Rental.Common.Enums;
using Car_Rental.Common.Interfaces;

namespace Car_Rental.Common.Classes;

public class Motorcycle : Vehicle
{    
    public new VehicleTypes Type { get; init; } = VehicleTypes.Motorcycle;

    public Motorcycle(string regNo, string make, VehicleTypes type, int odometer, double costPerKm, int costPerDay, int id) : base (type) =>
        (RegistrationNumber, Make, Odometer, CostPerKm, CostPerDay, Id) = (regNo, make, odometer, costPerKm, costPerDay, id);
}

