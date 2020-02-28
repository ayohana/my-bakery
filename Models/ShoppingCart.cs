using System;
using System.Collections.Generic;

namespace Bakery.Models
{
  public class ShoppingCart
  {
    public Bread BreadOrder { get; set; }
    public Pastry PastryOrder { get; set; }

    public ShoppingCart(int breadInputOrder, int pastryInputOrder)
    {
      BreadOrder = new Bread(breadInputOrder);
      PastryOrder = new Pastry(pastryInputOrder);
    }
  }
}