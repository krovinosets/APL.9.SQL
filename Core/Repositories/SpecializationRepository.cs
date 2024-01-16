using Core.Convertors;
using Core.Repositories.Entities;
using Core.Services.DTO;
using DatabaseContext;
using DatabaseModels;

namespace Core.Repositories;

public class SpecializationRepository
{
    private readonly Database _ctx;
    
    public SpecializationRepository(Database ctx)
    {
        _ctx = ctx;
    }

    public SpecializationDto Remove(SpecializationEntity entity)
    {
        Specialization specialization = GetRecord(entity);

        _ctx.Specializations.Remove(specialization);
        _ctx.SaveChanges();
        
        return Convertor.FromEntity(specialization);
    }
    
    public SpecializationDto Update(SpecializationEntity entity)
    {
        if (entity.Name == null)
            throw new Exception("Unexpected Nullable");
        
        Specialization specialization = GetRecord(entity);
        specialization.Name = entity.Name;
        _ctx.SaveChanges();
        
        return Convertor.FromEntity(specialization);
    }
    
    public SpecializationDto Add(SpecializationEntity entity)
    {
        if (entity.Name == null)
            throw new Exception("Unexpected Nullable");
        
        Specialization specialization = new Specialization(entity.Name);
        _ctx.Specializations.Add(specialization);
        _ctx.SaveChanges();
        
        return Convertor.FromEntity(specialization);
    }
    
    public Specialization GetRecord(SpecializationEntity entity)
    {
        if (entity.Id == null)
            throw new Exception("Unexpected Nullable");
        
        List<Specialization> spec = _ctx.Specializations.Where(s => s.Id == entity.Id).ToList();
        if (spec.Count == 0)
        {
            throw new Exception($"Record Specialization with PK_id:{entity.Id} not found");
        }
        
        return spec.First();
    }
    
    public SpecializationDto Get(SpecializationEntity entity)
    {
        return Convertor.FromEntity(GetRecord(entity));
    }
    
    public List<SpecializationDto> GetAll()
    {
        var lst = _ctx.Specializations.ToList();
        List<SpecializationDto> specializationDtos = new List<SpecializationDto>();
        foreach (var elem in lst)
        {
            specializationDtos.Add(Convertor.FromEntity(elem));
        }

        return specializationDtos;
    }
}