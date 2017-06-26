using DAL;
using Repository.UnitOfWork;
using System;
using System.Collections.Generic;

namespace ConsoleTester
{
    class Program
    {
        private UnitOfWork unitOfWork = new UnitOfWork();

        static void Main(string[] args)
        {
            UnitOfWork unitOfWork = new UnitOfWork();
            Console.WriteLine("Processing Start");

            //Add
            Customer customer = new Customer()
            {
                Name = "Aaron"
            };

            unitOfWork.CustomerRepo.Add(customer);
            unitOfWork.Complete();
            Console.WriteLine("Customer " + customer.Name + " created successfully");
            Console.WriteLine("");

            //AddRange
            List<Customer> customers = new List<Customer>();

            customers.Add(new Customer { Name = "Barbara" });
            customers.Add(new Customer { Name = "Charles" });
            customers.Add(new Customer { Name = "Dennis" });
            customers.Add(new Customer { Name = "Ellen" });
            customers.Add(new Customer { Name = "Farrah" });

            unitOfWork.CustomerRepo.AddRange(customers);
            unitOfWork.Complete();

            //List all customers
            IEnumerable<Customer> ExistingCustomers = unitOfWork.CustomerRepo.GetAll();
            Console.WriteLine("List of all created customers");

            foreach (var existingcustomer in ExistingCustomers)
            {
                Console.WriteLine(existingcustomer.Name);
            }

            Console.WriteLine("");

            //Update
            customer.Name = "Gerald";
            unitOfWork.Complete();

            //List all customers
            ExistingCustomers = unitOfWork.CustomerRepo.GetAll();
            Console.WriteLine("Update Aaron to Gerald");

            foreach (var existingcustomer in ExistingCustomers)
            {
                Console.WriteLine(existingcustomer.Name);
            }

            Console.WriteLine("");

            //Delete Gerald
            unitOfWork.CustomerRepo.Remove(customer);
            unitOfWork.Complete();

            //List all customers
            ExistingCustomers = unitOfWork.CustomerRepo.GetAll();
            Console.WriteLine("Delete Gerald");

            foreach (var existingcustomer in ExistingCustomers)
            {
                Console.WriteLine(existingcustomer.Name);
            }

            Console.WriteLine("");

            unitOfWork.CustomerRepo.RemoveRange(customers);
            unitOfWork.Complete();

            //List all customers
            ExistingCustomers = unitOfWork.CustomerRepo.GetAll();
            Console.WriteLine("Delete all customer");

            foreach (var existingcustomer in ExistingCustomers)
            {
                Console.WriteLine(existingcustomer.Name);
            }

            Console.WriteLine("Processing End");
            Console.ReadLine();
        }
    }
}
