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
    public class ReimbursementController : ControllerBase
    {
        private readonly BusinessLayerFacadeClass _blfc;

        public ReimbursementController(BusinessLayerFacadeClass BLFC)
        {
            this._blfc = BLFC;
        }

        //create an reimbursement
        [HttpPost]
        [Route("CreateReimbursement")]
        public IActionResult CreateReimbursement([FromBody] Reimbursement reim)
        {

            _blfc.CreateReimbursement(reim);
            return Created("Successfully Created", "In Database");
        }
        [HttpGet]
        [Route("GetReimbursement")]
        public IActionResult GetReimbursement()
        {
            /*Reimbursement dto = new Reimbursement();
            dto.ReimbursementId = id;*/
            return Ok(_blfc.GetReimbursement());
        }

        [HttpGet]
        [Route("getReimbursementsforUser/{id}")]
        public IActionResult getReimbursementsforUser(int id)
        {
            return Ok(_blfc.getReimbursementsforUser(id));
        }
        [HttpGet]
        [Route("getAllPendingRequest")]
        public IActionResult getAllPendingRequest()
        {
            return Ok(_blfc.getAllPendingRequests());
        }
        [HttpGet]
        [Route("getAllAcceptedRequest")]
        public IActionResult getAllAcceptedRequest()
        {
            return Ok(_blfc.getAllAcceptedRequests());
        }
        [HttpGet]
        [Route("getAllDeclinedRequest")]
        public IActionResult getAllDeclinedRequest()
        {
            return Ok(_blfc.getAllDeclinedRequests());
        }
        [HttpDelete]
        [Route("deleteReimbursement/{id}")]
        public IActionResult DeleteReimbursement(int id)
        {
            _blfc.DeleteReimbursement(id);
            return Ok("Deleted");
        }

        [HttpPut]
        [Route("DeclineReimbursement")]
        public IActionResult DeclineReimbursement(Decline decline)
        {
            _blfc.DeclineReimbursement(decline.ReimbursementId);
            return Ok("Declined");
        }

        [HttpPost]
        [Route("ApporveReimbursement")]
        public IActionResult ApproveReimbursement(AdminDashboardEntity admin)
        {
            _blfc.ApproveReimbursement(admin);
            return Ok("Approved");
        }

        [HttpPut]
        [Route("EditReimbursement")]
        public IActionResult EditReimbursement([FromBody] Reimbursement model)
        {
            _blfc.EditReimbursement(model);
            return Ok("Successfully Edited");
        }
    }
}
