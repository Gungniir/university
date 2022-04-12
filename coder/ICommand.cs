namespace coder;

public interface ICommand
{
    public string Signature { get; }
    public string Description { get; }
    public string HelpPage { get; }

    public void Run(string command);
}