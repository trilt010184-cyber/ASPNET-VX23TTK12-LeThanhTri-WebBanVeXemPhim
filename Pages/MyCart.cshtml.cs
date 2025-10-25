using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using dailyphongve.MyTagHelper;
using dailyphongve.Models;
using System.Linq;
namespace dailyphongve.Pages
{
    public class MyCartModel : PageModel
    {
        private IdailyphongveRepository repository;
        public MyCartModel(IdailyphongveRepository repo, MyCart myCartService)
        {
            repository = repo;
            myCart = myCartService;
        }
        public MyCart myCart { get; set; }
        public string ReturnUrl { get; set; }
        public void OnGet(string returnUrl)
        {
            ReturnUrl = returnUrl ?? "/";
        }
        public IActionResult OnPost(long veId, string returnUrl)
        {
            ve ve = repository.ves
            .FirstOrDefault(b => b.veID == veId);
            myCart.AddItem(ve, 1);
            return RedirectToPage(new { returnUrl = returnUrl });
        }
        public IActionResult OnPostRemove(long veId, string returnUrl)
        {
            myCart.RemoveLine(myCart.Lines.First(cl =>
            cl.ve.veID == veId).ve);
            return RedirectToPage(new { returnUrl = returnUrl });
        }
    }
}