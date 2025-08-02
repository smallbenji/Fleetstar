using Fleetstar.Auth;
using Fleetstar.Components;
using Fleetstar.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Fleetstar.Controllers
{
    [ApiController]
    [Route("Auth")]
    public class UserController : Controller
    {
        private readonly SignInManager<ApplicationUser> signInManager;
        private readonly UserManager<ApplicationUser> userManager;
        private readonly UserRepository userRepository;

        public UserController(
            SignInManager<ApplicationUser> signInManager,
            UserManager<ApplicationUser> userManager,
            UserRepository userRepository
        )
        {
            this.signInManager = signInManager;
            this.userManager = userManager;
            this.userRepository = userRepository;
        }

        public IActionResult Index()
        {
            if (HttpContext.User.Identity.IsAuthenticated)
                return Redirect("/admin");

            return View();
        }

        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> IndexAsync([FromBody]LoginDto model)
        {
            var result = await signInManager.PasswordSignInAsync(model.username, model.password, isPersistent: true, lockoutOnFailure: false);

            if (!result.Succeeded)
            {
                return Unauthorized("Invalid login.");
            }


            return Ok("Logged in successfully");
        }


        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> Register([FromBody]RegisterDto model)
        {
            var user = new ApplicationUser
            {
                UserName = model.UserName,
                NormalizedUserName = model.UserName.ToUpper(),
                FullName = model.FullName
            };

            var result = await userManager.CreateAsync(user, model.Password);

            if (!result.Succeeded)
                return BadRequest(result.Errors);

            return Ok("User registered successfully.");
        }

        [HttpGet]
        [Route("getall")]
        [Authorize]
        public IActionResult GetAllUsers()
        {
            var users = userRepository.GetAll();

            return Ok(users);
        }

        [HttpGet]
        [Route("currentuser")]
        public IActionResult CurrentUser()
        {
            var user = userManager.GetUserAsync(User);

            user.Result.PasswordHash = null;

            return Ok(user.Result);
        }

        [HttpGet]
        [Route("logout")]
        public async Task<IActionResult> Logout()
        {
            await signInManager.SignOutAsync();

            return Ok("signed out");
        }

        public class LoginDto
        {
            public string username { get; set; }
            public string password { get; set; }
        }

        public class RegisterDto
        {
            public string UserName { get; set; }
            public string FullName { get; set; }
            public string Password { get; set; }
        }
    }
}
