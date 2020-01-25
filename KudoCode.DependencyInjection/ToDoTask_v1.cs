namespace KudoCode.DependencyInjection
{
	public class ToDoTask_v1
	{
		public string Do(string key)
		{
			if (key.Equals("N"))
				return "You selected N";
			if (key.Equals("Y"))
				return "You selected Y";

			return "Incorrect Selection";
		}
	}
}