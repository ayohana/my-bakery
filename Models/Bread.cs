using System;
using System.Collections.Generic;

namespace Bakery.Models
{
  public class Bread
  {
    public int InputOrder { get; set; }
    public int CostPerLoaf { get; set; }
    public int TotalItemCost { get; set; }

    public Bread(int inputOrder)
    {
      InputOrder = inputOrder;
      CostPerLoaf = 5;
      TotalItemCost = InputOrder * CostPerLoaf;
    }
  }
}