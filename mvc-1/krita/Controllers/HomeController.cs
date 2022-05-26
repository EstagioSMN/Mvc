namespace krita.Controllers;

public class HomeController : AuthenticatedController
{
	private readonly ILogger<HomeController> _logger;
	private IEmailHandler _emailHandler;

	public HomeController(ILogger<HomeController> logger, IEmailHandler emailHandler)
	{
		_logger = logger;
		_emailHandler = emailHandler;
	}

    public async Task<IActionResult> Index()
    {

        ApiServices client = new ApiServices();
        HttpResponseMessage response = await client.Client.GetAsync(client.Url);
        TempData["Apelido"] = UsuarioLogado.Apelido;
        TempData["Email"] = UsuarioLogado.Email;
        return View();
    }
}
