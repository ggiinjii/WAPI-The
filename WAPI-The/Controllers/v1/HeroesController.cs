using System;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Wapi_the_Core.DTO;
using Wapi_the_Services.Services;

namespace WAPI_The.Controllers.v1
{
    [ApiVersion("1.0")]
    [Route("api/v1/[controller]")]
    [ApiController]
    public class HeroesController : Controller
    {
        private readonly HeroService _heroService;

        public HeroesController(IMapper mapper)
        {
            _heroService = new HeroService(mapper);
        }

        // GET: Heroes
        [HttpGet]
        [ResponseCache(VaryByHeader = "User-Agent", Duration = 30)]
        public ActionResult getHeroes()
        {
            return Ok(_heroService.getHeroes());
        }

        [HttpGet("{id}")]
        [ResponseCache(VaryByHeader = "User-Agent", Duration = 30)]
        // GET: Heroes/Details/5
        public ActionResult Details(int id)
        {
            return Ok(_heroService.getHeroId(id));
        }

        // POST: Heroes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        public IActionResult Create([Bind("Id,Name,HeroAlter")] HeroDto hero)
        {
            return Ok(_heroService.Create(hero));
        }

        // POST: Heroes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPut("{id}")]
        public IActionResult Edit(int id, [Bind("Id,Name,HeroAlter")] HeroDto hero)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _heroService.Edit(id, hero);
                }
                catch (Exception e)
                {
                    throw e;
                }
                return Ok();
            }
            return View(hero);
        }

        // POST: Heroes/Delete/5
        [HttpDelete("{id}")]
        public IActionResult DeleteConfirmed(int id)
        {
            try
            {
                _heroService.Delete(id);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
            return Ok();
        }
    }
}
