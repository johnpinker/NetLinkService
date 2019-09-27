using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using linkservicenet.Models;
using linkservicenet.Services;

namespace linkservicenet.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class LinksController : ControllerBase {

            private readonly ILinkService _linkService;
            private readonly ILoggerService _loggerService;
            public LinksController(ILinkService linkService, ILoggerService loggerService)
            {
                _linkService = linkService;
                _loggerService = loggerService;
            }

            [HttpGet]
            public ActionResult<List<Link>> Get() => _linkService.Get();

            [HttpGet("{id}")]
            public ActionResult<Link> Get(string id) => _linkService.Get(id);

            [HttpPost]
            public ActionResult<Link> Post([FromForm] string name, [FromForm] string href) 
            {
                if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(href))
                    return BadRequest();
                Link tmpLink = new Link(name, href);
                tmpLink =_linkService.Create(tmpLink);
                return tmpLink;
            }

            [HttpPut("{id}")]
            public ActionResult<Link> Put(string id, [FromForm] string name, [FromForm] string href)
            {
                if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(href) || string.IsNullOrEmpty(id))
                    return BadRequest();
                Link tmpLink = new Link() {name=name, href=href};
                tmpLink.Id = id;
                _linkService.Update(id, tmpLink);
                return tmpLink;
            }

            [HttpDelete("{id}")]
            public ActionResult<string> Delete(string id) 
            {
                if (string.IsNullOrEmpty(id))
                    return BadRequest();
                _linkService.Remove(id);
                return "Success";
            }
    }
}