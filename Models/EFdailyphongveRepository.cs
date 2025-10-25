using System.Linq;
namespace dailyphongve.Models
{
    public class EFdailyphongveRepository : IdailyphongveRepository
    {
        private dailyphongveDbContext context;
        public EFdailyphongveRepository(dailyphongveDbContext ctx)
        {
            context = ctx;
        }
        public IQueryable<ve> ves => context.ves;
        public void Createve(ve b)
        {
            context.Add(b);
            context.SaveChanges();
        }
        public void Deleteve(ve b)
        {
            context.Remove(b); context.SaveChanges();
        }
        public void Saveve(ve b)
        {
            context.SaveChanges();
        }
    }
}
    