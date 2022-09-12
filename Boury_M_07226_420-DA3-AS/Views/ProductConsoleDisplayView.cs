/*
 * (c) Copyright 2022 Marc-Eric Boury
 */

using IrinaKuzmitskaya_pr.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IrinaKuzmitskaya_pr.Views {
    internal class ProductConsoleDisplayView : IModelView<Product> {

        public ProductConsoleDisplayView() { 
        }

        public void Render(Product modelInstance) {
            Console.WriteLine($"Id: {modelInstance.Id} " +
                $"\nName: {modelInstance.Name} " +
                $"\nQty In Stock: {modelInstance.QtyInStock} " +
                $"\nGTIN code: {modelInstance.GtinCode} " +
                $"\nDescription: {modelInstance.Description}");
        }
    }
}
