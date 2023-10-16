using System.Security.Claims;
using AuthService.Communicators;
using AuthService.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;

namespace AuthService.Controllers;
[ApiController]
[Route("/auth")]
public class AuthController : ControllerBase
{
   private VTBCommunicator _vtbCommunicator;
   public AuthController(VTBCommunicator communicator)
   {
      _vtbCommunicator = communicator;
   }

   [HttpPost]
   [Route("login")]
   public async Task<IActionResult> OnLogin([FromBody] LoginModel model)
   {
      HttpContext.Response.WriteAsJsonAsync( await _vtbCommunicator.GetAuthUrl());
      return Ok();
   }
}