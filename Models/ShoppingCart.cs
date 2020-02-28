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
      if (PastryOrder == null)
      {
        TotalCost = BreadOrder.TotalItemCost;
      }
      else if (BreadOrder == null)
      {
        TotalCost = ApplyPastryDiscount();
      }
      else
      {
        TotalCost = BreadOrder.TotalItemCost + ApplyPastryDiscount();
      }
    }

    public int CountFreeBread()
    {
      int freeBread = 0;
      int breadQuantity = BreadOrder.InputOrder;
      int breadRemainder = breadQuantity % 2;
      if (BreadOrder != null)
      {
        freeBread = (breadQuantity - breadRemainder) / 2;
        return freeBread;
      }
      else
      {
        return freeBread;
      }
    }

    public int ApplyPastryDiscount()
    {
      int finalPastryTotal = PastryOrder.TotalItemCost;
      int pastryQuantity = PastryOrder.InputOrder;
      int pastryRemainder = pastryQuantity % 3;
      if (PastryOrder != null)
      {
        finalPastryTotal = (pastryRemainder) * PastryOrder.CostPerPiece;
        finalPastryTotal += ((pastryQuantity - pastryRemainder) / 3 * 5);
        return finalPastryTotal;
      }
      else
      {
        return finalPastryTotal;
      }
    }

  }
}