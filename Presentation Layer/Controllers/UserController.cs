using Business_Layer.Business_Layer_Facade_Class;
using Data_Access_Layer.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Presentation_Layer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly BusinessLayerFacadeClass _blfc;

        public UserController(BusinessLayerFacadeClass BLFC)
        {
            this._blfc = BLFC;
        }

        //create user
        [HttpPost]
        /*[Route("CreateUser")]*/
        public IActionResult CreateUser(User user)
        {
            System.Console.WriteLine("Useristhe"+user);
            _blfc.CreateUser(user);
            return Created("Created", "In database");
        }

        // get employee by id
        [HttpGet]
        public IActionResult GetAnUser(int userId)
        {
            return Ok(_blfc.GetAnUser(userId));
        }
    }
}
