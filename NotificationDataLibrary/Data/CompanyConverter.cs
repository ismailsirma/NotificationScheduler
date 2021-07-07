using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using NotificationDataLibrary.Models;
using NotificationDataLibrary.Models.Companies;

namespace NotificationDataLibrary.Data
{
	public class CompanyConverter : JsonConverter
	{
		public override bool CanRead { get { return true; } }

		public override bool CanWrite { get { return true; } }

		public override bool CanConvert(Type objectType)
		{
			return objectType == typeof(Company);
		}

		public override bool Equals(object obj)
		{
			return this.Equals(obj);
		}

		public override int GetHashCode()
		{
			return this.GetHashCode();
		}

		public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
		{
			JObject jo = JObject.Load(reader);
			if (jo["Market"].Value<Int64>() == 0)
			{
				return jo.ToObject<DenmarkCompany>(serializer);
			}
			if (jo["Market"].Value<Int64>() == 1)
			{
				return jo.ToObject<NorwayCompany>(serializer);
			}
			if (jo["Market"].Value<Int64>() == 2)
			{
				return jo.ToObject<SwedenCompany>(serializer);
			}
			if (jo["Market"].Value<Int64>() == 3)
			{
				return jo.ToObject<FinlandCompany>(serializer);
			}
			return null;
		}

		public override string ToString()
		{
			return this.ToString();
		}

		public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
		{
			serializer.Serialize(writer, value);
		}


	}
}
