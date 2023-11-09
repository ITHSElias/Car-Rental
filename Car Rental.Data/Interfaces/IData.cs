using System.Linq.Expressions;
using Car_Rental.Common.Enums;
using Car_Rental.Common.Interfaces;

namespace Car_Rental.Data.Interfaces;

public interface IData
{
    List<T> Get<T>(Func<T, bool>? expression);
    T? Single<T>(Func<T, bool>? expression);
    public void Add<T>(T item);

    int NextVehicleId { get; }
    int NextPersonId { get; }
    int NextBookingId { get; }

    public string[] VehicleStatusNames() => Enum.GetNames(typeof(VehicleStatuses));
    public string[] VehicleTypeNames() => Enum.GetNames(typeof(VehicleTypes));
}

