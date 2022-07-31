﻿using System.Runtime.Serialization;

namespace Microblink.Library.Service.Exceptions
{
	[Serializable]
	public class ItemNotFoundException : Exception
	{
		public ItemNotFoundException()
		{
		}

		public ItemNotFoundException(string message)
			: base(message)
		{
		}

		public ItemNotFoundException(string message, Exception inner)
			: base(message, inner)
		{
		}

		protected ItemNotFoundException(SerializationInfo info, StreamingContext context)
			: base(info, context)
		{
		}
	}
}
