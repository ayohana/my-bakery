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
        TotalCost = PastryOrder.TotalItemCost;
      }
      else
      {
        TotalCost = BreadOrder.TotalItemCost + PastryOrder.TotalItemCost;
      }
    }

    public int CountFreeBread()
    {
      int freeBread = 0;
      int breadQuantity = BreadOrder.InputOrder;
      if (BreadOrder != null)
      {
        if (breadQuantity % 2 == 0)
        {
          freeBread = breadQuantity / 2;
          return freeBread;
        }
        else if (breadQuantity > 2 && breadQuantity % 2 > 0)
        {
          freeBread = (breadQuantity - (breadQuantity % 2)) / 2;
          return freeBread;
        }
        else
        {
          return freeBread;
        }

      }
      else
      {
        return freeBread;
      }
    }

  }
}