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
      Console.WriteLine("When you're ready for checkout, enter \"checkout\" to see your");
      Console.WriteLine("final cost or enter \"exit\" to cancel/go back to Main Menu.");
      Console.WriteLine("Enter your order: [QUANTITY] [ITEM] (example: 2 bread)");

      Regex rx = new Regex("\\s+");
      string inputOrder = (Console.ReadLine()).ToLower();
      if (rx.IsMatch(inputOrder))
      {
        Console.WriteLine("input has whitespaces");
      }
      
      // if (inputOrder.Length < 1)
      // {
      //   switch(inputOrder[0])
      //   {
      //     case "checkout":
      //       Console.WriteLine("Here's your total = ...");
      //       stillBrowsing = false;
      //       break;
      //     case "exit":
      //       Console.WriteLine("You are done browsing our menu.");
      //       stillBrowsing = false;
      //       break;
      //     default:
      //       Console.WriteLine(">>> Invalid input. Please try again.");
      //       break;
      //   }
      // }
      // else
      // {
      //   inputOrder = inputOrder.Split(" ");
      //   int inputQuantity = int.Parse(inputOrder[0]);
      //   string inputItem = inputOrder[1];
      //   switch(inputItem)
      //   {
      //     case "bread":
      //       break;
      //     case "pastry":
      //       break;
      //     default:
      //       Console.WriteLine(">>> Invalid input. Please try again.");
      //       break;
      //   }
      // }
      
    }
  }
}