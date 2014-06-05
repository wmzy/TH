using Mvc.Mailer;

namespace TH.WebUI.Mailers
{ 
    public interface IUserMailer
    {
			MvcMailMessage Welcome();
            MvcMailMessage PasswordReset(string userId, string userName, string email, string token);
	}
}