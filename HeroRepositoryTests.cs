using System;
using NUnit.Framework;

public class HeroRepositoryTests
{
    [Test]

    public void CreateHeroPropperties()
    {
        Hero hero = new Hero("Sam", 1);
        Assert.AreEqual(hero.Name, "Sam");
        Assert.AreEqual(hero.Level, 1);
    }
    [Test]

    public void CreateHeroThrowsNull()
    {
        HeroRepository repository = new HeroRepository();
        Hero hero = null;

        Assert.Throws<ArgumentNullException>(() => repository.Create(hero));
            
        
    }
    [Test]

    public void CreateHeroThrowsIOE()
    {
        HeroRepository repository = new HeroRepository();
        Hero hero = new Hero("Sam", 1);
        repository.Create(hero);

        Assert.Throws<InvalidOperationException>(() => repository.Create(new Hero("Sam", 5)));
    }
    [Test]

    public void CreateHero()
    {
        HeroRepository repository = new HeroRepository();
        Hero hero = new Hero("Sam", 1);
       
        Assert.AreEqual(repository.Create(hero), "Successfully added hero Sam with level 1");

        
    }

    [TestCase(null)]
    [TestCase(" ")]
    public void RemoveHero(string name)
    {
        HeroRepository repository = new HeroRepository();
        Hero hero = new Hero (null, 1);
        Hero hero1 = new Hero (" ", 1);
        repository.Create(hero);
        Assert.Throws<ArgumentNullException>(() => repository.Remove(name));
       
    }
    [Test]
    public void RemoveHeroCorrectlyreturnsTrue()
    {
        HeroRepository repository = new HeroRepository();
        Hero hero = new Hero("Sam", 1);
        
        repository.Create(hero);
        
        Assert.AreEqual(repository.Remove("Sam"), true);
       
    }
    [Test]
    public void GetsHeroWithHiLevel()
    {
        HeroRepository repository = new HeroRepository();
        Hero hero = new Hero("Sam", 1);
        Hero hero1 = new Hero("Sa", 2);

        repository.Create(hero);
        repository.Create(hero1);

        Assert.AreEqual(repository.GetHeroWithHighestLevel(), hero1);

    }
    [Test]
    public void GetsHeroWitName()
    {
        HeroRepository repository = new HeroRepository();
        Hero hero = new Hero("Sam", 1);
        Hero hero1 = new Hero("Sa", 2);

        repository.Create(hero);
        repository.Create(hero1);

        Assert.AreEqual(repository.GetHero("Sa"), hero1);

    }


}