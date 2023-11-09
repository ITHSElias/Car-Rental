using System.Runtime.Intrinsics.X86;
using System.Text.RegularExpressions;
using Car_Rental.Common.Classes;
using Car_Rental.Common.Enums;
using Car_Rental.Common.Interfaces;
using Car_Rental.Data.Interfaces;

namespace Car_Rental.Business.Classes;

public class BookingProcessor
{
    public string InputRegNo { get; set; } = string.Empty;
    public string InputMake { get; set; } = string.Empty;
    public int InputOdometer { get; set; }
    public double InputCostPerKm { get; set; }
    public int InputCostPerDay { get; set; }
    public VehicleTypes InputVehicleType { get; set; }

    public string InputSSN { get; set; } = string.Empty;
    public string InputLastName { get; set; } = string.Empty;
    public string InputFirstName { get; set; } = string.Empty;

    public string InputBookingCustomerSSN { get; set; } = string.Empty;

    public int InputReturnDistance { get; set; }

    public string Message { get; set; } = string.Empty;

    public bool OngoingProcess { get; set; } = false;

    private readonly IData _db;

    public BookingProcessor(IData db) => _db = db;

    public IEnumerable<IPerson> GetCustomers() => _db.Get<IPerson>(null);
    
    public IEnumerable<IVehicle> GetVehicles(VehicleStatuses status = default) => _db.Get<IVehicle>(null);
 
    public IEnumerable<IBooking> GetBookings() => _db.Get<IBooking>(null);

    public string[] VehicleStatusNames => _db.VehicleStatusNames();
    public string[] VehicleTypeNames => _db.VehicleTypeNames();





    
    public IPerson? GetPerson(string ssn) 
    {
        return _db.Single<IPerson>(p => p.SSN == ssn);
    }
    public IVehicle? GetVehicle(string regNo) 
    {
        return _db.Single<IVehicle>(v => v.RegistrationNumber == regNo);
    }
    

    
    public async Task RentVehicle(string regNo, string
    ssn)
    {
        OngoingProcess = true;
        await Task.Delay(3000);
        OngoingProcess = false;

        IPerson? customer = GetPerson(ssn);
        IVehicle? vehicle = GetVehicle(regNo);

        if (customer is null)
        {
            Message = "Couldn't find person";
            return;
        }
        if (vehicle is null)
        {
            Message = "Couldn't find car";
            return;
        }
        if (vehicle.Status == VehicleStatuses.Booked)
        {
            Message = "Vehicle is not available";
            return;
        }
        _db.Add<IBooking>(new Booking(customer, vehicle, false, null, null, null, _db.NextBookingId));
        vehicle.BookVehicle();

    }
    
    public void ReturnVehicle(string bookingVehicleRegNo) 
    {
        if(GetVehicle(bookingVehicleRegNo) is null)
        {
            Message = "Could not find vehicle to return";
            return;
        }
        IVehicle bookingVehicle = GetVehicle(bookingVehicleRegNo);

        if (_db.Single<IBooking>(b => b.BookingVehicle == bookingVehicle && b.BookingClosed == false) is null)
        {
            Message = "Could not find booking";
            return;
        }

        _db.Single<IBooking>(b => b.BookingVehicle == bookingVehicle && b.BookingClosed == false).ReturnVehicle(InputReturnDistance); 
    }
    public void AddVehicle(string regNo, string make, VehicleTypes type, int
    odometer, double costKm, int costDay) 
    {
        if(regNo == string.Empty || make == string.Empty)
        {
            Message = "please fill in all the fields";
            return;
        }
        if(GetVehicle(regNo) is not null)
        {
            Message = "This vehicle already exists (Matching registration number)";
            return;
        }
        if (type == VehicleTypes.Motorcycle)
            _db.Add<IVehicle>(new Motorcycle(regNo, make, type, odometer, costKm, costDay, _db.NextVehicleId));
        else
            _db.Add<IVehicle>(new Car(regNo, make, type, odometer, costKm, costDay, _db.NextVehicleId));

        foreach(var v in _db.Get<IVehicle>(null))
        {
            Console.WriteLine(v.Type);
        }
        Console.WriteLine(GetVehicle("ABC123").Type);
    }
    
    public void AddCustomer(string ssn, string firstName, string
    lastName) 
    {
        if(ssn == string.Empty || firstName == string.Empty || lastName == string.Empty)
        {
            Message = "Please fill in all the fields";
            return;
        }
        if(GetPerson(ssn) is not null)
        {
            Message = "This person already exists (Matching social security number)";
            return;
        }
        _db.Add<IPerson>(new Customer(lastName, firstName, ssn, _db.NextPersonId));
    }
    
    public void ClearMessage()
    {
        Message = string.Empty;
    }
}

