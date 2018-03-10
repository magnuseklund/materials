using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using CQRSlite.Commands;
using MaterialsDomain.Api.Commands;
using MaterialsDomain.Api.Data;
using MaterialsDomain.Api.Models;
using MaterialsDomain.Api.ReadModels;
using Microsoft.AspNetCore.Mvc;
using StackExchange.Redis;

namespace MaterialsDomain.Api.Controllers
{
    [Route("api/[controller]")]
    public class ProjectController : Controller
    {
        private readonly ICommandSender _commandSender;
        private readonly IProjectRepository _projectRepository;
        
        public ProjectController(ICommandSender commandSender, IProjectRepository projectRepository)
        {
            _commandSender = commandSender;
            _projectRepository = projectRepository;
        }

        [HttpPost]
        public async Task<ActionResult> Create([FromBody]string name, CancellationToken cancellationToken)
        {
            await _commandSender.Send(new CreateProject(Guid.NewGuid(), name));

            return Ok();
        }

        [HttpGet]
        public async Task<ProjectListViewModel> Get()
        {
            return await _projectRepository.GetProjectListAsync();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
