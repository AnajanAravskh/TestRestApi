using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DAL.Context;
using DAL.Entities;
using DAL.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace RestService.Controllers
{
    [Route("api/[controller]")]
    //[ApiController]
    public class ResourcesController : ControllerBase
    {
        ResourcesRepository repo;
        public ResourcesController(ResourcesRepository repo)
        {
            this.repo = repo;
        }
        // GET api/values
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/Resources/5
        [HttpGet("{id}")]
        [ETagFilter(200)]
        public async Task<ActionResult<Resource>> Get(int id)
        {
            var res = await repo.GetByID(id);
            if (res == null)
            {
                return NotFound();
            }
            return res;
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
