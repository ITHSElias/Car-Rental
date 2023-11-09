using Car_Rental.Common.Enums;
using Car_Rental.Common.Interfaces;

namespace Car_Rental.Common.Classes
{
	public class Vehicle : IVehicle
	{
        public string RegistrationNumber { get; init; }
        public string Make { get; init; }
        public VehicleTypes Type { get; }
        public int Odometer { get; set; }
        public double CostPerKm { get; init; }
        public int CostPerDay { get; init; }
        public VehicleStatuses Status { get; set; } = VehicleStatuses.Available;
        public int Id { get; init; }

        public Vehicle(VehicleTypes type) =>
            Type = type;

        public void BookVehicle()
        {
            Status = VehicleStatuses.Booked;
        }
        public void ReturnVehicle()
        {
            Status = VehicleStatuses.Available;
        }
	}
}

