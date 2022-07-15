using Business_Layer.Business_Layer_Facade_Class;
using Data_Access_Layer.Models;
using Data_Access_Layer.RP_DbContext;
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
    public class AuthController : ControllerBase
    {
        private readonly BusinessLayerFacadeClass _blfc;

        public AuthController(BusinessLayerFacadeClass BLFC)
        {
            this._blfc = BLFC;
            
        }
        [HttpPost]
        [Route("Login")]
        public IActionResult Login(User user)
        {
            if (_blfc.Login(user) == true)
            {
                int id = _blfc.GetUserByEmail(user.UserEmail);
                string IsApprover = _blfc.GetIsApproverByEmail(user.UserEmail);
                return Ok(new
                {
                    UserId = id,
                    Approver = IsApprover,
                    status = true
                }
                );
            }
            return BadRequest("Invalid");
        }

        [HttpGet]
        [Route("emailAvailable/{email}")]

        public IActionResult EmailAvailable(string email)
        {
            var user =  _blfc.GetAllUserDetailByEmail(email);
            System.Console.WriteLine(user);
            if (user == null)
            {
                return Ok(new
                {
                    available = true
                });
            }
            else return Ok(new
            {
                available = false
            });
        }
    }
}
