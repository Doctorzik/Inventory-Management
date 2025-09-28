class Program
{



  static readonly Inventory inventory = new();


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
      Console.WriteLine("5. Save all Products");
      Console.WriteLine("6. Exit Program");

      var number = Console.ReadLine();

      switch (number)
      {
        case "1":
          inventory.ViewProducts();
          break;
        case "2":
          inventory.AddProduct();
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
          inventory.UpdateProduct(id);


          break;
        case "4":
          Console.WriteLine("Please indicate which product you want to remove");
          var removeProductId = Console.ReadLine();

          if (removeProductId == null)
          {
            Console.WriteLine("Invalid Id number");
            return;
          }
          inventory.RemoveProduct(removeProductId);
          break;
        case "5":
          Inventory.SaveProduct();
          break;
        case "6":
          Environment.Exit(0);
          break;
        default:
          Console.WriteLine("Invalid Choice");
          break;

      }
    }
  }


}