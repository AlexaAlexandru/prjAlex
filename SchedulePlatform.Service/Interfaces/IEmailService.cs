using System;
using SchedulePlatform.Service.Models;

namespace SchedulePlatform.Service.Interfaces
{
	public interface IEmailService
	{
		void SendEmail(EmailToSend request);
	}
}

