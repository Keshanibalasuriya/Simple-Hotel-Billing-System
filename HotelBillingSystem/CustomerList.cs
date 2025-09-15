using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelBillingSystem
{
    internal class CustomerList
    {
        public static List<Customer> customers = new List<Customer>();


        public static void  AddCustomer(Customer customer) { 
            customers.Add(customer);
        }

        public static List<Customer> GetCustomers() { 
            return customers;
        }

        public static int GetNextCustomerNo()
        {
            return customers.Count + 1;
        }


    }
}
