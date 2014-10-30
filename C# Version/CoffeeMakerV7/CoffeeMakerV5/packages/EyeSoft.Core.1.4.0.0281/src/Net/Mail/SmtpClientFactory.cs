namespace EyeSoft.Net.Mail
{
	public class SmtpClientFactory
	{
		public virtual ISmtpClient Create()
		{
			return new SmtpClientWrapper();
		}
	}
}