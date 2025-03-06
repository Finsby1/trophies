namespace Trophies;

public class Trophy
{
    private string _competition;
    private int _year;

    public int Id { get; set; }

    public string Competition
    {
        get => _competition;
        set
        {
            if (value == null)
            {
                throw new ArgumentNullException("Competition cannot be null.");
            }

            if (value.Length < 3)
            {
                throw new ArgumentException("Competition must be at least 3 characters long.");
            }
            _competition = value;
        }
    }

    public int Year
    {
        get => _year;
        set
        {
            if (value < 1970 || value > DateTime.Now.Year)
            {
                throw new ArgumentOutOfRangeException($"Year must be between 1970 and {DateTime.Now.Year}.");
            }
            _year = value;
        }
    }

    public Trophy(int id, string competition, int year)
    {
        Id = id;
        Competition = competition;
        Year = year;
    }

    public Trophy(Trophy trophy)
    {
        Id = trophy.Id;
        Competition = trophy.Competition;
        Year = trophy.Year;
    }

    public Trophy()
    {
        
    }


    public override string ToString()
    {
        return $"Id: {Id}, Competition: {Competition}, Year: {Year}";
    }
}