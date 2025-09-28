// See https://aka.ms/new-console-template for more information
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Security.AccessControl;
using System.Text.Json;

class Inventory
{
  int count = 0;
  static readonly List<Product> products = new();



  public void ViewProducts()
  {


    if (count > 0)
    {
      if (products.Count == 0)
      {
        Console.Title = "All Products";
        Console.WriteLine("Sorry! There are no products in the inventory 2");
        return;
      }
      else
      {
        Console.WriteLine("Here are all the Products in the inventory:");
        Console.WriteLine(" ");
        foreach (Product product in products)
        {
          string productString = $"Product ID: {product.Id} - Product Name: {product.Name} - Quantity: {product.quantity}";
          Console.WriteLine(productString);
        }
        return;
      }
    }

    if (!File.Exists("inventory.json"))
    {
      Console.WriteLine("Sorry! There are no products in the inventory");
      count = 1;
      return;
    }
    var textjson = File.ReadAllText("inventory.json");

    List<Product> loadJson = JsonSerializer.Deserialize<List<Product>>(textjson)!;
    products.AddRange(loadJson);
    Console.WriteLine("Here are all the Products in the inventory:");
    Console.WriteLine(" ");
    foreach (Product product in products)
    {
      string productString = $"Product ID: {product.Id} - Product Name: {product.Name} - Quantity: {product.quantity}";
      Console.WriteLine(productString);
    }
    count = 1;

  }


  public void AddProduct()
  {


    Console.WriteLine("What is the name of the product?: ");
    var productNameString = Console.ReadLine();

    Console.WriteLine("What is the price of the product?: ");

    var productPriceString = Console.ReadLine();

    Console.WriteLine("What is the quantity of the product?: ");

    var intproductQuantiyString = Console.ReadLine();

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
    Random ran = new();
    int id = ran.Next(1, 1000);
    Product product = new()
    {
      Name = productNameString,
      Id = id,
      quantity = quantity,
      Price = price
    };
    products.Add(product);

    Console.WriteLine("Product added successfully!");
  }




  public void UpdateProduct(int productId)
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
  public void RemoveProduct(string productId)
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


  public static void SaveProduct()
  {
    if (products.Count == 0)
    {
      Console.WriteLine("Sorry No Product in the inventory!");
      return;
    }

    string json = JsonSerializer.Serialize(products);
    File.WriteAllText("inventory.json", json);
    Console.WriteLine($"{products.Count} has been saved to file");
  }
}



