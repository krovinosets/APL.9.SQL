namespace DatabaseModels;

public class Doctor : ITable
{
    public uint Id { get; set; }
    public uint SpecializationId { get; set; }
    public string Name { get; set; }
    public Specialization Specialization { get; set; }

    public Doctor(uint specializationId, string name, Specialization specialization)
    {
        SpecializationId = specializationId;
        Name = name;
        Specialization = specialization;
    }
    
    public Doctor(){ }

    public override string ToString()
    {
        return  $$"""{Doctor record: [ID: {{Id}}, """ +
                $$"""Specialization ID: {{SpecializationId}}, """ +
                $$"""Name: {{Name}}, """ +
                $$"""Specialization: {{Specialization}}]}""";
    }
}