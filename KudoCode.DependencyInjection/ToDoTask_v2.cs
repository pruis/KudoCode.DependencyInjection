namespace KudoCode.DependencyInjection
{
	public class ToDoTask_v2
	{
		public string Do(string key)
		{
			if (key.Equals("Y"))
			{
				var message = "You selected Y";
				return key.Equals(key.ToUpper())
					? message.ToUpper()
					: message.ToLower();
			}

			else if (key.Equals("N"))
			{
				var message = "You selected N";
				return key.Equals(key.ToUpper())
					? message.ToUpper()
					: message.ToLower();
			}

			else if (key.Equals("1"))
			{
				var message = "You selected 1";
				return key.Equals(key.ToUpper())
					? message.ToUpper()
					: message.ToLower();
			}

			return "Incorrect Selection";
		}
	}
}