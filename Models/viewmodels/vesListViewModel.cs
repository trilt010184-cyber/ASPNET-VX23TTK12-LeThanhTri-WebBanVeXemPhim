using System.Collections.Generic;
namespace dailyphongve.Models.viewmodels
{
    public class vesListViewModel
    {
        public IEnumerable<ve> ves { get; set; }
        public PagingInfo PagingInfo { get; set; }
        public string CurrentGenre { get; set; }
    }
}