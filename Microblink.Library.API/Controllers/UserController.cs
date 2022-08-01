using AutoMapper;
using Microblink.Library.API.ViewModels.User.Request;
using Microblink.Library.API.ViewModels.User.Response;
using Microblink.Library.Service.Dtos;
using Microblink.Library.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Microblink.Library.API.Controllers
{
	/// <summary>
	/// Endpoint for saving user data
	/// </summary>
	[Route("api/[controller]")]
	[ApiController]
	public class UserController : ControllerBase
	{
		#region Fields

		private readonly IMapper mapper;
		private readonly IUserService userService;
		private readonly ILogger<UserController> logger;

		#endregion

		#region Constructor

		/// <summary>
		/// Initializes a new instance of the <see cref="UserController"/> class.
		/// </summary>
		/// <param name="mapper">Injected mapper.</param>
		/// <param name="userService">Injected user service.</param>
		/// <param name="logger">Injected logger.</param>
		public UserController(IMapper mapper, IUserService userService, ILogger<UserController> logger)
		{
			this.mapper = mapper;
			this.userService = userService;
			this.logger = logger;
		}

		#endregion

		#region Get

		/// <summary>
		/// Get users.
		/// </summary>
		/// <returns>A 200 Ok response containing users.</returns>
		/// <response code="200">Ok.</response>
		[HttpGet]
		[ProducesResponseType(StatusCodes.Status200OK)]
		public async Task<IActionResult> Get()
		{
			logger.LogInformation("Getting users.");

			IEnumerable<UserDto> users = await userService.GetUsers();

			return Ok(mapper.Map<IEnumerable<UserResponseVm>>(users));
		}

		/// <summary>
		/// Get user by id.
		/// </summary>
		/// <param name="id">User identifier.</param>
		/// <returns>A 200 Ok response containing user.</returns>
		/// <response code="200">Ok.</response>
		/// <response code="404">Not found.</response>
		[HttpGet("{id:int}")]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		public async Task<IActionResult> Get(int id)
		{
			logger.LogInformation("Getting user id: {Id}.", id);

			UserDto? user = await userService.GetUser(id);

			if (user is null)
			{
				return NotFound("User does not exist.");
			}

			return Ok(mapper.Map<UserResponseVm>(user));
		}

		#endregion

		#region Create

		/// <summary>
		/// Create user.
		/// </summary>
		/// <param name="userCreateRequest"><see cref="UserCreateRequestVm"/> User create request object.</param>
		/// <returns>A 201 Created response.</returns>
		/// <response code="201">Created.</response>
		/// <response code="400">Bad request.</response>
		[HttpPost]
		[ProducesResponseType(StatusCodes.Status201Created)]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
		public async Task<IActionResult> Create(UserCreateRequestVm userCreateRequest)
		{
			logger.LogInformation("Creating user.");

			UserDto user = mapper.Map<UserDto>(userCreateRequest);

			UserDto newUser = await userService.CreateUser(user);

			return CreatedAtAction(nameof(Get), new { id = newUser.Id }, mapper.Map<UserResponseVm>(newUser));
		}

		#endregion

		#region Update

		/// <summary>
		/// Update user.
		/// </summary>
		/// <param name="userUpdateRequest"><see cref="UserUpdateRequestVm"/> User update request object.</param>
		/// <returns>A 204 No content response.</returns>
		/// <response code="204">No content.</response>
		/// <response code="400">Bad request.</response>
		/// <response code="404">Not found.</response>
		[HttpPut]
		[ProducesResponseType(StatusCodes.Status204NoContent)]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		public async Task<IActionResult> Update(UserUpdateRequestVm userUpdateRequest)
		{
			logger.LogInformation("Updating user id: {Id}.", userUpdateRequest.Id);

			UserDto user = mapper.Map<UserDto>(userUpdateRequest);

			await userService.UpdateUser(user);

			return NoContent();
		}

		#endregion

		#region Delete

		/// <summary>
		/// Delete user.
		/// </summary>
		/// <param name="id">User identifier.</param>
		/// <returns>A 204 No content response or 404 not found response if user does not exist.</returns>
		/// <response code="200">OK.</response>
		/// <response code="404">Not found.</response>
		[HttpDelete("{id:int}")]
		[ProducesResponseType(StatusCodes.Status204NoContent)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		public async Task<IActionResult> Delete(int id)
		{
			logger.LogInformation("Pokrenuta deaktivacija natječaja za id: {Id}", id);

			await userService.DeleteUser(id);

			return NoContent();
		}

		#endregion
	}
}
