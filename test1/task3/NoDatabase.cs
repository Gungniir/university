namespace test1.task3;

public class NoDatabase : IDatabase
{
    private readonly List<Building> _buildings = new();
    private readonly List<Person> _persons = new();

    public List<Building> SelectAllBuildings()
    {
        return _buildings;
    }

    public Building? SelectBuildingById(int id)
    {
        return _buildings.Find(building => building.Id == id);
    }

    public List<Building> SelectBuildingByOwnerId(int ownerId)
    {
        return _buildings.FindAll(building => building.OwnerId == ownerId);
    }

    public Building InsertBuilding(Building building)
    {
        building.Id = _buildings.Count > 0 ? _buildings.Last().Id + 1 : 1;
        _buildings.Add(building);
        return building;
    }

    public Building UpdateBuilding(Building building)
    {
        Building? originalBuilding = _buildings.Find(item => item.Id == building.Id);

        if (originalBuilding is null)
        {
            throw new Exception("Not found");
        }

        originalBuilding.Adress = building.Adress;
        originalBuilding.DeprecationPeriod = building.DeprecationPeriod;
        originalBuilding.OwnerId = building.OwnerId;
        originalBuilding.StartDate = building.StartDate;
        originalBuilding.StartPrice = building.StartPrice;

        return originalBuilding;
    }

    public bool DeleteBuilding(Building building)
    {
        return _buildings.Remove(building);
    }

    public Building? SelectExpensiveBuilding()
    {
        return _buildings.MaxBy(item => item.StartPrice);
    }

    public List<Building> SelectDeprecatedBuildings()
    {
        return _buildings.FindAll(building =>
        {
            DateOnly d = building.StartDate.AddYears(building.DeprecationPeriod);
            return d.CompareTo(DateOnly.FromDateTime(DateTime.Today)) <= 0;
        });
    }

    public List<Person> SelectAllPersons()
    {
        return _persons;
    }

    public Person? SelectPersonById(int id)
    {
        return _persons.Find(person => person.Id == id);
    }

    public Person InsertPerson(Person person)
    {
        person.Id = _persons.Count > 0 ? _persons.Last().Id + 1 : 1;
        _persons.Add(person);
        return person;
    }

    public Person UpdatePerson(Person person)
    {
        Person? originalPerson = _persons.Find(item => item.Id == person.Id);

        if (originalPerson is null)
        {
            throw new Exception("Not found");
        }

        originalPerson.Fio = person.Fio;

        return originalPerson;
    }

    public bool DeletePerson(Person person)
    {
        return _persons.Remove(person);
    }
}