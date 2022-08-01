using Microblink.Library.Service.Dtos;

namespace Microblink.Library.Service.Interfaces
{
	public interface IUserService
	{
		public Task<IList<UserDto>> GetUsers();
		public Task<UserDto?> GetUser(int id);
		public Task<UserDto?> CreateUser(UserDto userDto);
		public Task UpdateUser(UserDto userDto);
		public Task DeleteUser(int id);
	}
}
