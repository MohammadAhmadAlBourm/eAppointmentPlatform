using API.Extensions;
using Application.Authentication.Commands.Login;
using Application.Authentication.Commands.Register;
using Application.Authentication.Queries.GetProfile;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[Route("api/auth")]
[ApiController]
public class AuthenticationController : ControllerBase
{
    private readonly ISender _sender;

    public AuthenticationController(ISender sender)
    {
        _sender = sender;
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login(LoginCommand request, CancellationToken cancellationToken)
    {
        var response = await _sender.Send(request, cancellationToken);
        return response.IsSuccess ? Ok(response.Value) : BadRequest(response.ToProblemDetails());
    }

    [HttpPost("profile")]
    public async Task<IActionResult> Profile(CancellationToken cancellationToken)
    {
        var response = await _sender.Send(new GetProfileQuery(), cancellationToken);
        return response.IsSuccess ? Ok(response.Value) : BadRequest(response.ToProblemDetails());
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register(RegisterCommand request, CancellationToken cancellationToken)
    {
        var response = await _sender.Send(request, cancellationToken);
        return response.IsSuccess ? Ok(response.Value) : BadRequest(response.ToProblemDetails());
    }
}