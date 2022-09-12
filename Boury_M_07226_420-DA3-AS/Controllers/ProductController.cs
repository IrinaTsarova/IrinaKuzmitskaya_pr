/*
 * (c) 
 */

using IrinaKuzmitskaya_pr.Models;
using IrinaKuzmitskaya_pr.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IrinaKuzmitskaya_pr.Controllers {
    internal class ProductController : IController {

        public void CreateProduct(string name, int qtyInStock) {
            CreateProduct(name, qtyInStock, 0L);
        }

        public void CreateProduct(string name, int qtyInStock, long gtinCode) {
            CreateProduct(name, qtyInStock, 0L, "");
        }

        public void CreateProduct(string name, int qtyInStock, long gtinCode, string description) {
            Product newProduct = new Product(name, qtyInStock, gtinCode, description);
            newProduct.Insert();
            MessageBox.Show("New product is add");
        }

        public void DisplayProduct(int productId) {
            Product product = new Product(productId);
            product.GetById();
            this.DisplayProduct(product);
        }

        public void DisplayProduct(Product product) {
            
        }

        public void UpdateProduct(int productId, string name, int qtyInStock, long gtinCode, string description) {
            Product product = Product.GetById(productId);
            product.Name = name;
            product.QtyInStock = qtyInStock;
            product.GtinCode = gtinCode;
            product.Description = description;
            product.Update();
            MessageBox.Show("Information is updated");
        }

        public void DeleteProduct(int productId) {
            Product product = new Product(productId);
            this.DeleteProduct(product);
        }

        public void DeleteProduct(Product product) {
            product.Delete();
            MessageBox.Show("Product is deleted");
        }

        //public void DisplayProducts(List<Product> productList) {
        //    foreach (Product product in productList) {
        //        this.DisplayProduct(product);
        //    }
        //}

    }
}
