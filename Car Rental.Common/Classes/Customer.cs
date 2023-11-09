using Car_Rental.Common.Interfaces;

namespace Car_Rental.Common.Classes;

public class Customer : IPerson
{
    public string LastName { get; init; }
    public string FirstName { get; init; }
    public string SSN { get; init; }
    public int Id { get; init; }

    public Customer(string lastName, string firstName, string ssn, int id) =>
        (LastName, FirstName, SSN, Id) = (lastName, firstName, ssn, id);
}

