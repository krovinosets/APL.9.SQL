using DatabaseModels;

namespace Core.Repositories.Entities;

public class DoctorEntity : IEntity
{
    public uint? Id { get; set; }
    public uint? SpecializationId { get; set; }
    public string? Name { get; set; }
    public Specialization? Specialization { get; set; }
    
    
}