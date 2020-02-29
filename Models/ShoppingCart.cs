using System;
using System.Collections.Generic;

namespace Bakery.Models
{
  public class ShoppingCart
  {
    public Bread BreadOrder { get; set; }
    public Pastry PastryOrder { get; set; }
    public int TotalCost { get; set; }

    public void AddBread(int inputOrder)
    {
      BreadOrder = new Bread(inputOrder);
    }

    public void AddPastry(int inputOrder)
    {
      PastryOrder = new Pastry(inputOrder);
    }

    public void CalculateTotalCost()
    {
      TotalCost = ApplyBreadDiscount() + ApplyPastryDiscount();
    }

    public int ApplyBreadDiscount()
    {
      if (BreadOrder != null)
      {
        if (CountFreeBread() > 0)
        {
          BreadOrder.InputOrder -= (BreadOrder.InputOrder % 2);
          BreadOrder.TotalItemCost = BreadOrder.InputOrder * BreadOrder.CostPerLoaf;
        }
        return BreadOrder.TotalItemCost;
      }
      else
      {
        return 0;
      }
    }

    public int CountFreeBread()
    {
      int breadQuantity = BreadOrder.InputOrder;
      int breadRemainder = breadQuantity % 2;
      return (breadQuantity - breadRemainder) / 2;
    }

    public int ApplyPastryDiscount()
    {
      if (PastryOrder != null)
      {
        int finalPastryTotal = PastryOrder.TotalItemCost;
        int pastryQuantity = PastryOrder.InputOrder;
        int pastryRemainder = pastryQuantity % 3;
        finalPastryTotal = (pastryRemainder) * PastryOrder.CostPerPiece;
        finalPastryTotal += ((pastryQuantity - pastryRemainder) / 3 * 5);
        return finalPastryTotal;
      }
      else
      {
        return 0;
      }
    }

  }
}