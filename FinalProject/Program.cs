using FinalProject.Models;
namespace FinalProject
{
    public class Program
    {
        private static Customers customers;
        private static List<Appointments> appointments;
        private static List<Customer_Appointment> customerAppointments;
        private static Customer authenticatedCustomer;
        static void Main(string[] args)
        {
            Console.WriteLine("Initializing....");
            Initialize();
            Menu();
        }

        static void Initialize()
        {
            var c1 = new Customer
            {
                FirstName = "Kambiz",
                LastName = "Saffari",
                UserName = "Kambiz",
                Password = "12345",
            };
            var c2 = new Customer
            {
                FirstName = "Terence",
                LastName = "Ow",
                UserName = "Terence",
                Password = "12346",
            };

            customers = new Customers();
            customers.customers.Add(c1);
            customers.customers.Add(c2);

            var a1 = new Appointments();
            var a2 = new Appointments();
            var a3 = new Appointments();

            var ca1 = new Customer_Appointment(c1, a1);
            var ca2 = new Customer_Appointment(c1, a2);
            var ca3 = new Customer_Appointment(c2, a3);

            appointments = new List<Appointments>();
            appointments.Add(ca1);
            appointments.Add(ca2);
            appointments.Add(ca3);
        }
        static void Menu()
        {
            bool done = false;

            while(!done)
            {
                Console.WriteLine("Options: Login 1 ---- Logout: 2---- Sign Up: 3 --- Appointments: 4 --- Clear Screen: c --- quit");
                Console.Write("Choice: ");
                string choice = Console.ReadLine();
                switch(choice)
                {
                    case "1":
                        LoginMenu();
                        break;
                    case "2":
                        LogoutMenu();
                        break;
                    case "3":
                        SignUpMenu();
                        break;
                    case "4":
                        GetCurrentAppointmentsMenu();
                        break;
                    case "C":
                        Console.Clear();
                        break;
                    case "q":
                        done = true;
                        break;
                    default:
                        Console.WriteLine("invalid command!");
                        break;
                }
            }
        }
        static void LoginMenu()
        {
            if(authenticatedCustomer == null)
            {
                Console.Write("Enter your Username: ");
                string userName = Console.ReadLine();
                Console.Write("Enter your Password: ");
                string password = Console.ReadLine();
                authenticatedCustomer = customers.Authenticate(userName, password);
                if (authenticatedCustomer != null)
                {
                    Console.WriteLine($"Welcome {authenticatedCustomer.FirstName}");
                }
                else
                {
                    Console.WriteLine("invalid username or password");
                }
            }
            else
            {
                Console.WriteLine($"You are already logged in as {authenticatedCustomer.UserName}");
            }
        }
        static void LogoutMenu()
        {
            authenticatedCustomer = null;
            Console.WriteLine("Logged out");
        }
        static void SignUpMenu()
        {
            Console.Write("First Name: ");
            string firstName = Console.ReadLine();
            Console.Write("Last Name: ");
            string LastName = Console.ReadLine();
            Console.Write("Username: ");
            string UserName = Console.ReadLine();
            Console.Write("Password: ");
            string PassWord = Console.ReadLine();
            Console.Write("Email: ");
            string email = Console.ReadLine();

            var newCustomer = new Customer
                Customer customer = new Customer
                {
                    FirstName = firstName,
                    LastName = LastName,
                    UserName = UserName,
                    Password = PassWord,
                    Email = email,
      
                };
            customers.customers.Add(newCustomer);
            Console.WriteLine("Profile created:");
        }
        static void GetCurrentAppointmentsMenu()
        {
            if(authenticatedCustomer == null)
            {
                Console.WriteLine("You are not loggin in.");
                return;
            }

            var appointmentList = customerAppointments.Where(o => o.customer.UserName == authenticatedCustomer.UserName);

            if(appointmentList.Count() == 0)
            {
                Console.WriteLine("0 appointment found.");
            }

            Console.WriteLine("Would you like to schedule an appointment today?");
            if (Console.ReadLine() == "yes")
            {
                Console.WriteLine("Options:  1 ---- Logout: 2---- Sign Up: 3 --- Appointments: 4 --- Clear Screen: c --- quit");
            }

            else
            {
                foreach(var appointment in appointmentList)
                {
                    Console.WriteLine(appointment.appointments.date);
                }
            }
        }

    }
}
