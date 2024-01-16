using Core.Repositories.DTO;

namespace Core.Services.DTO;

public class SpecializationDto : IDto
{
    public uint? Id { get; set; }
    public string? Name { get; set; }
    
    public override string ToString()
    {
        return  $$"""{Specialization record: [ID: {{Id}}, """ +
                $$"""Name: {{Name}}]}""";
    }
}