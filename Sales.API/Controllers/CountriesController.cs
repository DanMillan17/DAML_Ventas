﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Sales.API.Data;
using Sales.Shared.Entities;

namespace Sales.API.Controllers
{
    [ApiController]
    [Route("api/countries")]
    public class CountriesController: ControllerBase
    {
        private readonly DataContext _context;

        public CountriesController(DataContext context)
        {
            _context = context;
        }
// Método POST
        [HttpPost]
        public async Task<ActionResult> Post(Country country)
        {
            _context.Countries.Add(country);
            await _context.SaveChangesAsync();
            return Ok(country);
        }
//Método GET
        [HttpGet]
        public async Task<IActionResult> GetAsync()
        {
            return Ok(await _context.Countries.ToListAsync());
        }
    }
}
