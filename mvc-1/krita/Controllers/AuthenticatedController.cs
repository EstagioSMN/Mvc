namespace krita.Controllers
{
    public class AuthenticatedController : Controller
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            base.OnActionExecuting(context);
            {
                context.Result = new RedirectResult("/login");
            }
        }
    }
}
