namespace EyeSoft.Logging
{
	using System.Net.Mail;

	public class EmailLogger : ILogger
	{
		private readonly string[] destinataries;

		private readonly string subject;

		public EmailLogger(string[] destinataries, string subject)
		{
			this.destinataries = destinataries;
			this.subject = subject;
		}

		public void Write(string message)
		{
			using (var client = new SmtpClient())
			{
				var mailMessage =
					new MailMessage
						{
							Subject = subject,
							Body = message
						};

				foreach (var to in destinataries)
				{
					mailMessage.To.Add(to);
				}

				client.Send(mailMessage);
			}
		}
	}
}