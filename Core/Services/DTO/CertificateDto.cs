using Core.Repositories.DTO;
using DatabaseModels;

namespace Core.Services.DTO;

public class CertificateDto : IDto
{
    public uint? Id { get; set; }
    public uint? DoctorId { get; set; }
    public string? Description { get; set; }
    public DateTime? Date { get; set; }
    public Doctor? Doctor { get; set; }
    
    public override string ToString()
    {
        return $$"""{Certificate record: [ID: {{Id}}, """ +
               $$"""Doctor ID: {{DoctorId}}, """ +
               $$"""Description: {{Description}}, """ +
               $$"""Date: {{Date}}, """ +
               $$"""Doctor: {{Doctor}}]}""";
    }
}