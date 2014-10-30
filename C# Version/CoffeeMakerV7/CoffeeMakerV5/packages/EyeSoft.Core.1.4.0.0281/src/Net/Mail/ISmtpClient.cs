namespace EyeSoft.Net.Mail
{
	using System;
	using System.Net;
	using System.Net.Mail;

	public interface ISmtpClient
		: IDisposable
	{
		SmtpDeliveryMethod DeliveryMethod { get; set; }

		int Timeout { get; set; }

		ICredentialsByHost Credentials { get; set; }

		void Send(MailMessage mailMessage);
	}
}