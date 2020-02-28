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
    
  }
}