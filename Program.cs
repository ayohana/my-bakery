using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using Bakery.Models;

namespace Bakery
{
  public class Program
  {
    public static bool stillShopping = true;
    public static bool stillBrowsing = false;
    public static ShoppingCart userShoppingCart;

    public static void Main()
    {
      WelcomeMessage();
      while(stillShopping)
      {
        ConsoleMenu();
      }
    }

    public static void WelcomeMessage()
    {
      Console.WriteLine("                                                      ");
      Console.WriteLine("   ___      _ _      _      ___       _                ");
      Console.WriteLine("  |   \\ ___| | |__ _( )___ | _ ) __ _| |_____ _ _ _  _ ");
      Console.WriteLine("  | |) / -_) | / _` |/(_-< | _ \\/ _` | / / -_) '_| || |");
      Console.WriteLine("  |___/\\___|_|_\\__,_| /__/ |___/\\__,_|_\\_\\___|_|  \\_, |");
      Console.WriteLine("                                                  |__/ ");
      Console.WriteLine("Welcome to Della's Bakery! Our bread and pastry contains");
      Console.WriteLine("the finest local sugar, butter and flour ingredients. Enjoy!");
    }

    public static void ConsoleMenu()
    {
      Console.WriteLine(">>> Please type in a [NUMBER] from our Menu Options below:");
      Console.WriteLine("1. Have a look at our baked goods!");
      Console.WriteLine("2. See our special deals this week!");
      Console.WriteLine("3. Exit");
      string inputConsoleMenu = Console.ReadLine();
      switch(inputConsoleMenu)
      {
        case "1":
          stillBrowsing = true;
          BakeryMenu();
          while(stillBrowsing)
          {
            BakeryMenuOptions();
          }
          break;
        case "2":
          DisplaySpecialDeals();
          break;
        case "3":
          Console.WriteLine(">>> Goodbye! See you next time!");
          stillShopping = false;
          break;
        default:
          Console.WriteLine(">>> Invalid input. Please try again.");
          break;
      }
    }

    public static void DisplaySpecialDeals()
    {
      Console.WriteLine(" __| |_________________________________________| |__");
      Console.WriteLine("(__   _________________________________________   __)");
      Console.WriteLine("   | |                                         | |");
      Console.WriteLine("   | |   .~\"~._Della's Weekly Specials_.~\"~.   | |");
      Console.WriteLine("   | |        BREAD: Buy 2, get 1 free.        | |");
      Console.WriteLine("   | |     PASTRY: Buy 1 for $2 or 3 for $5.   | |");
      Console.WriteLine(" __| |_________________________________________| |__");
      Console.WriteLine("(__   _________________________________________   __)");
      Console.WriteLine("   | |                                         | |");
    }

    public static void BakeryMenu()
    {
      Console.WriteLine("======= Della's Baked Goods =======");
      Console.WriteLine("    World's Best Bread $5/loaf");
      Console.WriteLine("   World's Best Pastry $2/piece");
      Console.WriteLine("===================================");
    }

    public static void BakeryMenuOptions()
    {
      Console.WriteLine(">>> Enter \"EXIT\" to go back to Main Menu.");
      Console.WriteLine(">>> Enter \"CHECKOUT\" when you're ready to see your final cost.");
      Console.WriteLine(">>> Enter your order: [QUANTITY] [ITEM] (example: 2 bread 3 pastry)");
      string inputOrder = (Console.ReadLine()).ToLower();
      Regex rx = new Regex("\\s+");
      if (rx.IsMatch(inputOrder))
      {
        userShoppingCart = new ShoppingCart();
        AreMultipleOrders(inputOrder);
      }
      else
      {
        switch(inputOrder)
        {
          case "checkout":
            userShoppingCart.CalculateTotalCost();
            DisplayReceipt();
            stillBrowsing = false;
            break;
          case "exit":
            Console.WriteLine(">>> Heading back to our Main Menu...");
            stillBrowsing = false;
            break;
          default:
            Console.WriteLine(">>> Invalid input. Please try again.");
            break;
        }
      }
    }

    public static void AreMultipleOrders(string inputOrder)
    {
      Regex NumberSpaceWord = new Regex("[0-9]+\\s\\w+");
      Match eachMatch = NumberSpaceWord.Match(inputOrder);
      if (eachMatch.Success)
      {
        MatchCollection matches = NumberSpaceWord.Matches(inputOrder);
        if (matches.Count > 2)
        {
          Console.WriteLine(">>> Too many items specified. Please try again.");
        }
        else if (matches.Count > 0)
        {
          foreach (Match match in matches)
          {
            string[] eachOrderArr = (match.Value).Split(" ");
            int inputQuantity = int.Parse(eachOrderArr[0]);
            string inputItem = eachOrderArr[1];
            switch(inputItem)
            {
              case "bread":
                userShoppingCart.AddBread(inputQuantity);
                break;
              case "pastry":
                userShoppingCart.AddPastry(inputQuantity);
                break;
              default:
                Console.WriteLine(">>> Unknown item(s) specified. Please try again.");
                break;
            }
          }
        }
        else
        {
          Console.WriteLine(">>> Invalid input. Please try again.");
        }
      }
    }

    public static void DisplayReceipt()
    {
      Console.WriteLine("========= Customer Receipt =========");
      Console.WriteLine("                                    ");
      if (userShoppingCart.BreadOrder != null)
      {
        Console.WriteLine($"  {userShoppingCart.BreadOrder.InputOrder} x Bread Loaves        ${userShoppingCart.BreadOrder.TotalItemCost}");
        Console.WriteLine($"    Weekly Special:");
        Console.WriteLine($"    You also get {userShoppingCart.CountFreeBread()} free bread.");
      }
      if (userShoppingCart.PastryOrder != null)
      {
        Console.WriteLine($"  {userShoppingCart.PastryOrder.InputOrder} x Pastry              ${userShoppingCart.PastryOrder.TotalItemCost}");
        Console.WriteLine($"    Weekly Special:");
        Console.WriteLine($"    New pastry total = ${userShoppingCart.ApplyPastryDiscount()}");
      }
      Console.WriteLine("                                    ");
      Console.WriteLine($"  Your Total = ${userShoppingCart.TotalCost}");
      Console.WriteLine("                                    ");
      Console.WriteLine("Thanks for purchasing Della's today!");
      Console.WriteLine("                                    ");
      Console.WriteLine("====================================");
    }
  }
}