using FinalProject.Models;

namespace ClassProject
{
    public class Program//this is open access to anyone with the program
    {
        private static Customers customers;//pulling our information the customer class
        private static List<Customer_Appointment> appointments;//generating a list of customers with appointments
        private static List<Appointments> customerAppointments;//pulling information into the appointment class
        private static Customer authenticatedCustomer;//making sure this individual is an actual customer

        private static Customer customer;//
        static void Main(string[] args)//the normal constructor we use
        {
            Console.WriteLine("Welcome to Smile Brite Dental Services, we are happy to serve you!");//welcoming the customer
            Console.WriteLine("Initializing...");// initializing message
            Initialize(); //calling initializing method
            Menu(); // calling menu method
        }

        static void Initialize()
        {
            var c1 = new Customer //adds new customer
            {
                FirstName = "Jake",
                LastName = "Peralta",
                Username = "Jake.Peralta",
                Password = "12345"
            };
            var c2 = new Customer //adds new customer
            {
                FirstName = "Amy",
                LastName = "Santiago",
                Username = "Amy.Santiago",
                Password = "12346"
            };
            var a1 = new Appointments(); //makes new appointments
            var a2 = new Appointments(); //makes new appointments
            var a3 = new Appointments(); //makes new appointments

            var ca1 = new Customer_Appointment(c1, a1); //associates customer to specific appointment
            var ca2 = new Customer_Appointment(c1, a2);//associates customer to specific appointment
            var ca3 = new Customer_Appointment(c2, a3);//associates customer to specific appointment

            customers = new Customers(); //makes new customer calling customer class
            customers.customers.Add(c1); //adds c1 to the customer class
            customers.customers.Add(c2); //adds c2 to the customer class

            customerAppointments = new List<Appointments>(); //creates a new list of appointments
            customerAppointments.Add(a1); //adds customer appointments to the customer appointment class
            customerAppointments.Add(a2);//adds customer appointments to the customer appointment class
            customerAppointments.Add(a3);//adds customer appointments to the customer appointment class

            appointments = new List<Customer_Appointment>(); //creates a new list of customers and appointmets
            appointments.Add(ca1); // adds appointments to the doctor's calendar
            appointments.Add(ca2);// adds appointments to the doctor's calendar
            appointments.Add(ca3);// adds appointments to the doctor's calendar




        }

        static void Menu() //menu method
        {
            bool done = false; //creates a way to end the loop

            while (!done) // loop for basic operations
            {
                Console.WriteLine("Options: Login: 1 --- Logout: 2 --- Sign Up: 3 --- Appointments: 4 --- Clear Screen: c --- Quit: q ---"); //presents options for basic operations
                Console.Write("Choice: ");
                string choice = Console.ReadLine(); //records the option selection by the customer
                switch (choice) //based on the user's selection...
                {
                    case "1": // if the user chooses 1...
                        LoginMenu(); //sends them to the login menu
                        break; //breaks loop
                    case "2": // if the user chooses 2...
                        LogoutMenu(); //sends them to the logout menu
                        break;//stops if option is selected
                    case "3": //if the user chooses 3...
                        SignUpMenu();
                        break;//stops if option is selected
                    case "4": //if the user chooses 4...
                        GetCurrentAppointmentsMenu();
                        break;//stops if option is selected
                    case "c": //if the user chooses 5=c...
                        Console.Clear();
                        break;//stops if option is selected
                    case "q": //if the user chooses q...
                        done = true;
                        break;//stops if option is selected
                    default: //the default option
                        Console.WriteLine("Invalid command!");//their choice wasn't one of the ones listed
                        break;//stops if option is selected
                }

            }

        }
        static void LoginMenu() //pulls the information for the logging in
        {
            if (authenticatedCustomer == null) //testing if the customer is an existing customer
            {
                Console.Write("Enter your username: "); //prompting to add username
                string username = Console.ReadLine();//displaying the username
                Console.Write("Enter your password: "); //prompting to add password
                string password = Console.ReadLine(); //displaying the password
                authenticatedCustomer = customers.Authenticate(username, password); //checking to see if the username and password match
                if (authenticatedCustomer != null) //if the username and password check out
                {
                    Console.WriteLine($"Welcome {authenticatedCustomer.FirstName}"); //welcome individual
                } 
                else
                {
                    Console.WriteLine("invalid username or password"); //password and username are not a match
                }
            }
            else
            {
                Console.WriteLine($"You are already logged in as {authenticatedCustomer.Username}");//they are already logged in
            }
        }
        static void LogoutMenu() //prompting the log out method
        {
            authenticatedCustomer = null;
            Console.WriteLine("Logged out!"); //user is informed that they are logged out
        }

        static void SignUpMenu() //adding new customer to the system
        {
            Console.Write("First Name: "); //asking for their first name
            string firstName = Console.ReadLine(); //saving the first name
            Console.Write("Last Name: "); //asking for the last name
            string LastName = Console.ReadLine(); //saving the last name
            Console.Write("Username: ");//creating the username
            string username = Console.ReadLine();//saving the username
            Console.Write("Password: "); //creating the password
            string password = Console.ReadLine(); //saving the password
             
            var newCustomer = new Customer //adding the customer to customer class
            {
                FirstName = firstName,
                LastName = LastName,
                Username = username,
                Password = password
            };

            customers.customers.Add(newCustomer); //added the new customer to the customer list

            Console.WriteLine("Profile created!"); //profile has been created

        }


        static void GetCurrentAppointmentsMenu() //calling the current appointments menu
        {
            if (authenticatedCustomer == null) //if the customer isn't logged in
            {
                Console.WriteLine("You are not logged in."); //they need to sign in before scheduling appointment
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
            bool done = false;
            while(!done)
            {
                Console.WriteLine("Appointment Options: Cleaning: 1 -- Root Canal: 2 -- Extraction: 3 -- Filling: 4 -- X-Ray: 5 -- Clear Screen: 6 -- Quit: q--");
                Console.WriteLine("Appointment Type: ");
                string type = Console.ReadLine();
                switch (type)
                {
                    case "1":
                        Console.WriteLine("You've signed up for a cleaning with Dr. Aldrin");
                        break;//stops if option is selected
                    case "2":
                        Console.WriteLine("You've signed up for a Root Canal with Dr. Stinson");
                        break;//stops if option is selected
                    case "3":
                        Console.WriteLine("You've signed up for a Extraction with Dr. Scherbatsky");
                        break;//stops if option is selected
                    case "4":
                        Console.WriteLine("You've signed up for a Filling with Dr. Aldrin");
                        break;//stops if option is selected
                    case "5":
                        Console.WriteLine("You've signed up for an X-Ray with Dr. Stinson");
                        break;//stops if option is selected
                    case "6":
                        Console.Clear();
                        break;//stops if option is selected
                    case "q":
                        done = true;
                        break;//stops if option is selected
                    default:
                        Console.WriteLine("Invalid option!");
                        break;//stops if option is selected
                };
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
