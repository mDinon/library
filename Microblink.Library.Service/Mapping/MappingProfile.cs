using AutoMapper;
using Microblink.Library.Model.Entities;
using Microblink.Library.Service.Dtos;

namespace Microblink.Library.Service.Mapping
{
	public class MappingProfile : Profile
	{
		public MappingProfile()
		{
			CreateMap<UserDto, User>();
		}
	}
}
