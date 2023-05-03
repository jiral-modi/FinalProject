using FinalProject.Models;

namespace ClassProject
{
    public class Program
    {
        private static Customers customers;
        private static List<Customer_Appointment> appointments;
        private static List<Appointments> customerAppointments;
        private static Customer authenticatedCustomer;

        private static Customer customer;
        static void Main(string[] args)
        {
            Console.WriteLine("Initializing...");
            Initialize();
            Menu();
        }

        static void Initialize()
        {
            var c1 = new Customer
            {
                FirstName = "Jake",
                LastName = "Peralta",
                Username = "Jake.Peralta",
                Password = "12345"
            };
            var c2 = new Customer
            {
                FirstName = "Amy",
                LastName = "Santiago",
                Username = "Amy.Santiago",
                Password = "12346"
            };
            var a1 = new Appointments();
            var a2 = new Appointments();
            var a3 = new Appointments();

            var ca1 = new Customer_Appointment(c1, a1);
            var ca2 = new Customer_Appointment(c1, a2);
            var ca3 = new Customer_Appointment(c2, a3);

            customers = new Customers();
            customers.customers.Add(c1);
            customers.customers.Add(c2);

            customerAppointments = new List<Appointments>();
            customerAppointments.Add(a1);
            customerAppointments.Add(a2);
            customerAppointments.Add(a3);

            appointments = new List<Customer_Appointment>();
            appointments.Add(ca1);
            appointments.Add(ca2);
            appointments.Add(ca3);

           


        }

        static void Menu()
        {
            bool done = false;

            while (!done)
            {
                Console.WriteLine("Options: Login: 1 --- Logout: 2 --- Sign Up: 3 --- Appointments: 4 --- Clear Screen: c --- Quit: q ---");
                Console.Write("Choice: ");
                string choice = Console.ReadLine();
                switch (choice)
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
                    case "c":
                        Console.Clear();
                        break;
                    case "q":
                        done = true;
                        break;
                    default:
                        Console.WriteLine("Invalid command!");
                        break;
                }

            }

        }


        static void LoginMenu()
        {
            if (authenticatedCustomer == null)
            {
                Console.Write("Enter your username: ");
                string username = Console.ReadLine();
                Console.Write("Enter your password: ");
                string password = Console.ReadLine();
                authenticatedCustomer = customers.Authenticate(username, password);
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
                Console.WriteLine($"You are already logged in as {authenticatedCustomer.Username}");
            }
        }

        static void LogoutMenu()
        {
            authenticatedCustomer = null;
            Console.WriteLine("Logged out!");
        }

        static void SignUpMenu()
        {
            Console.Write("First Name: ");
            string firstName = Console.ReadLine();
            Console.Write("Last Name: ");
            string LastName = Console.ReadLine();
            Console.Write("Username: ");
            string username = Console.ReadLine();
            Console.Write("Password: ");
            string password = Console.ReadLine();

            var newCustomer = new Customer
            {
                FirstName = firstName,
                LastName = LastName,
                Username = username,
                Password = password
            };

            customers.customers.Add(newCustomer);

            Console.WriteLine("Profile created!");

        }


        static void GetCurrentAppointmentsMenu()
        {
            if (authenticatedCustomer == null)
            {
                Console.WriteLine("You are not logged in.");
                return;
            }

            // Prompt user for date and time of appointment
            Console.Write("Enter the date of your appointment (MM/DD/YYYY): ");
            string dateInput = Console.ReadLine();
            Console.Write("Enter the time of your appointment (HH:MM): ");
            string timeInput = Console.ReadLine();

            // Require user input into a DateTime object
            if (!DateTime.TryParse($"{dateInput} {timeInput}", out DateTime appointmentDateTime))
            {
                Console.WriteLine("Invalid date/time format. Please try again.");
                return;
            }

            // Create a new appointment for the current user with the specified date and time
            var newAppointment = new Appointments
            {
                customers = authenticatedCustomer,
                date = appointmentDateTime
            };

            customerAppointments.Add(newAppointment);

            Console.WriteLine("Appointment added!");
           
        }




    }
}
