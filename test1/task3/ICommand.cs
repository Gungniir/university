namespace test1.task3;

public interface ICommand: IEquatable<string>
{
    public string Signature { get; }
    public string Description { get; }

    public void Run();
}