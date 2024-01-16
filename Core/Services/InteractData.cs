using Core.Convertors;
using Core.Services.DTO;
using DatabaseModels;

namespace Core.Services;

public class InteractData
{
    private readonly Repositories.Repository _repository;

    public InteractData(Repositories.Repository repository)
    {
        _repository = repository;
    }

    /*
     * <begin title="Methods of interacting with Table 'Doctors'">
     */
    public void GetDoctor(DoctorDto doctorDto)
    {
        try
        {
            DoctorDto doctor = _repository.Doctor.Get(Convertor.ToEntity(doctorDto));
            Console.WriteLine($"{doctor}");
        }
        catch (Exception e)
        {
            Console.WriteLine($"Doctor not found: {e.Message}");
        }
    }

    public void GetAllDoctors()
    {
        List<DoctorDto> doctors = _repository.Doctor.GetAll();
        foreach (DoctorDto doctor in doctors)
        {
            Console.WriteLine($"{doctor}");
        }

        if (doctors.Count == 0)
        {
            Console.WriteLine("Table 'Doctors' do not have any records");
        }
    }

    public DoctorDto? AddDoctor(DoctorDto doctorDto)
    {
        DoctorDto doctor = null!;
        try
        {
            SpecializationDto specializationDto = new SpecializationDto();
            specializationDto.Id = doctorDto.SpecializationId;
            
            Specialization specialization = _repository.Specialization.GetRecord(Convertor.ToEntity(specializationDto));
            doctorDto.Specialization = specialization;
            
            doctor = _repository.Doctor.Add(Convertor.ToEntity(doctorDto));
            Console.WriteLine($"{doctor} was added");
        }
        catch (Exception e)
        {
            Console.WriteLine($"Specialization Record not found, create before using it: {e.Message}");
            return null;
        }

        return doctor;
    }

    public void UpdateDoctor(DoctorDto doctorDto)
    {
        try
        {
            SpecializationDto specializationDto = new SpecializationDto();
            specializationDto.Id = doctorDto.SpecializationId;
            _repository.Specialization.Get(Convertor.ToEntity(specializationDto));
            
            DoctorDto doctor = _repository.Doctor.Update(Convertor.ToEntity(doctorDto));
            Console.WriteLine($"{doctor} was updated");
        }
        catch (Exception e)
        {
            Console.WriteLine($"Specialization or Doctor Record not found, create before using it: {e.Message}");
        }
    }

    public void RemoveDoctor(DoctorDto doctorDto)
    {
        try
        {
            DoctorDto doctor = _repository.Doctor.Remove(Convertor.ToEntity(doctorDto));
            foreach (var cert in _repository.Certificate.GetAll())
            {
                if (cert.DoctorId == doctor.Id)
                    _repository.Certificate.Remove(Convertor.ToEntity(cert));
            }
            Console.WriteLine($"{doctor} was removed");
        }
        catch (Exception e)
        {
            Console.WriteLine($"Doctor Record not found, create before using it: {e.Message}");
        }
    }
    /*
     * </end title="Methods of interacting with Table 'Doctors'">
     */
    
    /*
     * <begin title="Methods of interacting with Table 'Specializations'">
     */
    public void GetSpecialization(SpecializationDto specializationDto)
    {
        try
        {
            SpecializationDto specialization = _repository.Specialization.Get(Convertor.ToEntity(specializationDto));
            Console.WriteLine($"{specialization}");
        }
        catch (Exception e)
        {
            Console.WriteLine($"Specialization not found: {e.Message}");
        }
    }

    public void GetAllSpecializations()
    {
        List<SpecializationDto> specializations = _repository.Specialization.GetAll();
        foreach (SpecializationDto specialization in specializations)
        {
            Console.WriteLine($"{specialization}");
        }

        if (specializations.Count == 0)
        {
            Console.WriteLine("Table 'Specializations' do not have any records");
        }
    }

    public void AddSpecialization(SpecializationDto specializationDto)
    {
        SpecializationDto specialization = _repository.Specialization.Add(Convertor.ToEntity(specializationDto));
        Console.WriteLine($"{specialization} was added");
    }

    public void UpdateSpecialization(SpecializationDto specializationDto)
    {
        try
        {
            SpecializationDto specialization = _repository.Specialization.Update(Convertor.ToEntity(specializationDto));
            Console.WriteLine($"{specialization} was updated");
        }
        catch (Exception e)
        {
            Console.WriteLine($"Specialization Record not found, create before using it: {e.Message}");
        }
    }

    public void RemoveSpecialization(SpecializationDto specializationDto)
    {
        try
        {
            SpecializationDto specialization = _repository.Specialization.Remove(Convertor.ToEntity(specializationDto));
            foreach (var doctor in _repository.Doctor.GetAll())
            {
                if (doctor.SpecializationId == specialization.Id)
                    RemoveDoctor(doctor);
            }
            Console.WriteLine($"{specialization} was removed");
        }
        catch (Exception e)
        {
            Console.WriteLine($"Specialization Record not found, create before using it: {e.Message}");
        }
    }
    /*
     * </end title="Methods of interacting with Table 'Specializations'">
     */
    
    /*
     * <begin title="Methods of interacting with Table 'Certificates'">
     */
    public void GetCertificate(CertificateDto certificateDto)
    {
        try
        {
            CertificateDto certificate = _repository.Certificate.Get(Convertor.ToEntity(certificateDto));
            Console.WriteLine($"{certificate}");
        }
        catch (Exception e)
        {
            Console.WriteLine($"Certificate not found: {e.Message}");
        }
    }

    public List<CertificateDto> GetAllCertificates()
    {
        List<CertificateDto> certificates = _repository.Certificate.GetAll();
        foreach (CertificateDto certificate in certificates)
        {
            Console.WriteLine($"{certificate}");
        }

        if (certificates.Count == 0)
        {
            Console.WriteLine("Table 'Certificates' do not have any records");
        }
        return certificates;
    }

    public void AddCertificate(CertificateDto certificateDto)
    {
        try
        {
            DoctorDto doctorDto = new DoctorDto();
            doctorDto.Id = certificateDto.DoctorId;
            
            Doctor doctor = _repository.Doctor.GetRecord(Convertor.ToEntity(doctorDto));
            certificateDto.Doctor = doctor;
            
            CertificateDto certificate = _repository.Certificate.Add(Convertor.ToEntity(certificateDto));
            Console.WriteLine($"{certificate} was added");
        }
        catch (Exception e)
        {
            Console.WriteLine($"Doctor Record not found, create before using it: {e.Message}");
        }
    }

    public void UpdateCertificate(CertificateDto certificateDto)
    {
        try
        {
            DoctorDto doctorDto = new DoctorDto();
            doctorDto.Id = certificateDto.DoctorId;
            
            _repository.Doctor.Get(Convertor.ToEntity(doctorDto));
            CertificateDto certificate = _repository.Certificate.Update(Convertor.ToEntity(certificateDto));
            Console.WriteLine($"{certificate} was updated");
        }
        catch (Exception e)
        {
            Console.WriteLine($"Doctor Record not found, create before using it: {e.Message}");
        }
    }

    public void RemoveCertificate(CertificateDto certificateDto)
    {
        try
        {
            bool dependency = false;
            CertificateDto certificate = _repository.Certificate.Remove(Convertor.ToEntity(certificateDto));
            foreach (var cert in _repository.Certificate.GetAll())
            {
                if (cert.DoctorId == certificate.Id)
                {
                    dependency = true;
                    break;
                }
            }

            DoctorDto doctorDto = new DoctorDto();
            doctorDto.Id = certificateDto.DoctorId;
            if (!dependency)
            {
                RemoveDoctor(doctorDto);
            }
            Console.WriteLine($"{certificate} was removed");
        }
        catch (Exception e)
        {
            Console.WriteLine($"Certificate Record not found, create before using it: {e.Message}");
        }
    }
    /*
     * </end title="Methods of interacting with Table 'Certificates'">
     */
}