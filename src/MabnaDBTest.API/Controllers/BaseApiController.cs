using MabnaDBTest.Domain.DTOs;

using MediatR;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MabnaDBTest.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public abstract class BaseApiController : ControllerBase
{
    private IMediator _mediator;      
    protected IMediator Mediator => _mediator ??= HttpContext.RequestServices.GetService<IMediator>();


    public IActionResult OkReult<T>(CustomResponseDto<T> response)
    {
        return new ObjectResult(response.StatusCode == 204 ? null : response)
        {
            StatusCode = response.StatusCode
        };
    }
}
