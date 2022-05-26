namespace Shared.Interfaces
{
	public interface IEmailHandler
	{
	   Task EnviarEmail(EmailParametro emailParametros, Object replaces);
	}
}
