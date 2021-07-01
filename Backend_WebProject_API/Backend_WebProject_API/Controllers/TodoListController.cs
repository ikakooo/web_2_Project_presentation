using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Backend_WebProject_API.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Backend_WebProject_API.Controllers
{
    public class TodoListController : Controller
    {
        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }



        [HttpPost]
        [Route("AddTodoTask")]
        public ActionResult AddTodoTask([FromBody] TodoItemModel todoItemModel)
        {
           
            if (Helper.isUserLoggedIn(HttpContext.Request.Cookies["session-id"])){

                todoItemModel.UUID = HttpContext.Request.Cookies["session-id"];

                Helper.addToDoTaskInList(todoItemModel);

                return Ok();
            }
            else
            {
                return Unauthorized("User is not loggged");
            }


        }


        [HttpGet]
        [Route("getAllTodoTasks")]
        public ActionResult Get()
        {
            if (Helper.isUserLoggedIn(HttpContext.Request.Cookies["session-id"]))
            {
                return Ok(Helper.getAllToDoTaskInList(HttpContext.Request.Cookies["session-id"]).ToArray());
            }
            else
            {
                return Unauthorized("User is not loggged");
            }
        }

    }
}
