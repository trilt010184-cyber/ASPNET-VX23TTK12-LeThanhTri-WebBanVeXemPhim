using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace dailyphongve.Models
{
    public class MyCart
    {
        public List<CartLine> Lines { get; set; } = new List<CartLine>();
        public virtual void AddItem(ve Ve, int quantity)
        {
            CartLine line = Lines
            .Where(b => b.ve.veID == Ve.veID)
            .FirstOrDefault(); 
            if (line == null)
            {
                Lines.Add(new CartLine
                {
                    ve = Ve,
                    Quantity = quantity
                });
            }
            else
            {
                line.Quantity += quantity;
            }
        }
        public virtual void RemoveLine(ve ve) =>
        Lines.RemoveAll(l => l.ve.veID == ve.veID);
        public decimal ComputeTotalValue() =>
        Lines.Sum(e => e.ve.Price * e.Quantity);
        public virtual void Clear() => Lines.Clear();
    }
    public class CartLine
    {
        public int CartLineID { get; set; }
        public ve ve { get; set; }
        public int Quantity { get; set; }
    }
}