using System;
using KudoCode.DependencyInjection_v5;

namespace KudoCode.DependencyInjection
{
	internal class Program
	{
		public static void Main(string[] args)
		{
			ToDoTask_v5 x = new ToDoTask_v5();
			var N = x.Do("N");
			var n = x.Do("n");
			var Y = x.Do("Y");
			var y = x.Do("y");
		}
	}
}