using Backend_WebProject_API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Net.Http.Headers;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Backend_WebProject_API.Controllers


{
    public class AuthController : Controller
    {
        private readonly ILogger<AuthController> _logger;

        public AuthController(ILogger<AuthController> logger)
        {
            _logger = logger;
        }


        private const string pathLogin = "Auth/Login";
        private const string pathRegister = "Auth/Register";
        

        public IActionResult Index()
        {
            return View();
        }


        /// <summary>
        /// მომხმარებლის ავტორიზაცია
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>

        [HttpPost]
        [Route(pathLogin)]
        public ActionResult Login([FromBody] LoginModel model)
        {


            if (Helper.isUserLoggedIn(Helper.anscriptUsernameAndPassword(model)))
            {
                // set Cookie

                CookieOptions option = new CookieOptions();

                option.Expires = DateTime.Now.AddMinutes(15);

                Response.Cookies.Append("session-id", Helper.anscriptUsernameAndPassword(model), option);




                return Ok("Autorithed: " + model);
            }
            else
            {
                return Unauthorized("User is not loggged");
            }

           
        }




        /// <summary>
        /// მომხმარებლის რეგისტრაცია
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        [Route(pathRegister)]
        public ActionResult Register([FromBody] ApplicationUserModel model)
        {
            
            if (Helper.IsValidEmail(model.Email) && model.FullName!=null && model.Password!=null && model.UserName!=null)
            {

                Helper.registerUserIn(model);
               
        



                // set Cookie

                CookieOptions option = new CookieOptions();

                option.Expires = DateTime.Now.AddMinutes(15);

                Response.Cookies.Append("session-id", Helper.anscriptUsernameAndPassword(new LoginModel()
                {
                    UserName = model.UserName,
                    Password = model.Password

                }), option);

               // _logger.LogInformation(usersUUIDList.ToString());

                return Ok("Register Successfully");
            }
            else
            {
                return BadRequest("Unsuccessful Registration, Try again");
            }
        }








        



    }
}
