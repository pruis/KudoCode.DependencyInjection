using System;
using System.Collections.Generic;

namespace KudoCode.DependencyInjection
{
	public interface IStrategy
	{
		string Do(string key);
	}

	public class SelectedN : IStrategy
	{
		public string Do(string key)
		{
			var message = "You selected N";
			return key.Equals(key.ToUpper())
				? message.ToUpper()
				: message.ToLower();
		}
	}

	public class SelectedY : IStrategy
	{
		public string Do(string key)
		{
			var message = "You selected Y";
			return key.Equals(key.ToUpper())
				? message.ToUpper()
				: message.ToLower();
		}
	}

	public class ToDoTask_v3
	{
		public static  Dictionary<string, IStrategy> Container { get; set; }

		public ToDoTask_v3()
		{
			Container = new Dictionary<string, IStrategy>();
			Container.Add("N", new SelectedN());
			Container.Add("N", new SelectedY());
		}

		public string Do(string key)
		{
			IStrategy strategy = null;
			Container.TryGetValue(key.ToUpper(), out strategy);
			return strategy != null
				? strategy.Do(key)
				: "Incorrect Selection";
		}
	}
}