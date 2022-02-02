namespace test1.task3;

public interface IDatabase
{
    public List<Building> SelectAllBuildings();
    public Building? SelectBuildingById(int id);
    public List<Building> SelectBuildingByOwnerId(int ownerId);
    public Building InsertBuilding(Building building);
    public Building UpdateBuilding(Building building);
    public bool DeleteBuilding(Building building);
    public Building? SelectExpensiveBuilding();
    public List<Building> SelectDeprecatedBuildings();
    
    public List<Person> SelectAllPersons();
    public Person? SelectPersonById(int id);
    public Person InsertPerson(Person person);
    public Person UpdatePerson(Person person);
    public bool DeletePerson(Person person);
}