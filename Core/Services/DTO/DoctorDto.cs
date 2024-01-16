using Core.Repositories.DTO;
using DatabaseModels;

namespace Core.Services.DTO;

public class DoctorDto : IDto
{
    public uint? Id { get; set; }
    public uint? SpecializationId { get; set; }
    public string? Name { get; set; }
    public Specialization? Specialization { get; set; }
    
    public override string ToString()
    {
        return  $$"""{Doctor record: [ID: {{Id}}, """ +
                $$"""Specialization ID: {{SpecializationId}}, """ +
                $$"""Name: {{Name}}, """ +
                $$"""Specialization: {{Specialization}}]}""";
    }
}