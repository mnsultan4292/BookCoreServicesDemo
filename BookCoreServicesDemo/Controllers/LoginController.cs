using BookCoreServicesDemo.AppSettings;
using BookCoreServicesDemo.Helper;
using BookCoreServicesDemo.Models;
using BookCoreServicesDemo.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace BookCoreServicesDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly IUserRegistrationRepository _userReg;
        private readonly IConfiguration _config;
        private readonly JwtHelper _jwtHelper;
        private readonly SettingDemo _settingDemo;
        private readonly ILogger<LoginController> _logger;
        public LoginController(SettingDemo settingDemo, IConfiguration config,IUserRegistrationRepository userRegistrationRepository, JwtHelper jwtHelper, ILogger<LoginController> logger)

        {
            _config = config;
            _userReg = userRegistrationRepository;
            _jwtHelper = jwtHelper;
            _settingDemo = settingDemo;
            _logger = logger;
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Login([FromBody] UserLogin userLogin)
        {
            
            //string str = _settingDemo.M1();
            //string str1 = _settingDemo.Setting;

            
            var user =await Authenticate(userLogin);
            if (user != null)
            {
                var token = _jwtHelper.GenerateToken(user);
                return Ok(token);
            }

            return NotFound("user not found");
        }

       

        //To authenticate user
        private async Task<UserRegistration> Authenticate(UserLogin userLogin)
        {
            var currentUser = await _userReg.GetUserDetails();
            if (currentUser != null)
            {
               var data= currentUser.FirstOrDefault(x => x.Username.ToLower() ==
                    userLogin.Username.ToLower() && x.Password == userLogin.Password);
                if (data != null)
                {
                    return data;
                }                
            }
            return null;
        }

    }
}
