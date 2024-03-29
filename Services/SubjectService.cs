﻿using Microsoft.EntityFrameworkCore;
using ScienceApp.Data;
using ScienceApp.Dtos;
using ScienceApp.Models;

namespace ScienceApp.Services
{
    public class SubjectService
    {
        private readonly ScienceAppContext _context;


        public SubjectService(ScienceAppContext context)
        {
            _context = context;
        }



        public async Task createSubject(Subject subject, int curriculumId)
        {
            //check if the curriculum exists
            var curriculum = await _context.Curriculum.FindAsync(curriculumId);
            if (curriculum == null) { return; }

            subject.Curriculums.Add(curriculum);

            _context.Subject.Add(subject);

            await _context.SaveChangesAsync();
        }

        public async Task<Subject?> GetSubject(int id)
        {
            var subject = await _context.Subject.Include(s => s.Curriculums).FirstOrDefaultAsync(s => s.Id == id);

            return subject;
        }

        public async Task<List<Subject>> GetSubjects()
        {
            //get subjects with their curriculum
            var subjects = await _context.Subject.Include(s => s.Curriculums).ToListAsync();

            return subjects;
        }

        public async Task<Boolean> UpdateSubject(int id, SubjectUpdateDto subject)
        {
            var itemExists = await _context.Subject.FindAsync(id);

            if (itemExists == null)
            {
                return false;
            }

            try
            {
                itemExists.Name = subject.Name;


                await _context.SaveChangesAsync();
                return false;

            }
            catch (DbUpdateConcurrencyException ex)
            {
                throw;
            }
        }


        public async Task<Boolean> DeleteSubject(int id)
        {
            var itemExists = await _context.Subject.FindAsync(id);

            if (itemExists == null)
            {
                return false;
            }

            _context.Subject.Remove(itemExists);

            await _context.SaveChangesAsync();

            return true;
        }
    }
}
