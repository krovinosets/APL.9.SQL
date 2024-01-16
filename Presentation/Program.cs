using Core;
using Core.Handlers;
using DatabaseContext;
using Microsoft.EntityFrameworkCore;

namespace Presentation
{
    static class Program
    {
        static void Main()
        {
            // Repository - make IRepository with .Get(RepositoryModel) and etc.
            // Repository <- Model Doctor (toRepository Model) contains (Doctor, Certificate, Specialization)
            // Service <- toService Model contains (id, string, description...)
            // Facade <- input from keyboard which formatting toService Model
            try
            {
                var exit = false;
                while (!exit)
                {
                    Console.WriteLine("To work with Doctors enter: 1");
                    Console.WriteLine("To work with Specializations enter: 2");
                    Console.WriteLine("To work with Certificates enter: 3");
                    Console.WriteLine("To Analyze Data enter: 4");
                    Console.WriteLine("To exit program enter: 5");
                    Console.WriteLine("Choose action: ");
    
                    var action = Console.ReadLine();
                    var menu = new Menu();
                    var facade = new Facade();
    
                    switch (action)
                    {
                        case ("1"):
                            menu.DoctorMenu(facade);
                            break;
                        case ("2"):
                            menu.SpecializationMenu(facade);
                            break;
                        case ("3"):
                            menu.CertificateMenu(facade);
                            break;
                        case ("4"):
                            menu.AnalyzeMenu(facade);
                            break;
                        case ("5"):
                            Console.WriteLine("End of program");
                            exit = true;
                            break;
                        default:
                            throw new ArgumentException("Error. Please enter correct value.");
                    }
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
}