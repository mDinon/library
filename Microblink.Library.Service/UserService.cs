using AutoMapper;
using Microblink.Library.DAL.Context;
using Microblink.Library.Model.Entities;
using Microblink.Library.Service.Dtos;
using Microblink.Library.Service.Enums;
using Microblink.Library.Service.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Microblink.Library.Service
{
	public class UserService : ServiceBase, IUserService
	{
		#region Constructor

		public UserService(LibraryContext context, IMapper mapper) : base(context, mapper)
		{
		}

		public async Task<UserDto?> CreateUser(UserDto userDto)
		{
			User user = mapper.Map<User>(userDto);

			await libraryContext.AddAsync(user);
			await libraryContext.SaveChangesAsync();

			return await GetUser(user.Id.GetValueOrDefault());
		}

		public async Task DeleteUser(int id)
		{
			User? user = await libraryContext.Users.SingleOrDefaultAsync(x => x.Id == id);

			if (user is null)
			{
				throw new ItemNotFoundException($"User with id {id} does not exist!");
			}

			user.IsDeleted = true;
			user.DateModified = DateTime.Now;

			await libraryContext.SaveChangesAsync();
		}

		public async Task<UserDto?> GetUser(int id)
		{
			return await libraryContext.Users
				.TagWith("GetUser")
				.Where(x => x.Id == id)
				.AsNoTracking()
				.Select(x => new UserDto()
				{
					Id = x.Id,
					DateOfBirth = x.DateOfBirth,
					FirstName = x.FirstName,
					LastName = x.LastName,
					UserContacts = x.UserContacts.Select(uc => new UserContactDto()
					{
						Id = uc.Id,
						ContactTypeId = (ContactTypeEnum)uc.ContactTypeId,
						UserId = uc.UserId,
						Value = uc.Value,
						ContactTypeName = uc.ContactType.Name
					})
				}).SingleOrDefaultAsync();
		}

		public async Task<IList<UserDto>> GetUsers()
		{
			return await libraryContext.Users
				.TagWith("GetUsers")
				.AsNoTracking()
				.Select(x => new UserDto()
				{
					Id = x.Id,
					DateOfBirth = x.DateOfBirth,
					FirstName = x.FirstName,
					LastName = x.LastName,
					UserContacts = x.UserContacts.Select(uc => new UserContactDto()
					{
						Id = uc.Id,
						ContactTypeId = (ContactTypeEnum)uc.ContactTypeId,
						UserId = uc.UserId,
						Value = uc.Value,
						ContactTypeName = uc.ContactType.Name
					})
				}).ToListAsync();
		}

		public async Task UpdateUser(UserDto userDto)
		{
			User? user = await libraryContext
				.Users
				.Include(x => x.UserContacts)
				.SingleOrDefaultAsync(x => x.Id == userDto.Id);

			if (user is null)
			{
				throw new ItemNotFoundException($"User with id {userDto.Id} does not exist!");
			}

			user.DateOfBirth = userDto.DateOfBirth;
			user.FirstName = userDto.FirstName;
			user.LastName = userDto.LastName;
			user.DateModified = DateTime.Now;

			foreach (UserContact userContact in user.UserContacts)
			{
				if (!userDto.UserContacts.Any(x => x.Id == userContact.Id))
				{
					userContact.IsDeleted = true;
					userContact.DateModified = DateTime.Now;
				}
			}

			foreach (UserContactDto userContactDto in userDto.UserContacts)
			{
				if (userContactDto.Id > 0)
				{
					UserContact? userContact = user.UserContacts.SingleOrDefault(x => x.Id == userContactDto.Id);

					if (userContact is not null)
					{
						userContact.Value = userContactDto.Value;
						userContact.DateModified = DateTime.Now;
					}
				}
				else
				{
					user.UserContacts.Add(new()
					{
						ContactTypeId = (int)userContactDto.ContactTypeId,
						UserId = userContactDto.UserId,
						Value = userContactDto.Value
					});
				}
			}

			await libraryContext.SaveChangesAsync();
		}

		#endregion
	}
}
