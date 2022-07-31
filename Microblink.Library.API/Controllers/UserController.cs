using AutoMapper;
using Microblink.Library.Service.Dtos;
using Microblink.Library.Service.Interfaces;
using Microsoft.AspNetCore.Http;
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
		/// <returns>A 200 Ok response containing informations.</returns>
		/// <response code="200">Ok.</response>
		[HttpGet]
		[ProducesResponseType(StatusCodes.Status200OK)]
		public async Task<IActionResult> Get()
		{
			logger.LogInformation("Getting users.");

			IList<UserDto>? users = await userService.GetUsers();

			return Ok();
		}

		#endregion
	}
}
