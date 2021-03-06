﻿using MongoFramework.Infrastructure.Linq.Processors;
using System.Linq;

namespace MongoFramework.Infrastructure.Linq
{
	public interface IMongoFrameworkQueryable : IOrderedQueryable
	{
		string ToQuery();
	}

	public interface IMongoFrameworkQueryable<TEntity, TOutput> : IMongoFrameworkQueryable, IOrderedQueryable<TOutput>
	{
		EntityProcessorCollection<TEntity> EntityProcessors { get; }
	}
}
