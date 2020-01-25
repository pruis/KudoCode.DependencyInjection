using System;
using System.Collections.Generic;
using Autofac;
using Autofac.Core;

namespace KudoCode.DependencyInjection
{

	public class ToDoTask_v4
	{
		public static IContainer Container { get; set; }

		public ToDoTask_v4()
		{
			var builder = new ContainerBuilder();
			builder.RegisterType<SelectedN>().Keyed<IStrategy>("N");
			builder.RegisterType<SelectedY>().Keyed<IStrategy>("Y");

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