using Backend_WebProject_API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
        private const string pathLogin = "Auth/Login";
        private const string pathRegister = "Auth/Register";
        private List<ApplicationUserModel> usersList = new List<ApplicationUserModel>();
        private List<String> usersUUIDList = new List<String>();

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [Route(pathLogin)]
        public ActionResult Login([FromBody] LoginModel model)
        {


            anscriptUsernameAndPassword(model);

            try {
                var fnj = Int64.Parse(i);
                return Ok("gamovidaasajhdasjhdakjdh: " + i);
               
            }
            catch (Exception ex)
            {
                return BadRequest("can not parce to int");
            }
        }

        [HttpPost]
        [Route(pathRegister)]
        public ActionResult Register([FromBody] ApplicationUserModel model)
        {
            
            if (Helper.IsValidEmail(model.Email) && model.FullName!=null && model.Password!=null && model.UserName!=null)
            {
                usersList.Add(model);
                anscriptUsernameAndPassword(new LoginModel(){
                    UserName = model.UserName,
                    Password = model.Password

                });



                // set Cookie

                CookieOptions option = new CookieOptions();
                
                option.Expires = DateTime.Now.AddMinutes(15);

                Response.Cookies.Append(" df ", "edeed", option);



                return Ok();
            }
            else
            {
                return BadRequest("Unsuccessful Registration, Try again");
            }
        }



        private string anscriptUsernameAndPassword(LoginModel UsernameAndPassword)
        {
            const string salt = "ewufbydiwyuabdwnbdjgaedbjaqpoweqweuru3orhsdsduwerhndfsnncxz558023434509348090312dsjioflasxxkjawdjwed28939ri2t5y75therw8029340223u44";
           
                char[] characters = (UsernameAndPassword.Password+ UsernameAndPassword.Password+ salt).ToArray();
                List<char> newcharacters = new List<char>();
                Array.Sort(characters);

            for (int i =0; i<128;i++)
            {
                newcharacters.Add(characters[i]);
            }


                return new string(newcharacters.ToArray());
         
        }



    }
}
