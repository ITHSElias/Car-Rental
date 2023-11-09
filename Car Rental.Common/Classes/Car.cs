using Car_Rental.Common.Enums;
using Car_Rental.Common.Interfaces;

namespace Car_Rental.Common.Classes;

public class Car : Vehicle
{
    

    public new VehicleTypes Type { get; init; }

    public Car(string regNo, string make, VehicleTypes type, int odometer, double costPerKm, int costPerDay, int id) : base (type) =>
        (RegistrationNumber, Make, Type, Odometer, CostPerKm, CostPerDay, Id) = (regNo, make, type, odometer, costPerKm, costPerDay, id);
    
}

