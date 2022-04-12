namespace coder;

public abstract class CommandWithFlags : ICommand
{
    public abstract string Signature { get; }
    public abstract string Description { get; }
    public abstract string HelpPage { get; }

    protected List<(string, string)> Flags = new();

    protected void ParseFlags(string command)
    {
        Flags = new();

        var flags = command.Split(' ');

        string key = "";

        for (int i = 0; i < flags.Length; i++)
        {
            if (string.IsNullOrEmpty(key) || key.StartsWith("-"))
            {
                if (flags[i].StartsWith("--"))
                {
                    key = flags[i][2..];
                    continue;
                }

                if (flags[i].StartsWith("-"))
                {
                    foreach (var flag in flags[i])
                    {
                        Flags.Add((flag.ToString(), "true"));
                    }

                    continue;
                }

                continue;
            }

            Flags.Add((key, flags[i]));
            key = "";
        }

        if (!string.IsNullOrEmpty(key))
        {
            Flags.Add((key, "true"));
        }
    }

    protected string GetFlag(string flag)
    {
        return Flags.Find(tuple => tuple.Item1.Equals(flag)).Item2;
    }

    protected bool HasFlag(string flag)
    {
        return !string.IsNullOrEmpty(GetFlag(flag));
    }

    public abstract void Run(string command);
}