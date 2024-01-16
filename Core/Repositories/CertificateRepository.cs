using Core.Convertors;
using Core.Repositories.Entities;
using Core.Services.DTO;
using DatabaseContext;
using DatabaseModels;
using Microsoft.EntityFrameworkCore;

namespace Core.Repositories;

public class CertificateRepository
{
    private readonly Database _ctx;
    
    public CertificateRepository(Database ctx)
    {
        _ctx = ctx;
    }

    public CertificateDto Remove(CertificateEntity entity)
    {
        Certificate certificate = GetRecord(entity);

        _ctx.Certificates.Remove(certificate);
        _ctx.SaveChanges();
        
        return Convertor.FromEntity(certificate);
    }
    
    public CertificateDto Update(CertificateEntity entity)
    {
        if (entity.DoctorId == null || entity.Description == null || entity.Date == null)
            throw new Exception("Unexpected Nullable");
        
        Certificate certificate = GetRecord(entity);
        certificate.DoctorId = (uint)entity.DoctorId;
        certificate.Description = entity.Description;
        certificate.Date = (DateTime)entity.Date;
        _ctx.SaveChanges();
        
        return Convertor.FromEntity(certificate);
    }
    
    public CertificateDto Add(CertificateEntity entity)
    {
        if (entity.DoctorId == null || entity.Description == null || entity.Date == null || entity.Doctor == null)
            throw new Exception("Unexpected Nullable");
        
        Certificate certificate = new Certificate((uint)entity.DoctorId, entity.Description, (DateTime)entity.Date, entity.Doctor);
        _ctx.Certificates.Add(certificate);
        _ctx.SaveChanges();
        
        return Convertor.FromEntity(certificate);
    }
    
    public Certificate GetRecord(CertificateEntity entity)
    {
        if (entity.Id == null)
            throw new Exception("Unexpected Nullable");
        
        List<Certificate> cert = _ctx.Certificates.Where(cert => cert.Id == entity.Id).Include(cert => cert.Doctor).ToList();
        if (cert.Count == 0)
        {
            throw new Exception($"Record Specialization with PK_id:{entity.Id} not found");
        }
        
        return cert.First();
    }

    public CertificateDto Get(CertificateEntity entity)
    {
        return Convertor.FromEntity(GetRecord(entity));
    }
    
    public List<CertificateDto> GetAll()
    {
        var lst = _ctx.Certificates.Include(cert => cert.Doctor).ToList();
        List<CertificateDto> certificateDtos = new List<CertificateDto>();
        foreach (var elem in lst)
        {
            certificateDtos.Add(Convertor.FromEntity(elem));
        }

        return certificateDtos;
    }
}