using AutoMapper;
using Microblink.Library.API.ViewModels.User.Request;
using Microblink.Library.API.ViewModels.User.Response;
using Microblink.Library.Service.Dtos;

namespace Microblink.Library.API.Mapping
{
	/// <summary>
	/// Mapping profile class
	/// </summary>
	public class MappingProfile : Profile
	{
		/// <summary>
		/// Constructor - create maps
		/// </summary>
		public MappingProfile()
		{
			CreateMap<UserDto, UserResponseVm>();
			CreateMap<UserContactDto, UserContactResponseVm>();
			CreateMap<UserCreateRequestVm, UserDto>();
			CreateMap<UserContactCreateRequestVm, UserContactDto>();
			CreateMap<UserUpdateRequestVm, UserDto>();
			CreateMap<UserContactUpdateRequestVm, UserContactDto>();
		}
	}
}
