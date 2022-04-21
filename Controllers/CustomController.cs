using CustomAuthApi.Models;
using CustomAuthApi.Repository;
using Dapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CustomAuthApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomController : ControllerBase
    {
        private readonly ICallSPRepository _callSPRepository;
        public CustomController(ICallSPRepository callSPRepository)
        {
            _callSPRepository = callSPRepository;
        }
        [HttpGet]
        public IActionResult InsertUser(AppUser request)
        {           
            //request.Name = "test";
            //request.Email = "test@gmail.com";
            //request.RoleId = 1;
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@Name", request.Name);
            parameters.Add("@Email", request.Email);
            parameters.Add("@RoleId", request.RoleId);
            _callSPRepository.Execute("CreateUser", parameters);
            return Ok(request);
        }
        [HttpPost("AuthenticateUser")]
        public IActionResult AuthenticateUser(DTO request)
        {           
            //request.Name = "test";
            //request.Email = "test@gmail.com";         
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@Name", request.Name);
            parameters.Add("@Email", request.Email);        
           var data= _callSPRepository.Single<string>("CheckUser", parameters);
            return Ok(new { role = data });
        }
    }
}
