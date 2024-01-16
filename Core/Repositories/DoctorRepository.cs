using Core.Convertors;
using Core.Repositories.Entities;
using Core.Services.DTO;
using DatabaseContext;
using DatabaseModels;
using Microsoft.EntityFrameworkCore;

namespace Core.Repositories;

public class DoctorRepository
{
    private readonly Database _ctx;
    
    public DoctorRepository(Database ctx)
    {
        _ctx = ctx;
    }

    public DoctorDto Remove(DoctorEntity entity)
    {
        Doctor doctor = GetRecord(entity);

        _ctx.Doctors.Remove(doctor);
        _ctx.SaveChanges();
        
        return Convertor.FromEntity(doctor);
    }
    
    public DoctorDto Update(DoctorEntity entity)
    {
        if (entity.Name == null || entity.SpecializationId == null)
            throw new Exception("Unexpected Nullable");
        
        Doctor doctor = GetRecord(entity);
        doctor.Name = entity.Name;
        doctor.SpecializationId = (uint)entity.SpecializationId;
        _ctx.SaveChanges();

        return Convertor.FromEntity(doctor);
    }
    
    public DoctorDto Add(DoctorEntity entity)
    {
        if (entity.Name == null || entity.SpecializationId == null || entity.Specialization == null)
            throw new Exception("Unexpected Nullable");
        
        Doctor doctor = new Doctor((uint)entity.SpecializationId, entity.Name, entity.Specialization);
        _ctx.Doctors.Add(doctor);
        _ctx.SaveChanges();
        
        return Convertor.FromEntity(doctor);
    }
    
    public Doctor GetRecord(DoctorEntity entity)
    {
        if (entity.Id == null)
            throw new Exception("Unexpected Nullable");
        
        List<Doctor> doctor = _ctx.Doctors.Where(doctor => doctor.Id == entity.Id).Include(doctor => doctor.Specialization).ToList();
        if (doctor.Count == 0)
            throw new Exception($"Record Specialization with PK_id:{entity.Id} not found");
        
        return doctor.First();
    }
    
    public DoctorDto Get(DoctorEntity entity)
    {
        return Convertor.FromEntity(GetRecord(entity));
    }
    
    public List<DoctorDto> GetAll()
    {
        var lst = _ctx.Doctors.Include(doctor => doctor.Specialization).ToList();
        List<DoctorDto> doctorDtos = new List<DoctorDto>();
        foreach (var elem in lst)
        {
            doctorDtos.Add(Convertor.FromEntity(elem));
        }

        return doctorDtos;
    }
}