namespace test1.task3;

public class Building : IHaveId, IEquatable<Building>
{
    public int Id { get; set; }
    public int OwnerId { get; set; }
    public string Adress { get; set; } = string.Empty;
    public int DeprecationPeriod { get; set; }
    public decimal StartPrice { get; set; }
    public DateOnly StartDate { get; set; }

    public bool Equals(Building? other)
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
        return Equals((Building) obj);
    }

    public override int GetHashCode()
    {
        return Id;
    }
}