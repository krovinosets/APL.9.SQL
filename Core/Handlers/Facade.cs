using Core.Convertors;
using Core.Services;
using Core.Services.DTO;
using DatabaseContext;
using DatabaseModels;

namespace Core.Handlers;

public class Facade
{
    private readonly Database _database;
    private readonly Repositories.Repository _repository;
    private readonly Service _service;
    
    public Facade()
    {
        _database = new Database();
        _repository = new Repositories.Repository(_database);
        _service = new Service(_repository);
    }
    
    public void GetDoctor()
    {
        Console.WriteLine("Enter Doctor ID: ");
        if (!uint.TryParse(Console.ReadLine(), out var doctorId))
            throw new ArgumentException("Error. Please enter correct Doctor ID");
        
        _service.InteractData.GetDoctor(Convertor.ToDto(doctorId: doctorId));
    }
    
    public void GetAllDoctor()
    {
        _service.InteractData.GetAllDoctors();
    }

    public void UpdateDoctor()
    {
        Console.WriteLine("Enter Doctor ID: ");
        if (!uint.TryParse(Console.ReadLine(), out var doctorId))
            throw new ArgumentException("Error. Please enter correct Doctor ID");
        
        Console.WriteLine("Enter new Specialization ID: ");
        if (!uint.TryParse(Console.ReadLine(), out var specId))
            throw new ArgumentException("Error. Please enter correct Specialization ID");
        
        Console.WriteLine("Enter new Doctor Name: ");
        var doctorName = Console.ReadLine();
        if (doctorName == null)
            throw new ArgumentException("Error. Doctor Name cannot be null.");
        
        _service.InteractData.UpdateDoctor(Convertor.ToDto(doctorId: doctorId, doctorSpecializationId: specId, doctorName: doctorName));
    }
    
    public void AddDoctor()
    {
        Console.WriteLine("Enter Specialization ID: ");
        if (!uint.TryParse(Console.ReadLine(), out var specId))
            throw new ArgumentException("Error. Please enter correct Specialization ID");
        
        Console.WriteLine("Enter Doctor Name: ");
        var doctorName = Console.ReadLine();
        if (doctorName == null)
            throw new ArgumentException("Error. Doctor Name cannot be null.");
        
        DoctorDto? doctor = _service.InteractData.AddDoctor(Convertor.ToDto(doctorSpecializationId: specId, doctorName: doctorName));
        if(doctor == null)
            return;
        
        bool noDependency = true;
        foreach (var cert in _service.InteractData.GetAllCertificates())
        {
            if (cert.DoctorId == doctor.Id)
            {
                noDependency = false;
                break;
            }
        }

        
        if (noDependency && doctor.Id != null)
        {
            Console.WriteLine($"Doctor {doctor} does not have any certificates, add at least one");
            AddCertificate((uint)doctor.Id);
        }
    }

    public void RemoveDoctor()
    {
        Console.WriteLine("Enter Doctor ID: ");
        if (!uint.TryParse(Console.ReadLine(), out var doctorId))
            throw new ArgumentException("Error. Please enter correct Doctor ID");
        
        _service.InteractData.RemoveDoctor(Convertor.ToDto(doctorId: doctorId));
    }
    
    // Delimiter
    
    public void GetSpecialization()
    {
        Console.WriteLine("Enter Specialization ID: ");
        if (!uint.TryParse(Console.ReadLine(), out var specId))
            throw new ArgumentException("Error. Please enter correct Specialization ID");
        
        _service.InteractData.GetSpecialization(Convertor.ToDto(specializationId: specId));
    }
    
    public void GetAllSpecializations()
    {
        _service.InteractData.GetAllSpecializations();
    }
    
    public void AddSpecialization()
    {
        Console.WriteLine("Enter Specialization Name: ");
        var specName = Console.ReadLine();
        if (specName == null)
            throw new ArgumentException("Error. Specialization Name cannot be null.");
        
        _service.InteractData.AddSpecialization(Convertor.ToDto(specializationName: specName));
    }
    
    public void UpdateSpecialization()
    {
        Console.WriteLine("Enter Specialization ID: ");
        if (!uint.TryParse(Console.ReadLine(), out var specId))
            throw new ArgumentException("Error. Please enter correct Specialization ID");
        
        Console.WriteLine("Enter new Specialization Name: ");
        var specName = Console.ReadLine();
        if (specName == null)
            throw new ArgumentException("Error. Specialization Name cannot be null.");
        
        _service.InteractData.UpdateSpecialization(Convertor.ToDto(specializationId: specId,specializationName: specName));
    }
    
    public void RemoveSpecialization()
    {
        Console.WriteLine("Enter Specialization ID: ");
        if (!uint.TryParse(Console.ReadLine(), out var specId))
            throw new ArgumentException("Error. Please enter correct Specialization ID");
        
        _service.InteractData.RemoveSpecialization(Convertor.ToDto(specializationId: specId));
    }
    
    // Delimiter
    
    public void GetCertificate()
    {
        Console.WriteLine("Enter Certificate ID: ");
        if (!uint.TryParse(Console.ReadLine(), out var certId))
            throw new ArgumentException("Error. Please enter correct Certificate ID");
        
        _service.InteractData.GetCertificate(Convertor.ToDto(certificateId: certId));
    }
    
    public void GetAllCertificates()
    {
        _service.InteractData.GetAllCertificates();
    }
    
    public void AddCertificate(uint doctorId = 0)
    {
        if (doctorId == 0)
        {
            Console.WriteLine("Enter Doctor ID: ");
            if (!uint.TryParse(Console.ReadLine(), out doctorId))
                throw new ArgumentException("Error. Please enter correct Doctor ID");
        }

        Console.WriteLine("Enter Certificate Description: ");
        var certDesc = Console.ReadLine();
        if (certDesc == null)
            throw new ArgumentException("Error. Certificate Description cannot be null.");
        
        Console.WriteLine("Enter creation year: ");
        if (!Int32.TryParse(Console.ReadLine(), out var year) || 0 > year)
            throw new ArgumentException("Error. Please enter correct year.");
        
        Console.WriteLine("Enter creation month: ");
        if (!Int32.TryParse(Console.ReadLine(), out var month) || 0 > month || month > 12)
            throw new ArgumentException("Error. Please enter correct month.");
        
        Console.WriteLine("Enter creation day: ");
        if (!Int32.TryParse(Console.ReadLine(), out var day) || 0 > day || day > 31)
            throw new ArgumentException("Error. Please enter correct day.");
        
        var creationDate = new DateTime(year, month, day);
        
        _service.InteractData.AddCertificate(Convertor.ToDto(certificateDescription: certDesc, certificateDoctorId: doctorId, certificateDate: creationDate));
    }
    
    public void UpdateCertificate()
    {
        Console.WriteLine("Enter Certificate ID: ");
        if (!uint.TryParse(Console.ReadLine(), out var specId))
            throw new ArgumentException("Error. Please enter correct Certificate ID");
        
        Console.WriteLine("Enter Doctor ID: ");
        if (!uint.TryParse(Console.ReadLine(), out var doctorId))
            throw new ArgumentException("Error. Please enter correct Doctor ID");

        Console.WriteLine("Enter new Certificate Description: ");
        var certDesc = Console.ReadLine();
        if (certDesc == null)
            throw new ArgumentException("Error. Certificate Description cannot be null.");
            
        Console.WriteLine("Enter new creation year: ");
        if (!Int32.TryParse(Console.ReadLine(), out var year) || 0 > year)
            throw new ArgumentException("Error. Please enter correct year.");
            
        Console.WriteLine("Enter new creation month: ");
        if (!Int32.TryParse(Console.ReadLine(), out var month) || 0 > month || month > 12)
            throw new ArgumentException("Error. Please enter correct month.");
            
        Console.WriteLine("Enter new creation day: ");
        if (!Int32.TryParse(Console.ReadLine(), out var day) || 0 > day || day > 31)
            throw new ArgumentException("Error. Please enter correct day.");
            
        var creationDate = new DateTime(year, month, day);
        _service.InteractData.UpdateCertificate(Convertor.ToDto(certificateId: specId, certificateDescription: certDesc, certificateDoctorId: doctorId, certificateDate: creationDate));
    }
    
    public void RemoveCertificate()
    {
        Console.WriteLine("Enter Certificate ID: ");
        if (!uint.TryParse(Console.ReadLine(), out var certId))
            throw new ArgumentException("Error. Please enter correct Certificate ID");
        
        _service.InteractData.RemoveCertificate(Convertor.ToDto(certificateId: certId));
    }
    
    // Delimiter

    public void GetAllDoctorsWithSpecialization()
    {
        Console.WriteLine("Enter Specialization ID: ");
        if (!uint.TryParse(Console.ReadLine(), out var specId))
            throw new ArgumentException("Error. Please enter correct Specialization ID");
        
        _service.AnalyzeData.GetAllDoctorsWithSpecialization(Convertor.ToDto(specializationId: specId));
    }
    
    public void GetSpecializationNameByCertificate()
    {
        Console.WriteLine("Enter Certificate ID: ");
        if (!uint.TryParse(Console.ReadLine(), out var certId))
            throw new ArgumentException("Error. Please enter correct Certificate ID");
        
        _service.AnalyzeData.GetSpecializationNameByCertificate(Convertor.ToDto(certificateId: certId));
    }
    
    public void GetLastCertificateToDoctor()
    {
        Console.WriteLine("Enter Doctor ID: ");
        if (!uint.TryParse(Console.ReadLine(), out var doctorId))
            throw new ArgumentException("Error. Please enter correct Doctor ID");
        
        _service.AnalyzeData.GetLastCertificateToDoctor(Convertor.ToDto(doctorId: doctorId));
    }
}