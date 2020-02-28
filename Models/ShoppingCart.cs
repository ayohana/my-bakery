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
      TotalCost = BreadOrder.TotalItemCost + PastryOrder.TotalItemCost;
    }
  }
}