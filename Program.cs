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
      Console.WriteLine("  ___      _ _      _      ___       _                ");
      Console.WriteLine(" |   \\ ___| | |__ _( )___ | _ ) __ _| |_____ _ _ _  _ ");
      Console.WriteLine(" | |) / -_) | / _` |/(_-< | _ \\/ _` | / / -_) '_| || |");
      Console.WriteLine(" |___/\\___|_|_\\__,_| /__/ |___/\\__,_|_\\_\\___|_|  \\_, |");
      Console.WriteLine("                                                 |__/ ");
      Console.WriteLine("Welcome to Della's Bakery! Our bread and pastry contains");
      Console.WriteLine("the finest local sugar, butter and flour ingredients. Enjoy!");
    }

    public static void ConsoleMenu()
    {
      Console.WriteLine(">>> Please type in a NUMBER from our menu options below:");
      Console.WriteLine("1. Have a look at our baked goods!");
      Console.WriteLine("2. Exit");
      string inputConsoleMenu = Console.ReadLine();

      switch(inputConsoleMenu)
      {
        case "1":
          stillBrowsing = true;
          while(stillBrowsing)
          {
            BakeryMenu();
          }
          break;
        case "2":
          Console.WriteLine(">>> Goodbye! See you next time!");
          stillShopping = false;
          break;
        default:
          Console.WriteLine(">>> Invalid input. Please try again.");
          break;
      }
    }

    public static void BakeryMenu()
    {
      Console.WriteLine("===== Della's Baked Goods =====");
      Console.WriteLine("World's Best Bread $5/loaf");
      Console.WriteLine("World's Best Pastry $2/piece");
      Console.WriteLine("When you're ready for CHECKOUT, enter \"CHECKOUT\" to see your");
      Console.WriteLine("final cost or enter \"EXIT\" to cancel/go back to Main Menu.");
      Console.WriteLine("Enter your order: [QUANTITY] [ITEM] (example: 2 bread)");
      string inputOrder = (Console.ReadLine()).ToLower();
      Regex rx = new Regex("\\s+");

      if (rx.IsMatch(inputOrder))
      {
        AreMultipleOrders(inputOrder);
        string[] inputArr = inputOrder.Split(" ");
        int inputQuantity = int.Parse(inputArr[0]);
        string inputItem = inputArr[1];
        // userShoppingCart = new ShoppingCart(5, 3);
        switch(inputItem)
        {
          case "bread":

            break;
          case "pastry":
            break;
          default:
            Console.WriteLine(">>> Invalid input. Please try again.");
            break;
        }
      }
      else
      {
        switch(inputOrder)
        {
          case "checkout":
            Console.WriteLine("Here's your total = ...");
            stillBrowsing = false;
            break;
          case "exit":
            Console.WriteLine("You are done browsing our menu.");
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

        // Report the number of matches found.
        Console.WriteLine("{0} matches found in:\n   {1}", 
                          matches.Count, 
                          inputOrder);

        // Report on each match.
        foreach (Match match in matches)
        {
            Console.WriteLine("Found '{0}' at position {1}", match.Value, match.Index);
        }
      }
      
    }
  }
}