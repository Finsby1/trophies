using Trophies;

namespace TrophyTest;

[TestClass]
public class TrophyTests
{
    private readonly Trophy _trophy = new Trophy(1, "Run", 1970);
    
    [TestMethod]
    public void TrophyTest1()
    {
        Assert.AreEqual(1, _trophy.Id);
        Assert.AreEqual("Run", _trophy.Competition);
        Assert.AreEqual(1970, _trophy.Year);
        
        Assert.ThrowsException<ArgumentNullException>(() => _trophy.Competition = null);
        Assert.ThrowsException<ArgumentException>(() => _trophy.Competition = "");
        Assert.ThrowsException<ArgumentOutOfRangeException>(() => _trophy.Year = 1969);
        Assert.ThrowsException<ArgumentOutOfRangeException>(() => _trophy.Year = DateTime.Now.Year + 1);
    }
}