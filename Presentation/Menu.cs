using Core;
using Core.Handlers;

namespace Presentation;

public class Menu
{
    public void DoctorMenu(Facade facade)
    {
        try
        {
            Console.WriteLine("To add Doctor enter: 1");
            Console.WriteLine("To update Doctor enter: 2");
            Console.WriteLine("To delete Doctor enter: 3");
            Console.WriteLine("To get Doctor enter: 4");
            Console.WriteLine("To get all Doctor enter: 5");
            Console.WriteLine("To exit program enter: 6");
            var action = Console.ReadLine();
        
            switch (action)
            {
                case ("1"):
                    facade.AddDoctor();
                    break;
                case ("2"):
                    facade.UpdateDoctor();
                    break;
                case ("3"):
                    facade.RemoveDoctor();
                    break;
                case ("4"):
                    facade.GetDoctor();
                    break;
                case ("5"):
                    facade.GetAllDoctor();
                    break;
                case ("6"):
                    break;
                default:
                    throw new ArgumentException("Error. Please enter correct value.");
            }
        }
        catch (InvalidOperationException e)
        {
            Console.WriteLine(e.Message);
        }
        catch (ArgumentException e)
        {
            Console.WriteLine(e.Message);
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
    }

    public void SpecializationMenu(Facade facade)
    {
        try
        {
            Console.WriteLine("To add Specialization enter: 1");
            Console.WriteLine("To update Specialization enter: 2");
            Console.WriteLine("To delete Specialization enter: 3");
            Console.WriteLine("To get Specialization enter: 4");
            Console.WriteLine("To get all Specialization enter: 5");
            Console.WriteLine("To exit program enter: 6");
            var action = Console.ReadLine();
        
            switch (action)
            {
                case ("1"):
                    facade.AddSpecialization();
                    break;
                case ("2"):
                    facade.UpdateSpecialization();
                    break;
                case ("3"):
                    facade.RemoveSpecialization();
                    break;
                case ("4"):
                    facade.GetSpecialization();
                    break;
                case ("5"):
                    facade.GetAllSpecializations();
                    break;
                case ("6"):
                    break;
                default:
                    throw new ArgumentException("Error. Please enter correct value.");
            }
        }
        catch (InvalidOperationException e)
        {
            Console.WriteLine(e.Message);
        }
        catch (ArgumentException e)
        {
            Console.WriteLine(e.Message);
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
    }

    public void CertificateMenu(Facade facade)
    {
        try
        {
            Console.WriteLine("To add Certificate enter: 1");
            Console.WriteLine("To update Certificate enter: 2");
            Console.WriteLine("To delete Certificate enter: 3");
            Console.WriteLine("To get Certificate enter: 4");
            Console.WriteLine("To get all Certificate enter: 5");
            Console.WriteLine("To exit program enter: 6");
            var action = Console.ReadLine();
        
            switch (action)
            {
                case ("1"):
                    facade.AddCertificate();
                    break;
                case ("2"):
                    facade.UpdateCertificate();
                    break;
                case ("3"):
                    facade.RemoveCertificate();
                    break;
                case ("4"):
                    facade.GetCertificate();
                    break;
                case ("5"):
                    facade.GetAllCertificates();
                    break;
                case ("6"):
                    break;
                default:
                    throw new ArgumentException("Error. Please enter correct value.");
            }
        }
        catch (InvalidOperationException e)
        {
            Console.WriteLine(e.Message);
        }
        catch (ArgumentException e)
        {
            Console.WriteLine(e.Message);
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
    }

    public void AnalyzeMenu(Facade facade)
    {
        try
        {
            Console.WriteLine("To calculate number of doctors with special specialization enter: 1");
            Console.WriteLine("To get specialization name by certificate id: 2");
            Console.WriteLine("To get date of last given certificate by doctor id: 3");
            Console.WriteLine("To exit program enter: 4");

            var action = Console.ReadLine();
            switch (action)
            {
                case ("1"):
                    facade.GetAllDoctorsWithSpecialization();
                    break;
                case ("2"):
                    facade.GetSpecializationNameByCertificate();
                    break;
                case ("3"):
                    facade.GetLastCertificateToDoctor();
                    break;
                case ("4"):
                    break;
                default:
                    throw new ArgumentException("Error. Please enter correct value.");
            }
        }
        catch (InvalidOperationException e)
        {
            Console.WriteLine(e.Message);
        }
        catch (ArgumentException e)
        {
            Console.WriteLine(e.Message);
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
    }
}