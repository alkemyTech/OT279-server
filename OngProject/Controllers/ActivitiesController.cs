using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OngProject.Core.Interfaces;

namespace OngProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ActivitiesController : ControllerBase
    {
        private IActivitiesService _activitesService;
        public ActivitiesController(IActivitiesService activitesService)
        {
            _activitesService = activitesService;
        }
    }
}
