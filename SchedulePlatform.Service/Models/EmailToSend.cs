using System;
namespace SchedulePlatform.Service.Models
{
	public class EmailToSend
	{
		public string? To { get; set; }
		public string? Subject { get; set; }
		public string? Body { get; set; }
	}
}

