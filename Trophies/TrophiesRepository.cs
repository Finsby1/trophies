namespace Trophies;

public class TrophiesRepository
{
    private int _nextId = 1;
    private readonly List<Trophy> _trophies;

    public TrophiesRepository()
    {
        _trophies = new List<Trophy>
        {
            new Trophy(1, "Competition A", 2021),
            new Trophy(2, "Competition B", 2002),
            new Trophy(3, "Competition C", 2003),
            new Trophy(4, "Competition D", 2004),
            new Trophy(5, "Competition E", 2005)
        };
    }

    public List<Trophy> GetTrophies(int? year = null, string sortBy = null)
    {
        List<Trophy> trophiesCopy = _trophies.Select(t => new Trophy(t)).ToList();

        if (year.HasValue)
        {
            trophiesCopy = _trophies.Where(t => t.Year == year.Value).ToList();
        }
        
        if(!string.IsNullOrEmpty(sortBy))
        {
            switch (sortBy.ToLower())
            {
                case "competition":
                case"competition asc":
                    trophiesCopy = trophiesCopy.OrderBy(t => t.Competition).ToList();
                    break;
                case "competition desc":
                    trophiesCopy = trophiesCopy.OrderByDescending(t => t.Competition).ToList();
                    break;
                case "year":
                case "year asc":
                    trophiesCopy = trophiesCopy.OrderBy(t => t.Year).ToList();
                    break;
                case "year desc":
                    trophiesCopy = trophiesCopy.OrderByDescending(t => t.Year).ToList();
                    break;
                default:
                    break;
            }
        }
        return trophiesCopy;
    }
    
    public Trophy? GetTrophyById(int Id)
    {
        return _trophies.FirstOrDefault(t => t.Id == Id);
    }

    public Trophy? AddTrophy(Trophy trophy)
    {
        trophy.Id = _nextId++;
        _trophies.Add(trophy);
        return trophy;
    }

    public Trophy? RemoveTrophy(int id)
    {
        Trophy? trophy = GetTrophyById(id);
        if (trophy == null)
        {
            return null;
        }
        _trophies.Remove(trophy);
        return trophy;
    }

    public Trophy? UpdateTrophy(int id, Trophy values)
    {
        Trophy? trophy = GetTrophyById(id);
        if (trophy == null)
        {
            return null;
        }
        trophy.Competition = values.Competition;
        trophy.Year = values.Year;
        return trophy;
    }
    
    
}