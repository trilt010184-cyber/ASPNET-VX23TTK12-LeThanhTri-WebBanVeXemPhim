using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace dailyphongve.Models
{
    public class EFOrderRepository : IOrderRepository
    {
        private dailyphongveDbContext context;
        public EFOrderRepository(dailyphongveDbContext ctx)
        {
            context = ctx;
        }
        public IQueryable<Order> Orders => context.Orders
        .Include(o => o.Lines)
        .ThenInclude(l => l.ve);
        public void SaveOrder(Order order)
        {
            context.AttachRange(order.Lines.Select(l => l.ve));
            if (order.OrderID == 0)
            {
                context.Orders.Add(order);
            }
            context.SaveChanges();
        }
    }
}