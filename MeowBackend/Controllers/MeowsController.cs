using Microsoft.AspNetCore.Mvc;

namespace MeowBackend.Controllers;


[ApiController]
[Route("pypypy")]

public class MeowsController : Controller
{ 

    public MeowsController()
    {

    }

    [HttpGet]
    public int[] GetCount()
    {
        return [5, 66];
    }

   
}
