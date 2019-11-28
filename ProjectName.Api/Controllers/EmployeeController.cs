﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ProjectName.Api.Application.Behaviors;
using ProjectName.Infrastructure.Database;
using System.Threading.Tasks;

namespace ProjectName.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IRepositoryGeneric<ProfileContext, Employee> _employee;
        private readonly ILogger<EmployeeController> _logger;

        public EmployeeController(IRepositoryGeneric<ProfileContext, Employee> employee, ILogger<EmployeeController> logger)
        {
            _employee = employee;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _employee.GetAllAsync());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(await _employee.GetOneAsync(id));
        }

        [HttpPost]
        [ProfileUnitOfWork]
        public void Post([FromBody] Employee value)
        {
            _employee.Insert(value);
        }

        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Employee value)
        {
            value.Id = id;
            _employee.Update(value);
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _employee.Delete(id);
        }
    }
}