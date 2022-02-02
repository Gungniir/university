namespace test1.task3;

public class Person : IHaveId, IEquatable<Person>
{
    public int Id { get; set; }
    public string Fio { get; set; } = "";
    public string Position { get; set; } = "";

    public List<Building> GetBuildings(IDatabase db)
    {
        return db.SelectBuildingByOwnerId(Id);
    }

    public bool Equals(Person? other)
    {
        if (ReferenceEquals(null, other)) return false;
        if (ReferenceEquals(this, other)) return true;
        return Id == other.Id;
    }

    public override bool Equals(object? obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != this.GetType()) return false;
        return Equals((Person) obj);
    }

    public override int GetHashCode()
    {
        return Id;
    }
}