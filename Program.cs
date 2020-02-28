using System;
using System.Collections.Generic;
using Bakery.Models;

namespace Bakery
{
  public class Program
  {
    public static bool stillShopping = true;
    public static void Main()
    {
      WelcomeMessage();
      while(stillShopping)
      {
        MainMenu();
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

    public static void MainMenu()
    {
      Console.WriteLine(">>> Please type in a NUMBER from our menu options below:");
      Console.WriteLine("1. Have a look at our baked goods!");
      Console.WriteLine("2. Exit");
      string input = Console.ReadLine();
      switch(input)
      {
        case "1":
          Console.WriteLine("Della's Baked Goods");
          break;
        case "2":
          Console.WriteLine(">>> Goodbye! See you next time!");
          Environment.Exit(0);
          break;
        default:
          Console.WriteLine(">>> Invalid input. Please try again.");
          break;
      }

    }
  }
}