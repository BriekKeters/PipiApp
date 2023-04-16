using System;
using MediatR;

namespace PipiApp.Api.RequestHandlers
{
	public abstract class QueryBase<T>:IRequest<T>
	{
		public QueryBase()
		{
		}
	}
}

