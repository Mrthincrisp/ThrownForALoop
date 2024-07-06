List<Product> products =
[
    new Product()
    { 
        Name = "Football", 
        Price = 15.00m,
        Sold = true,
        StockDate = new DateTime(2024, 7, 1),
        ManufactureYear = 2010,
        Condition = 4.2
    },
    new Product() 
    { 
        Name = "Hockey Stick", 
        Price = 12.99m, 
        Sold = false,
        StockDate = new DateTime(2024, 7, 1),
        ManufactureYear = 2011,
        Condition = 6.7
    },
    new Product()
      {
        Name = "Broken Bat",
        Price = 2.00m,
        Sold = false,
        StockDate = new DateTime(2024, 7, 1),
        ManufactureYear = 2001,
        Condition = 1.2
      },
    new Product()
    {
      Name = "Batche ball",
      Price = 5.76m,
      Sold = true,
      StockDate = new DateTime(2024, 1, 2),
      ManufactureYear = 2021,
      Condition = 3.3
    },
    new Product()
    {
      Name = "Hunting Rifle",
      Price = 45.87m,
      Sold = false,
      StockDate = new DateTime(2022, 10, 20),
      ManufactureYear = 2010,
      Condition = 3.5
    },
    new Product()
    {
      Name = "frisbee",
      Price = 3.43m,
      Sold = false,
      StockDate = new DateTime(2019, 9, 2),
      ManufactureYear = 2021,
      Condition = 2.5
    }
    
];

string greeting = @"Welcome to Thrown for a Loop!
Your one-stop shop for used sporting equipment, please make a selection from below~";

Console.WriteLine(greeting);
string choice = null;
while (choice != "0")
{
    Console.WriteLine(@"Choose an option:
                        0. Exit
                        1. View All Products
                        2. View Product Details
                        3. Latest");
    choice = Console.ReadLine();
    if (choice == "0")
    {
        Console.WriteLine("Goodbye!");
    }
    else if (choice == "1")
    {
        ListProducts();
    }
    else if (choice == "2")
    {
        ViewProductDetails();
    }
    else if (choice == "3")
    {
    ViewLatestProducts();
    }
    }

void ViewProductDetails()
{
  ListProducts();
Product chosenProduct = null;

while (chosenProduct == null)
{
    Console.WriteLine("Please enter a product number:");
    try 
    {
      int response = int.Parse(Console.ReadLine().Trim());
      chosenProduct = products[response - 1];
    }
    catch (FormatException) // if this error occurs the 
    {
      Console.WriteLine("a product NUMBER is required");
    }
    catch (Exception ex)
    {
        Console.WriteLine(ex);
        Console.WriteLine("Do better!");
    }
}

DateTime now = DateTime.Now;

TimeSpan timeInStock = now - chosenProduct.StockDate;
Console.WriteLine(@$"You chose: 
{chosenProduct.Name}, which costs {chosenProduct.Price} dollars.
It is {now.Year - chosenProduct.ManufactureYear} years old. 
It {(chosenProduct.Sold ? "is not available." : $"has been in stock for {timeInStock.Days} days.")}");


}

void ListProducts()
{
    decimal totalValue = 0.0M;
    foreach (Product product in products)
    {
        if (!product.Sold)
        {
            totalValue += product.Price;
        }
    }
    Console.WriteLine($"Total inventory value: ${totalValue}");
    Console.WriteLine("Products:");
    for (int i = 0; i < products.Count; i++)
    {
        Console.WriteLine($"{i + 1}. {products[i].Name}");
    }
}

void ViewLatestProducts()
{
    // create a new empty List to store the latest products
    List<Product> latestProducts = new List<Product>();
    // Calculate a DateTime 90 days in the past
    DateTime threeMonthsAgo = DateTime.Now - TimeSpan.FromDays(90);
    //loop through the products
    foreach (Product product in products)
    {
        //Add a product to latestProducts if it fits the criteria
        if (product.StockDate > threeMonthsAgo && !product.Sold)
        {
            latestProducts.Add(product);
        }
    }
    // print out the latest products to the console 
    for (int i = 0; i < latestProducts.Count; i++)
    {
        Console.WriteLine($"{i + 1}. {latestProducts[i].Name}");
    }
}
