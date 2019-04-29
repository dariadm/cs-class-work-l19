using System;
using Reminder.Domain;
using Reminder.Receiver.Telegram;
using Reminder.Sender.Telegram;
using Reminder.Storage.InMemory;


namespace Reminder.App
{
	class Program
	{
		static void Main(string[] args)
		{
			const string token = "893127484:AAFkdqr_oR7LMSxJC9a70Fzh-GUwqT9V5pY";
			//const string token = "633428988:AAHLW_LaS7A47PDO2l8sbLkllM9L0joPOSQ";

			var receiver = new TelegramReminderReceiver(token);
			var sender = new TelegramReminderSender(token);
			var storage = new InMemoryReminderStorage();

			var domain = new ReminderDomain(storage, receiver, sender);
			domain.AddingSucceded += Domain_AddingSucceded;
			domain.SendingSucceded += Domain_SendingSucceded;
			domain.SendingFailed += Domain_SendingFailed;

			Console.ReadKey();

			//receiver.GetHelloFromBot();
		}

		private static void Domain_SendingFailed(object sender, Domain.EventArgs.SendingFailedEventArgs e)
		{
			Console.WriteLine("Sending Failed");
		}

		private static void Domain_SendingSucceded(object sender, Domain.EventArgs.SendingSuccededEventArgs e)
		{
			Console.WriteLine("Sending succeded");
		}

		private static void Domain_AddingSucceded(object sender, Domain.EventArgs.AddingSuccededEventArgs e)
		{
			Console.WriteLine("Adding succeded");
		}
	}
}
