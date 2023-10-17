using Car_Rental.Common.Enums;
using Car_Rental.Common.Interfaces;

namespace Car_Rental.Data.Interfaces;

public interface IData
{
    IEnumerable<IPerson> GetPersons();
    IEnumerable<IVehicle> GetVehicles(VehicleStatuses status = default);
    IEnumerable<IBooking> GetBookings();
    //IBooking GetBooking(int vehicleId);
    //IPerson GetPerson(string socialSecurityNumber);
    //IPerson GetPerson(int id);
    //IVehicle GetVehicle(string registrationNumber);
    //IVehicle GetVehicle(int id);
}

