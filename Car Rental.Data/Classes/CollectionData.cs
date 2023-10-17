using Car_Rental.Common.Classes;
using Car_Rental.Common.Enums;
using Car_Rental.Common.Interfaces;
using Car_Rental.Data.Interfaces;

namespace Car_Rental.Data;

public class CollectionData : IData
{
    readonly List<IPerson> _persons = new List<IPerson>();
    readonly List<IVehicle> _vehicles = new List<IVehicle>();
    readonly List<IBooking> _bookings = new List<IBooking>();

    public CollectionData() => SeedData();

    void SeedData()
    {
        _vehicles.Add(new Car("ABC123", "Volvo", VehicleTypes.Combi, 5000, 2.5, 100));
        _vehicles.Add(new Car("JDK884", "Volkswagen", VehicleTypes.Van, 10000, 1.5, 50));
        _vehicles.Add(new Car("SGT591", "Saab", VehicleTypes.Sedan, 7000, 2, 75));
        _vehicles.Add(new Car("NMH870", "Tesla", VehicleTypes.Sedan, 1000, 3, 200));
        _vehicles.Add(new Motorcycle("DDG546", "Yamaha", 20000, 0.5, 500));

        _persons.Add(new Customer("Andersson", "Herbert", 56071));
        _persons.Add(new Customer("Lind", "Berit", 98122));

        _bookings.Add(new Booking(_persons.SingleOrDefault(c => c.SSN == 56071),
                                  _vehicles.SingleOrDefault(v => v.RegistrationNumber == "JDK884"),
                                  false, new DateOnly(2023, 10, 10), new DateOnly(2023, 10, 12), 200));
        _bookings.Add(new Booking(_persons.SingleOrDefault(c => c.SSN == 98122),
                                  _vehicles.SingleOrDefault(v => v.RegistrationNumber == "DDG546"),
                                  true, new DateOnly(2023, 10, 7), new DateOnly(2023, 10, 8), 100));
    }

    public IEnumerable<IPerson> GetPersons() => _persons;
    public IEnumerable<IBooking> GetBookings() => _bookings;
    public IEnumerable<IVehicle> GetVehicles(VehicleStatuses status = 0) => _vehicles;
    
}

