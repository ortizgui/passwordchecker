using Microsoft.AspNetCore.Mvc;
using PasswordValidation.Core.Dtos;
using PasswordValidation.Core.Interfaces;
using PasswordValidation.Core.Services;

namespace PasswordValidation.Core.Controllers
{
    [ApiController]
    [Route("/api/[controller]")]
    public class PasswordController : ControllerBase
    {
        private readonly IPasswordService _passwordService;

        public PasswordController(IPasswordService passwordService)
        {
            this._passwordService = passwordService;
        }

        [HttpPost("isValid")]
        public IActionResult PasswordIsValid(AddPasswordDto inputtedPassword)
        {
            GetPasswordDto response = _passwordService.PasswordIsValid(inputtedPassword);
            if(response.IsValid == false)
            {
                return BadRequest(response);
            }
            return Ok(response);
        }

    }
}