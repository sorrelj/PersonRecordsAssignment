using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Project_Assignment.Data;
using Project_Assignment.Models;

namespace Project_Assignment.Controllers
{
    public class PersonController : Controller
    {

        // Database context
        public readonly PersonRecordsContext _context;


        // set person records context
        public PersonController(PersonRecordsContext context)
        {
            _context = context;
        }

        // index (home) page
        public async Task<IActionResult> Index()
        {
            // return view with list of person records
            return View(await _context.Person.ToListAsync());
        }


        // GET person (EDIT)
        // the edit button is clicked
        public async Task<IActionResult> Edit(int? id)
        {
            // check for null id value
            if (id == null)
            {
                // return 400
                return BadRequest();
            }

            // get person object from id
            var person = await _context.Person.FirstOrDefaultAsync(p => p.Id == id);

            // check if person does not exist
            if (person == null)
            {
                // return 404
                return NotFound();
            }

            // return view with person object
            return View(person);
        }

        // POST person (EDIT)
        // submit button on Edit Page
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,FirstName,LastName,AddressOne,AddressTwo,City,State,Country,Phone,Email")] Person person)
        {
            // check that id matches id in person object
            if (id != person.Id)
            {
                // return 404
                return NoContent();
            }

            // check if the changes are valid
            if (ModelState.IsValid)
            {
                try
                {
                    // update person in the records context and save changes
                    _context.Update(person);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    // check if person exists
                    if (_context.Person.Any(p => p.Id == person.Id))
                    {
                        return NotFound();
                    }
                    throw;
                }
                return RedirectToAction("Index");
            }

            // if not valid do not update
            return View(person);
        }

        // Get Add Person
        public IActionResult Add()
        {
            // Go to add person page
            return View();
        }

        // POST Add Person
        // submit button on Add Page
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Add([Bind("Id,FirstName,LastName,AddressOne,AddressTwo,City,State,Country,Phone,Email")] Person person)
        {
            // check valid record entry
            if (ModelState.IsValid)
            {
                // add person to record context
                _context.Add(person);
                await _context.SaveChangesAsync();

                // redirect to home page on success
                return RedirectToAction("Index");
            }

            // do not add if invalid
            return View(person);
        }

        // POST Delete Person
        // delete button action
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            // get person modelItem from id
            var person = await _context.Person.SingleOrDefaultAsync(p => p.Id == id);

            // remove person from records context
            _context.Person.Remove(person);

            // save changes and redirect to home page
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

    }





}
