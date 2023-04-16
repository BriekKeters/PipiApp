using System;
using MediatR;

namespace PipiApp.Api.RequestHandlers
{
	public class CommandBase<T>:IRequest<T>
	{
		public CommandBase()
		{
		}
	}
}

