/*
 * (c) 
 */

using IrinaKuzmitskaya.Models;
using IrinaKuzmitskaya_pr.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IrinaKuzmitskaya_pr.Controllers {
    internal class CustomerController : IController {


        public void CreateCustomer(string Email) {
            CreateCustomer(Email, "", "");
        }

        public void CreateCustomer(string Email, string FirstName, string LastName) {
            Customer customer = new Customer(Email, FirstName, LastName);
            customer.Insert();
            MessageBox.Show("New Customer is created"); 
        }

        public void DisplayCustomer(int customerId) {
            Customer customer = new Customer(customerId);
            customer.GetById();
            this.DisplayCustomer(customer);
        }

        public void DisplayCustomer(Customer customer) {
            // do something later in the course when we have views, or, if you want,
            // dump the data to the console.
        }

        public void UpdateCustomer(int customerId, string FirstName, string LastName, string Email) {
            Customer customer = Customer.GetById(customerId);
            customer.FirstName = FirstName;
            customer.LastName = LastName;
            customer.Email = Email;
            customer.Update();
            MessageBox.Show("Information is updated");
        }

        public void DeleteCustomer(int customerId, MessageBox messageBox) {
            Customer customer = new Customer(customerId);
            
                this.DeleteCustomer(customer);
            MessageBox.Show("Customer is deleted");



        }

        public void DeleteCustomer(Customer customer) {
            customer.Delete();
        }
    }
}
