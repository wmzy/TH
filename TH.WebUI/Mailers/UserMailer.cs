using System.Security.Policy;
using Mvc.Mailer;

namespace TH.WebUI.Mailers
{ 
    public class UserMailer : MailerBase, IUserMailer 	
	{
		public UserMailer()
		{
			MasterName="_Layout";
		}
		
		public virtual MvcMailMessage Welcome()
		{
			//ViewBag.Data = someObject;
			return Populate(x =>
			{
				x.Subject = "Welcome";
				x.ViewName = "Welcome";
				x.To.Add("some-email@example.com");
			});
		}
 
		public virtual MvcMailMessage PasswordReset(string userId, string userName, string email, string token)
		{
		    ViewData["Title"] = "��������";
            ViewData["userName"] = userName;
		    ViewData["token"] = token;
		    ViewData["userId"] = userId;
            
			return Populate(x =>
			{
                x.Subject = "���·����Ϣ��-�һ������ʻ�����";
				x.ViewName = "PasswordReset";
                x.To.Add(email);
			});
		}
 	}
}