using DatabaseContext;

namespace Core.Repositories;

public class Repository
{
    public readonly CertificateRepository Certificate;
    public readonly DoctorRepository Doctor;
    public readonly SpecializationRepository Specialization;

    public Repository(Database ctx)
    {
        Certificate = new CertificateRepository(ctx);
        Doctor = new DoctorRepository(ctx);
        Specialization = new SpecializationRepository(ctx);
    }
}