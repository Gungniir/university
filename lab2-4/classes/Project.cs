using lab2_4.attributes;

namespace lab2_4.classes;

[HorizontalAlignment]
public class Project
{
    public string Name { get; set; } = "";
    public string Description { get; set; } = "";
    [NotPrintable]
    public string Secret { get; set; } = "";
    public int StudentId = 0;
}