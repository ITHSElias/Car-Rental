namespace Car_Rental.Common.Interfaces;

public interface IPerson
{
    public string LastName { get; init; }
    public string FirstName { get; init; }
    public string SSN { get; init; }
    public int Id { get; init; }
}

