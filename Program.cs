using Crud_Task.Context;
using Crud_Task.Module;
using System;

namespace Crud_Task
{
    internal class Program
    {
        static void Main(string[] args)
        {
            CrudDbContext crudDbContext = new CrudDbContext();

            Product product = new Product() { Name = "Laptop", Price = 2000 };
            Order order = new Order() { Address = "Ramallah" };
            //Insert Date
            crudDbContext.products_crud.Add(product);
            crudDbContext.orders.Add(order);
            crudDbContext.SaveChanges();
            
            //Get All Data
            var products = crudDbContext.products_crud.ToList();
            var orders = crudDbContext.orders.ToList();
         
            //Update
            var update_Product = crudDbContext.products_crud.First(P => P.Id ==1);
            update_Product.Name = "Airpods";

            var update_order = crudDbContext.orders.First(O =>O.Id ==1);
            update_order.CreatedAt = DateTime.Now;
            crudDbContext.SaveChanges();

           var delete_product = crudDbContext.products_crud.First(P =>P.Id ==2);
            crudDbContext.products_crud.Remove(delete_product);

            var delete_order = crudDbContext.orders.First(O =>O.Id ==3);
            crudDbContext.orders.Remove(delete_order);
            Console.WriteLine("Data saved successfully.");
        }
    }
}
