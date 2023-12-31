﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebAPI_Final.Entities;
using WebAPI_Final.IServices;
using WebAPI_Final.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebAPI_Final.Controllers
{
    [Route("api/[controller]")]
    public class PropertyController : Controller
    {
        private readonly IPropertiesServices propertiesServices;

        public PropertyController()
        {
            propertiesServices = new PropertiesServices();
        }

        // GET: api/values
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public IActionResult AddProperty(int id,[FromBody] Properties property)
        {      
            return Ok(propertiesServices.AddProperties(id, property));
        }

        // PUT api/values/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody]string value)
        //{
        //}

        // DELETE api/values/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}

