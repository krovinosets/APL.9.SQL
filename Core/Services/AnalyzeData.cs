using Core.Convertors;
using Core.Repositories.Entities;
using Core.Services.DTO;
using DatabaseModels;

namespace Core.Services;

public class AnalyzeData
{
    private readonly Repositories.Repository _repository;

    public AnalyzeData(Repositories.Repository repository)
    {
        _repository = repository;
    }

    public void GetAllDoctorsWithSpecialization(SpecializationDto specializationDto)
    {
        try
        {
            int count = 0;
            SpecializationDto specialization = _repository.Specialization.Get(Convertor.ToEntity(specializationDto));
            foreach (var doctor in _repository.Doctor.GetAll())
            {
                if(doctor.SpecializationId == specializationDto.Id)
                {
                    Console.WriteLine($"Doctor {doctor} has current Specialization");
                    count++;
                }
            }
            Console.WriteLine($"{count} doctors has current Specialization {specialization}");
        }
        catch (Exception e)
        {
            Console.WriteLine($"Specialization not found: {e.Message}");
        }
    }

    public void GetSpecializationNameByCertificate(CertificateDto certificateDto)
    {
        try
        {
            CertificateDto certificate = _repository.Certificate.Get(Convertor.ToEntity(certificateDto));

            DoctorDto doctorDto = new DoctorDto();
            doctorDto.Id = certificate.DoctorId;
            
            DoctorDto doctor = _repository.Doctor.Get(Convertor.ToEntity(doctorDto));
            Specialization specialization = doctor.Specialization!;

            Console.WriteLine($"Certificate {certificate} has been given by Specialization {specialization}");
        }
        catch (Exception e)
        {
            Console.WriteLine($"Certificate Record not found: {e.Message}");
        }
    }

    public void GetLastCertificateToDoctor(DoctorDto doctorDto)
    {
        try
        {
            DoctorDto doctor = _repository.Doctor.Get(Convertor.ToEntity(doctorDto));
            CertificateDto lastCertificate = null!;
            
            foreach (var cert in _repository.Certificate.GetAll())
            {
                if (cert.DoctorId == doctor.Id)
                {
                    lastCertificate = cert;
                }
            }
            Console.WriteLine($"Last given Certificate to Doctor is {lastCertificate}");
        }
        catch (Exception e)
        {
            Console.WriteLine($"Doctor Record not found: {e.Message}");
        }
    }
}