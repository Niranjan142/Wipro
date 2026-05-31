public class BooksController : Controller
{
    private readonly BookRepository _repo;

    public BooksController(BookRepository repo)
    {
        _repo = repo;
    }

    public IActionResult Index()
    {
        return View(_repo.GetBooks());
    }

    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Create(Book book)
    {
        _repo.AddBook(book);
        return RedirectToAction("Index");
    }
}
