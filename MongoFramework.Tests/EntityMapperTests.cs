﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MongoFramework.Infrastructure;
using MongoFramework.Tests.Models;
using System.Linq;
using MongoFramework.Infrastructure.Mapping;

namespace MongoFramework.Tests
{
	[TestClass]
	public class DbEntityMapperTests
	{
		[TestMethod]
		public void DefaultCollectionName()
		{
			var mapper = new EntityMapper<CommonEntity>();
			Assert.AreEqual("CommonEntity", mapper.GetCollectionName());
		}

		[TestMethod]
		public void AttributeCollectionName()
		{
			var mapper = new EntityMapper<AttributeEntity>();
			Assert.AreEqual("MySchema.MyCustomCollection", mapper.GetCollectionName());
		}

		[TestMethod]
		public void IdMapsOnName()
		{
			var mapper = new EntityMapper<CommonEntity>();
			Assert.AreEqual("_id", mapper.GetIdName());
		}

		[TestMethod]
		public void IdMapsOnAttribute()
		{
			var mapper = new EntityMapper<AttributeEntity>();
			Assert.AreEqual("MyCustomId", mapper.GetIdName());
		}

		[TestMethod]
		public void PropertyUnmaps()
		{
			var mapper = new EntityMapper<AttributeEntity>();
			var mappedProperties = mapper.GetEntityMapping();
			Assert.IsFalse(mappedProperties.Any(p => p.ElementName == "MyUnmappedField"));
		}

		[TestMethod]
		public void AccessToInheritedProperty()
		{
			var mapper = new EntityMapper<ExtendedEntity>();
			var mappedProperties = mapper.GetEntityMapping();
			Assert.IsTrue(mappedProperties.Any(p => p.ElementName == "_id"));
		}

		[TestMethod]
		public void AccessToDeclaredProperty()
		{
			var mapper = new EntityMapper<ExtendedEntity>();
			var mappedProperties = mapper.GetEntityMapping();
			Assert.IsTrue(mappedProperties.Any(p => p.ElementName == "IsDisabled"));
		}
	}
}