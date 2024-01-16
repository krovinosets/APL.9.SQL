namespace DatabaseModels;

public class Specialization : ITable
{
    public uint Id { get; set; }
    public string Name { get; set; }

    public Specialization(string name)
    {
        Name = name;
    }
    
    public Specialization(){ }
    
    public override string ToString()
    {
        return  $$"""{Specialization record: [ID: {{Id}}, """ +
                $$"""Name: {{Name}}]}""";
    }
}