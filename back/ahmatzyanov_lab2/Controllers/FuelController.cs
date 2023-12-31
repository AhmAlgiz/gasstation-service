﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ahmatzyanov_lab2.Services;
using ahmatzyanov_lab2.Models;
using Microsoft.AspNetCore.Authorization;

namespace ahmatzyanov_lab2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FuelController : Controller
    {
        FuelService fuelService = new FuelService();

        [HttpGet]
        public IEnumerable<Fuel> Get()
        {
            return fuelService.getFuels();
        }

        [HttpGet("{id}")]
        public Fuel Get(int id)
        {
            return fuelService.getFuelById(id);
        }

        [HttpGet("withGasStation/{id}")]
        public IEnumerable<Fuel> GetWithGasStation(int id)
        {
            return fuelService.getWithGasStation(id);
        }
        [HttpGet("withGasStationBranded/{id}")]
        public IEnumerable<object> GetWithGasStationBranded(int id)
        {
            return fuelService.getWithGasStationBranded(id);
        }

        [HttpPost("auth/post/")]
        [Authorize(Roles = "0")]
        public void Post(Fuel fuel)
        {
            fuelService.postFuel(fuel);
        }

        [HttpPut("auth/edit/{id}")]
        [Authorize(Roles = "0")]
        public void Put(int id, Fuel fuel)
        {
            fuelService.putFuel(id, fuel);
        }

        [HttpDelete("auth/delete/{id}")]
        [Authorize(Roles = "0")]
        public void Delete(int id)
        {
            Console.WriteLine("delete " + id);
            fuelService.deleteFuel(id);
        }
    }
}
