using Car_Rental.Common.Enums;

namespace Car_Rental.Common.Interfaces;

public interface IVehicle
{
    public string RegistrationNumber { get; init; }
    public string Make { get; init; }
    public VehicleTypes Type { get; }
    public int Odometer { get; set; }
    public double CostPerKm { get; init; }
    public int CostPerDay { get; init; }
    public VehicleStatuses Status { get; set; }
    public int Id { get; init; }

    public void BookVehicle();
    public void ReturnVehicle();
}

