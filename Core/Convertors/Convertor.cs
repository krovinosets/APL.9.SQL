
using Core.Repositories.Entities;
using Core.Services.DTO;
using DatabaseModels;

namespace Core.Convertors;

public static class Convertor
{
    public static DoctorDto ToDto(
        uint? doctorId = null,
        uint? doctorSpecializationId = null,
        string? doctorName = null,
        Specialization? doctorSpecialization = null)
    {
        DoctorDto doctorDto = new DoctorDto();
        doctorDto.Id = doctorId;
        doctorDto.SpecializationId = doctorSpecializationId;
        doctorDto.Name = doctorName;
        doctorDto.Specialization = doctorSpecialization;

        return doctorDto;
    }
    
    public static SpecializationDto ToDto(
        uint? specializationId = null,
        string? specializationName = null)
    {
        SpecializationDto specializationDto = new SpecializationDto();
        specializationDto.Id = specializationId;
        specializationDto.Name = specializationName;

        return specializationDto;
    }
    
    public static CertificateDto ToDto(
        uint? certificateId = null,
        uint? certificateDoctorId = null,
        string? certificateDescription = null,
        DateTime? certificateDate = null,
        Doctor? certificateDoctor = null)
    {
        CertificateDto certificateDto = new CertificateDto();
        certificateDto.Id = certificateId;
        certificateDto.DoctorId = certificateDoctorId;
        certificateDto.Description = certificateDescription;
        certificateDto.Date = certificateDate;
        certificateDto.Doctor = certificateDoctor;

        return certificateDto;
    }

    public static DoctorEntity ToEntity(DoctorDto doctorDto)
    {
        DoctorEntity doctorEntity = new DoctorEntity();
        doctorEntity.Id = doctorDto.Id;
        doctorEntity.SpecializationId = doctorDto.SpecializationId;
        doctorEntity.Name = doctorDto.Name;
        doctorEntity.Specialization = doctorDto.Specialization;

        return doctorEntity;
    }
    
    public static SpecializationEntity ToEntity(SpecializationDto specializationDto)
    {
        SpecializationEntity specializationEntity = new SpecializationEntity();
        specializationEntity.Id = specializationDto.Id;
        specializationEntity.Name = specializationDto.Name;

        return specializationEntity;
    }
    
    public static CertificateEntity ToEntity(CertificateDto certificateDto)
    {
        CertificateEntity certificateEntity = new CertificateEntity();
        certificateEntity.Id =  certificateDto.Id;
        certificateEntity.DoctorId = certificateDto.DoctorId;
        certificateEntity.Description = certificateDto.Description;
        certificateEntity.Date = certificateDto.Date;
        certificateEntity.Doctor = certificateDto.Doctor;

        return certificateEntity;
    }

    public static DoctorDto FromEntity(Doctor doctor)
    {
        DoctorDto doctorDto = new DoctorDto();
        doctorDto.Id = doctor.Id;
        doctorDto.SpecializationId = doctor.SpecializationId;
        doctorDto.Name = doctor.Name;
        doctorDto.Specialization = doctor.Specialization;

        return doctorDto;
    }
    
    public static SpecializationDto FromEntity(Specialization specialization)
    {
        SpecializationDto specializationDto = new SpecializationDto();
        specializationDto.Id = specialization.Id;
        specializationDto.Name = specialization.Name;

        return specializationDto;
    }
    
    public static CertificateDto FromEntity(Certificate certificate)
    {
        CertificateDto certificateDto = new CertificateDto();
        certificateDto.Id =  certificate.Id;
        certificateDto.DoctorId = certificate.DoctorId;
        certificateDto.Description = certificate.Description;
        certificateDto.Date = certificate.Date;
        certificateDto.Doctor = certificate.Doctor;

        return certificateDto;
    }
}