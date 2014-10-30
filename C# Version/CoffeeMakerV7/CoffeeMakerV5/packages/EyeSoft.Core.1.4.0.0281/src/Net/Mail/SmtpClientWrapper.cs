namespace EyeSoft.Net.Mail
{
	using System.Net;
	using System.Net.Mail;

	public class SmtpClientWrapper
		: ISmtpClient
	{
		private readonly SmtpClient smtpClient = new SmtpClient();

		public SmtpDeliveryMethod DeliveryMethod
		{
			get
			{
				return smtpClient.DeliveryMethod;
			}
			set
			{
				smtpClient.DeliveryMethod = value;
			}
		}

		public int Timeout
		{
			get
			{
				return smtpClient.Timeout;
			}
			set
			{
				smtpClient.Timeout = value;
			}
		}

		public ICredentialsByHost Credentials
		{
			get
			{
				return smtpClient.Credentials;
			}
			set
			{
				smtpClient.Credentials = value;
			}
		}

		public void Send(MailMessage mailMessage)
		{
			smtpClient.Send(mailMessage);
		}

		public void Dispose()
		{
			smtpClient.Dispose();
		}
	}
}