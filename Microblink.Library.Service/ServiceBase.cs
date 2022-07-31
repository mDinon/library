using AutoMapper;
using Microblink.Library.DAL.Context;

namespace Microblink.Library.Service
{
	public abstract class ServiceBase
	{
		#region Fields

		public readonly LibraryContext libraryContext;
		public readonly IMapper mapper;

		#endregion

		#region Constructor

		protected ServiceBase(LibraryContext libraryContext, IMapper mapper)
		{
			this.libraryContext = libraryContext;
			this.mapper = mapper;
		}

		#endregion
	}
}
