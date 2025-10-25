using System.Linq;
namespace dailyphongve.Models
{
    public interface IdailyphongveRepository
    {
        IQueryable<ve> ves { get; }
        void Saveve(ve b);
        void Createve(ve b);
        void Deleteve(ve b);
    }
}