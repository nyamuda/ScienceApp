using Microsoft.EntityFrameworkCore;
using ScienceApp.Data;
using ScienceApp.Models;

namespace ScienceApp.Services
{
    public class CurriculumService
    {
        private readonly ScienceAppContext _context;



        public CurriculumService(ScienceAppContext context)
        {
            _context = context;
        }



        public async Task<Curriculum?> GetCurriculum(int id)
        {
            //it must include the subjects
            var curriculum = await _context.Curriculum.Include(c => c.Subjects).FirstOrDefaultAsync(c => c.Id == id);

            return curriculum;
        }

        public async Task<List<Curriculum>> GetCurricula()
        {
            //they must include the subjects
            var curricula = await _context.Curriculum.Include(c => c.Subjects).ToListAsync();

            return curricula;
        }

        public async Task<Boolean> UpdateCurriculum(int id, Curriculum curriculum)
        {
            var itemExists = await _context.Curriculum.FindAsync(id);

            if (itemExists == null)
            {
                return false;
            }

            try
            {
                itemExists.Name = curriculum.Name;

                await _context.SaveChangesAsync();

                return true;

            }
            catch (DbUpdateConcurrencyException ex)
            {
                throw;
            }
        }

        public async Task PostCurriculum(Curriculum curriculum)
        {

            _context.Curriculum.Add(curriculum);

            await _context.SaveChangesAsync();

        }

        public async Task<Boolean> DeleteCurriculum(int id)
        {
            var itemExists = await _context.Curriculum.FindAsync(id);

            if (itemExists == null)
            {
                return false;
            }

            _context.Curriculum.Remove(itemExists);
            await _context.SaveChangesAsync();
            return true;

        }
    }
}
