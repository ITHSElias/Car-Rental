using Car_Rental.Common.Interfaces;

namespace Car_Rental.Common.Classes;

public class Customer : IPerson
{
    public string LastName { get; init; }
    public string FirstName { get; init; }
    public int SSN { get; init; }

    public Customer(string lastName, string firstName, int ssn) =>
        (LastName, FirstName, SSN) = (lastName, firstName, ssn);
}

