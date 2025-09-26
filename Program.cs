// See https://aka.ms/new-console-template for more information
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

class Inventory
{


  static List<Product> products = new List<Product>();



  static void Main(string[] args)
  {
    while (true)
    {
      Console.WriteLine("                      Welcome to the Inventory management App.            ");
      Console.WriteLine("                        -------------------------------------                    ");
      Console.WriteLine("Please select what you intend to do");
      Console.WriteLine("1. View all the available stocks");
      Console.WriteLine("2. Add product to stock");
      Console.WriteLine("3. Update Product");
      Console.WriteLine("4. Remove Product from Inventory");
      Console.WriteLine("5. Exit Program");

      var number = Console.ReadLine();

      switch (number)
      {
        case "1":
          ViewProducts();
          break;
        case "2":
          AddProduct();
          break;
        case "3":
          Console.WriteLine("Please indicate which product you want to update");
          var productId = Console.ReadLine();
          int id;
          if (!int.TryParse(productId, out id))
          {
            Console.WriteLine("Invalid Id number");
            return;
          }
          UpdateProduct(id);


          break;
        case "4":
          Console.WriteLine("Please indicate which product you want to remove");
          var removeProductId = Console.ReadLine();

          if (removeProductId == null)
          {
            Console.WriteLine("Invalid Id number");
            return;
          }
          RemoveProduct(removeProductId);
          break;
        case "5":
          Environment.Exit(0);
          break;
        default:
          Console.WriteLine("Invalid Choice");
          break;

      }
    }
  }

  static void ViewProducts()
  {
    if (products.Count == 0)
    {
      Console.Title = "All Products";
      Console.WriteLine("Sorry! There are no products in the inventory");
      return;
    }
    else
    {
      Console.WriteLine("Here are all the Products in the inventory:");
      Console.WriteLine(" ");
      Console.WriteLine(products);
      foreach (Product product in products)
      {
        string productString = $"Product ID: {product.Id} - Product Name: {product.Name} - Quantity: {product.quantity}";
        Console.WriteLine(productString);
      }
    }

  }

  static void AddProduct()
  {


    Console.WriteLine("What is the name of the product?: ");
    var productNameString = Console.ReadLine();

    Console.WriteLine("What is the price of the product?: ");

    var productPriceString = Console.ReadLine();

    Console.WriteLine("What is the quantity of the product?: ");

    var intproductQuantiyString = Console.ReadLine();
    Random rnd = new Random();
    int id = rnd.Next(1, 100000);

    int price;
    int quantity;

    if (!int.TryParse(productPriceString, out price))
    {
      Console.WriteLine("Invalid price entered.");
      return;
    }

    if (!int.TryParse(intproductQuantiyString, out quantity))
    {
      Console.WriteLine("Invalid quantity entered.");
      return;
    }
    if (productNameString == null)
    {
      return;
    }
    {
      Product newProduct = new Product
      {
        Id = id,
        Name = productNameString,
        Price = price,
        quantity = quantity
      };

      Console.WriteLine(newProduct);
      products.Add(newProduct);
     
      Console.WriteLine("Product added successfully!");







    }
  }

  static void UpdateProduct(int productId)
  {
    Product productToUpdate = products.Find(p => p.Id == productId)!;
    if (productToUpdate == null)
    {
      Console.WriteLine("Product not found.");
      return;
    }

    Console.WriteLine($"Updating Product: {productToUpdate.Name}");

    Console.WriteLine("Enter new name (leave blank to keep current):");
    var newName = Console.ReadLine();
    if (!string.IsNullOrWhiteSpace(newName))
    {
      productToUpdate.Name = newName;
    }

    Console.WriteLine("Enter new price (leave blank to keep current):");
    var newPrice = Console.ReadLine();
    if (!string.IsNullOrWhiteSpace(newPrice))
    {
      int price;
      if (int.TryParse(newPrice, out price))
      {
        productToUpdate.Price = price;
      }
      else
      {
        Console.WriteLine("Invalid price entered. Keeping current price.");
      }
    }

    Console.WriteLine("Enter new quantity (leave blank to keep current):");
    var newQuantity = Console.ReadLine();
    if (!string.IsNullOrWhiteSpace(newQuantity))
    {
      int quantity;
      if (int.TryParse(newQuantity, out quantity))
      {
        productToUpdate.quantity = quantity;
      }
    }



  }
  static void RemoveProduct(string productId)
  {
    int id;
    if (!int.TryParse(productId, out id))
    {
      return;
    }
    Product productToRemove = products.Find(p => p.Id == id)!;
    if (productToRemove != null)
    {
      products.Remove(productToRemove);
      Console.WriteLine("Product removed successfully!");
    }
    else
    {
      Console.WriteLine("Product not found.");
    }
  }

}


class Product
{

  public int Id { get; set; }
  public required string Name { get; set; }

  public required int Price { get; set; }

  public required int quantity { get; set; }

}
