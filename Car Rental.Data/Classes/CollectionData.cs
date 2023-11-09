using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
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

    public int NextVehicleId => _vehicles.Count == 0 ? 1 : _vehicles.Max(b => b.Id + 1);
    public int NextPersonId => _persons.Count == 0 ? 1 : _persons.Max(b => b.Id + 1);
    public int NextBookingId => _bookings.Count == 0 ? 1 : _bookings.Max(b => b.Id + 1);

    public CollectionData() => SeedData();

    void SeedData()
    {
        _vehicles.Add(new Car("ABC123", "Volvo", VehicleTypes.Combi, 5000, 2.5, 100, NextVehicleId));
        _vehicles.Add(new Car("JDK884", "Volkswagen", VehicleTypes.Van, 10000, 1.5, 50, NextVehicleId));
        _vehicles.Add(new Car("SGT591", "Saab", VehicleTypes.Sedan, 7000, 2, 75, NextVehicleId));
        _vehicles.Add(new Car("NMH870", "Tesla", VehicleTypes.Sedan, 1000, 3, 200, NextVehicleId));
        _vehicles.Add(new Motorcycle("DDG546", "Yamaha", VehicleTypes.Motorcycle, 20000, 0.5, 500, NextVehicleId));

        _persons.Add(new Customer("Andersson", "Herbert", "56071", NextPersonId));
        _persons.Add(new Customer("Lind", "Berit", "98122", NextPersonId));

        _bookings.Add(new Booking(_persons.SingleOrDefault(c => c.SSN == "56071"),
                                  _vehicles.SingleOrDefault(v => v.RegistrationNumber == "JDK884"),
                                  false, new DateOnly(2023, 10, 10), null, null, NextBookingId));
        _bookings.Add(new Booking(_persons.SingleOrDefault(c => c.SSN == "98122"),
                                  _vehicles.SingleOrDefault(v => v.RegistrationNumber == "DDG546"),
                                  true, new DateOnly(2023, 10, 7), new DateOnly(2023, 10, 8), 100, NextBookingId));
    }

    public List<T> Get<T>(Func<T, bool>? expression)
    {
        FieldInfo? collections = GetType()
            .GetFields(BindingFlags.NonPublic | BindingFlags.Instance)
            .FirstOrDefault(f => f.FieldType == typeof(List<T>) && f.IsInitOnly) ?? throw new InvalidOperationException("Unsupported type");

        var value = collections.GetValue(this) ?? throw new InvalidDataException();

        var collection = (List<T>)value;

        return expression is null ? collection : collection.Where(expression).ToList();  
    }

    public T? Single<T>(Func<T, bool>? expression)
    {
        return Get<T>(null).SingleOrDefault(expression);
    }

    public void Add<T>(T item)
    {
        Get<T>(null).Add(item);
    }

    public string[] VehicleStatusNames() => Enum.GetNames(typeof(VehicleStatuses));
    public string[] VehicleTypeNames() => Enum.GetNames(typeof(VehicleTypes));
}

