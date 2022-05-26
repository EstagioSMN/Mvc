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

        [HttpPost]
        public async Task<IActionResult> LoginPost(LoginViewModel loginView)
        {
            ApiServices client = new ApiServices("usuario/login");
            HttpResponseMessage response = await client.Client.PostAsJsonAsync(client.Url, loginView);

            if (response.IsSuccessStatusCode)
            {
                var token = await response.DeserializeObject<LoginDto>();
                HttpContext.Session.Set<string>("Token", token.Token);
                Session session = HttpContext.GetSession();
                client.Close();
                return RedirectToAction("Index", "Home");
            }
            
            ViewBag.Erro = await response?.Content.ReadAsStringAsync();
            return View("Login", loginView);  
        }

        [HttpGet("esqueci-senha")]
        public IActionResult EsqueciSenha([FromQuery] string email)
        {
            var secureQuery = new SecureQueryString(email);
            var emailDescriptografado = secureQuery["emailSitemauriciojunior.net"];
            return View("EsqueciSenha", emailDescriptografado);
        }

        [HttpGet("Enviar")]
        public async Task<IActionResult> Enviar(string email)
        {
            var criptografandoEmail = new SecureQueryString();
            criptografandoEmail["emailSitemauriciojunior.net"] = email;

            ApiServices client = new ApiServices($"usuario/verificarEmail?Email={email}");
            HttpResponseMessage response = await client.Client.GetAsync(client.Url);
            if(response.IsSuccessStatusCode){
                var resposta = await response?.Content.ReadAsStringAsync();
                await _emailHandler.EnviarEmail(new EmailParametro
                {
                    CaminhoHTML = "Templates/MensagemEmail.html",
                    EmailDestino = email,
                    NomeRemetente = "Krita SMN",
                    AssuntoEmail = "Confirmação necessária"
                }, new
                {
                    Usuario = JsonConvert.DeserializeObject<Usuario>(resposta).Apelido,
                    Link = $"http://localhost:5141/login/esqueci-senha?Email={criptografandoEmail.ToString()}"
                });
            }
            return RedirectToAction("Index", "Login");
        }

        [HttpPost("NovaSenha")]
        public async Task<IActionResult> NovaSenha(NovaSenhaViewModel novaSenhaViewModel)
        {
            if (novaSenhaViewModel.SenhaNova != novaSenhaViewModel.SenhaNovaRepetida)
                return RedirectToAction("Index", "Login");
            
            NovaSenhaDto novaSenhaDto = new NovaSenhaDto()
            {
                Email = novaSenhaViewModel.Email,
                Senha = novaSenhaViewModel.SenhaNova
            };

            ApiServices client = new ApiServices($"usuario/esqueci-senha");
            HttpResponseMessage response = await client.Client.PostAsJsonAsync(client.Url, novaSenhaDto);
            return RedirectToAction("Index", "Login");
        }

        [HttpGet("logout")]
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Login", "Login");
        }  

        [HttpPost("SenhaTrocada")]
        public async Task<IActionResult> SenhaTrocada (SenhaTrocadaDto senhaTrocadaDto)
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
