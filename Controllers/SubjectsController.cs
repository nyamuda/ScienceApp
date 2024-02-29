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
    public class SubjectsController : ControllerBase
    {
        private readonly ScienceAppContext _context;

        private readonly SubjectService _subjectService;

        public SubjectsController(ScienceAppContext context, SubjectService subjectService)
        {
            _context = context;

            _subjectService = subjectService;
        }

        // GET: api/Subjects
        [HttpGet]
        public async Task<IActionResult> GetSubjects()
        {
            IEnumerable<Subject> subjects = await _subjectService.GetSubjects();

            return Ok(subjects);
        }

        // GET: api/Subjects/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetSubject(int id)
        {
            var subject = await _subjectService.GetSubject(id);

            if (subject == null)
            {
                return NotFound();
            }

            return Ok(subject);
        }

        // PUT: api/Subjects/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSubject(int id, SubjectUpdateDto subject)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            bool isSuccess = await _subjectService.UpdateSubject(id, subject);

            if (!isSuccess)
            {
                return NotFound();
            }

            return NoContent();
        }

        // POST: api/Subjects
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<IActionResult> PostSubject(SubjectDto subjectDto)

        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            //check if the curriculum exists
            var curriculum = await _context.Curriculum.FindAsync(subjectDto.CurriculumId);
            //if the curriculum does not exist return a bad request
            if (curriculum == null)
            {
                string errorMessage = "The curriculum with the given ID does not exist";
                return BadRequest(errorMessage);
            }
            int curriculumId = subjectDto.CurriculumId;
            Subject subject = new Subject()
            {
                Name = subjectDto.Name,

            };
            await _subjectService.createSubject(subject, curriculumId);

            return CreatedAtAction("GetSubject", new { id = subject.Id }, subject);
        }

        // DELETE: api/Subjects/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSubject(int id)
        {
            bool isSuccess = await _subjectService.DeleteSubject(id);
            if (!isSuccess)
            {
                return NotFound();
            }



            return NoContent();
        }


    }
}
