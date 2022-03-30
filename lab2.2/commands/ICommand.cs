namespace lab2._2.commands;

public interface ICommand
{
    public string Signature { get; }
    public string Description { get; }

    public void Run();
}