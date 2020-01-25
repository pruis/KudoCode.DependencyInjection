using System;
using System.Collections.Generic;
using Autofac;
using Autofac.Core;
using KudoCode.DependencyInjection;

namespace KudoCode.DependencyInjection_v5
{
	public class SwapCase
	{
		public string Swap(string key, string message)
		{
			return key.Equals(key.ToUpper())
				? message.ToUpper()
				: message.ToLower();
		}
	}

	public class SelectedN : IStrategy
	{
		private readonly SwapCase _swapCase;

		public SelectedN(SwapCase swapCase)
		{
			_swapCase = swapCase;
		}

		public string Do(string key)
		{
			var message = "You selected N";
			return _swapCase.Swap(key, message);
		}
	}

	public class SelectedY : IStrategy
	{
		private readonly SwapCase _swapCase;

		public SelectedY(SwapCase swapCase)
		{
			_swapCase = swapCase;
		}

		public string Do(string key)
		{
			var message = "You selected Y";
			return _swapCase.Swap(key, message);
		}
	}

	public class ToDoTask_v5
	{
		public static IContainer Container { get; set; }

		public ToDoTask_v5()
		{
			var builder = new ContainerBuilder();
			builder.RegisterType<SelectedN>().Keyed<IStrategy>("N");
			builder.RegisterType<SelectedY>().Keyed<IStrategy>("Y");
			builder.RegisterType<SwapCase>();

			Container = builder.Build();
		}


		public string Do(string key)
		{
			using (var scope = Container.BeginLifetimeScope())
			{
				var strategy = Container.ResolveKeyed<IStrategy>(key.ToUpper());
				return strategy != null
					? strategy.Do(key)
					: "Incorrect Selection";
			}
		}
	}
}