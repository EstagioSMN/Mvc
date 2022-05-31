namespace krita.Controllers
{
    [Route("login")]
    public class LoginController : Controller
    {
        private IEmailHandler _emailHandler;
        public LoginController(IEmailHandler emailHandler)
        {
            _emailHandler = emailHandler;
        }

        [HttpGet]
        public IActionResult Login()
        {
            var session = HttpContext.Session.Get<string>("Token");
            if (session != null)
                return RedirectToAction("Index", "Home");
                
            return View();
        } 
        
        [HttpPost("SenhaTrocada")]
        public async Task<IActionResult> SenhaTrocada(SenhaTrocadaDto senhaTrocadaDto)
        {
            ApiServices client = new ApiServices("usuario/trocar-senha");
            HttpResponseMessage response = await client.Client.PostAsJsonAsync(client.Url, senhaTrocadaDto);

            if (response.IsSuccessStatusCode)
            {
                client.Close();
                return RedirectToAction("Login", "Login");
            }
            else
            {
                return BadRequest(response.Content.ReadAsStringAsync().Result);
            }
        }
    }
}
