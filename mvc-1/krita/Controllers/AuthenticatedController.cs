namespace krita.Controllers
{
    public class AuthenticatedController : Controller
    {
        public Session UsuarioLogado { get; set; }

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            base.OnActionExecuting(context);

            UsuarioLogado = HttpContext.GetSession();
            TempData["Apelido"] = UsuarioLogado.Apelido;
            TempData["Email"] = UsuarioLogado.Email;

            var user = context.HttpContext.Session.Get<string>("Token");
            if (string.IsNullOrEmpty(user))
            {
                context.Result = new RedirectResult("/login");
            }
        }
    }
}
