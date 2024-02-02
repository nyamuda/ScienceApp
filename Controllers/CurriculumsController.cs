using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ScienceApp.Data;
using ScienceApp.Dtos;
using ScienceApp.Models;
using ScienceApp.Services;

namespace ScienceApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CurriculumsController : ControllerBase
    {
        private readonly ScienceAppContext _context;
        private readonly CurriculumService _service;

        public CurriculumsController(ScienceAppContext context, CurriculumService service)
        {
            _context = context;
            _service = service;
        }

        // GET: api/Curriculums
        [HttpGet]
        public async Task<IActionResult> GetCurriculums()
        {
            IEnumerable<Curriculum> curriculums = await _service.GetCurricula();

            return Ok(curriculums);

        }

        // GET: api/Curriculums/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCurriculum(int id)
        {
            var curriculum = await _service.GetCurriculum(id);

            if (curriculum == null)
            {
                return NotFound();
            }

            return Ok(curriculum);
        }

        // PUT: api/Curriculums/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCurriculum(int id, CurriculumDto curriculumDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Curriculum curriculum = new Curriculum()
            {
                Name = curriculumDto.Name

            };
            bool success = await _service.UpdateCurriculum(id, curriculum);

            if (success)
            {
                return NoContent();
            }

            return BadRequest();
        }

        // POST: api/Curriculums
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<IActionResult> PostCurriculum(CurriculumDto curriculumDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Curriculum curriculum = new Curriculum()
            {
                Name = curriculumDto.Name,
            };
            await _service.PostCurriculum(curriculum);

            return CreatedAtAction("GetCurriculum", new { id = curriculum.Id }, curriculum);
        }

        // DELETE: api/Curriculums/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCurriculum(int id)
        {

            bool success = await _service.DeleteCurriculum(id);

            if (success)
            {
                return NoContent();
            }

            return NotFound();
        }


    }
}
