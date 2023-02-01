using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")] // url => ../api/NameOFDerivedController

    public class BaseApiController : ControllerBase
    {
        
    }
}