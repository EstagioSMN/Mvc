namespace krita.Controllers
{
    public class AuthenticatedController : Controller
    {
        public Session UsuarioLogado { get; set; }

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            base.OnActionExecuting(context);

            UsuarioLogado = HttpContext.GetSession();

            var user = context.HttpContext.Session.Get<string>("Token");
            if (string.IsNullOrEmpty(user))
            {
                context.Result = new RedirectResult("/login");
            }
        }
    }
}
