namespace Car_Rental.Common.Extensions;

public static class Extensions
{
	public static int Duration(this DateOnly initialDate, DateOnly endDate)
	{
        return endDate.DayNumber - initialDate.DayNumber + 1;
    }
}

