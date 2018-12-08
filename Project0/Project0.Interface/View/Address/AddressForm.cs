using Project0.DataAccess;
using Project0.Interface.View.Menu;
using Project0.Library.Control.Model;
using System;
using System.Collections.Generic;
using System.Text;
using AddressesDataAccess = Project0.DataAccess.Addresses;
using CustomerDataAccess = Project0.DataAccess.Customers;

namespace Project0.Interface.View.Address
{
    public class AddressForm
    {
        public static void ShowForm()
        {
            AddressController controller = new AddressController();
            //AddressDataAccess customer = new AddressDataAccess();
            AddressesDataAccess address = new AddressesDataAccess();
            
            CustomerController customerController = new CustomerController();
            List<CustomerDataAccess> customersList = customerController.getAll();
            CustomerDataAccess customer = new CustomerDataAccess();
            int customerId = 0;

            Console.WriteLine("New Address");

            //Show all customers
            foreach(CustomerDataAccess c in customersList)
            {
                Console.WriteLine(c.ToString());
            }

            //Select Customer
            Console.WriteLine("\nSelect Customer to add address:\n");
            customerId = Int32.Parse(Console.ReadLine());
            customer = customerController.FindById(customerId);
            
            ClearHelper.Clear();

            address.CustomerId = customerId;

            //New Address
            Console.WriteLine("New Address");
            Console.WriteLine($"Customer: {customer.ToString()}\n");

            Console.Write("Address Line 1:\n");
            address.Address1 = Console.ReadLine();

            Console.Write("Address Line 2:\n");
            address.Address2 = Console.ReadLine();

            Console.Write("City:\n");
            address.City = Console.ReadLine();

            do
            {
                Console.Write("State: (2 letters)\n");
                address.State = Console.ReadLine();
            } while (address.State.Length != 2);

            Console.Write("ZipCode:\n");
            address.Zipcode = Int32.Parse(Console.ReadLine());
            
            controller.Save(address);

            Console.WriteLine("\nAddress saved!\n");
            Console.ReadKey();
            ClearHelper.Clear();
        }
    }
}
