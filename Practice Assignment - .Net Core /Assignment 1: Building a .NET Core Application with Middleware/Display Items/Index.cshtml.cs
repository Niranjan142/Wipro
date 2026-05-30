using Microsoft.AspNetCore.Mvc.RazorPages;

public class IndexModel : PageModel
{
    public List<string> Items { get; set; }

    public void OnGet()
    {
        Items = ItemRepository.Items;
    }
}
