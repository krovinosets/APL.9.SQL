using DatabaseModels;

namespace Core.Repositories.Entities;

public class CertificateEntity : IEntity
{
    public uint? Id { get; set; }
    public uint? DoctorId { get; set; }
    public string? Description { get; set; }
    public DateTime? Date { get; set; }
    public Doctor? Doctor { get; set; }
}