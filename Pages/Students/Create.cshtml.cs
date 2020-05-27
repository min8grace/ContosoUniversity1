using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ContosoUniversity1.Data;
using ContosoUniversity1.Models;

namespace ContosoUniversity1.Pages.Students
{
    public class CreateModel : PageModel
    {
        private readonly ContosoUniversity1.Data.SchoolContext _context;

        public CreateModel(ContosoUniversity1.Data.SchoolContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Student Student { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            var emptyStudent = new Student();

            if (await TryUpdateModelAsync<Student>(
                emptyStudent,
                "student",   // Prefix for form value.
                s => s.FirstMidName, s => s.LastName, s => s.EnrollmentDate))
            {
                _context.Students.Add(emptyStudent);
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }

            return Page();

            //TryUpdateModelAsync
            //The preceding code creates a Student object and then uses posted form fields to update the Student object's properties. The TryUpdateModelAsync method:

            //Uses the posted form values from the PageContext property in the PageModel.
            //Updates only the properties listed(s => s.FirstMidName, s => s.LastName, s => s.EnrollmentDate).
            //Looks for form fields with a "student" prefix.For example, Student.FirstMidName.It's not case sensitive.
            //Uses the model binding system to convert form values from strings to the types in the Student model.For example, EnrollmentDate has to be converted to DateTime.


            //if (!ModelState.IsValid)
            //{
            //    return Page();
            //}

            //_context.Students.Add(Student);
            //await _context.SaveChangesAsync();

            //return RedirectToPage("./Index");
        }
    }
}
