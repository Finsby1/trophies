using System.Security.Cryptography;
using Trophies;

namespace TrophiesRepositoryTest;

[TestClass]
public class TrophiesRepositoryTests
{
    private TrophiesRepository _repo = new();
    
    
    [TestMethod]
    public void GetTrophyByIdTest()
    {
        Assert.IsNotNull(_repo.GetTrophyById(1));
        Assert.IsNull(_repo.GetTrophyById(100));
    }

    [TestMethod]
    public void GetTrophiesTest()
    {
        IEnumerable<Trophy> trophies = _repo.GetTrophies();
        Assert.AreEqual(5, trophies.Count());
        Assert.AreEqual(trophies.First().Competition, "Competition A");
        
        IEnumerable<Trophy> sortedTrophies = _repo.GetTrophies(sortBy: "Competition");
        Assert.AreEqual(sortedTrophies.First().Competition, "Competition A");
        
        IEnumerable<Trophy> sortedTrophies2 = _repo.GetTrophies(sortBy: "Year");
        Assert.AreEqual(sortedTrophies2.First().Competition, "Competition A");
    }

    [TestMethod]
    public void RemoveTrophyTest()
    {
        Assert.IsNull(_repo.RemoveTrophy(100));
        Assert.AreEqual(1, _repo.RemoveTrophy(1)?.Id);
        Assert.AreEqual(4, _repo.GetTrophies().Count());
    }

    [TestMethod]
    public void UpdateTrophyTest()
    {
        Assert.AreEqual(5, _repo.GetTrophies().Count());
        Trophy newTrophy = new() { Competition = "test", Year = 2023 };
        Assert.IsNull(_repo.UpdateTrophy(100, newTrophy));
        Assert.AreEqual(1, _repo.UpdateTrophy(1, newTrophy)?.Id);
        Assert.AreEqual(5, _repo.GetTrophies().Count());
    }
}