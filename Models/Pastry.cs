using System;
using System.Collections.Generic;

namespace Bakery.Models
{
  public class Pastry
  {
    public int InputOrder { get; set; }
    public int CostPerPiece { get; set; }
    public int TotalItemCost { get; set; }

    public Pastry(int inputOrder)
    {
      InputOrder = inputOrder;
      CostPerPiece = 2;
      TotalItemCost = InputOrder * CostPerPiece;
    }
  }
}