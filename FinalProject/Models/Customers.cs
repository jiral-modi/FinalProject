namespace FinalProject.Models
{
    public class Customers
    {
        public List<Customer> customers { get; set;}//

        public Customers()
        {
            customers = new List<Customer>();
        }

        public Customer Authenticate(string username, string password)
        {
            var c = customers.Where(o => o.UserName == username).First();
            //return the object where the object.username matches the username sent to this method
            if (c != null)
            {
                if(c.Password == password)

                {
                    return c;
                }
                else
                {
                    return null;
                }
            }
            return null;
        }
    }
}
