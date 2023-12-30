using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PabloStaffApp.Data;
using PabloStaffApp.Models;

namespace PabloStaffApp.Controllers
{
    [Authorize]
    public class EmpController : Controller
    {
        private readonly ApplicationDbContext _context;

        public EmpController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Emp
        public async Task<IActionResult> Index(int? employeeId)
        {
            IQueryable<EmployeeEntity> employees = _context.Employees;

            if (employeeId.HasValue)
            {
                employees = employees.Where(e => e.EmpId == employeeId.Value);
            }

            var employeeList = await employees.ToListAsync();
            return View(employeeList);
        }

        // GET: Emp/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employeeEntity = await _context.Employees
                .FirstOrDefaultAsync(m => m.EmpId == id);

            if (employeeEntity == null)
            {
                return NotFound();
            }

            return View(employeeEntity);
        }

        // GET: Emp/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Emp/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("EmpId,Name,Surname,Department,Phone,Salary,Email")] EmployeeEntity employeeEntity)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _context.Add(employeeEntity);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
            }
            catch (DbUpdateException)
            {
                // Log the exception
                ModelState.AddModelError(string.Empty, "Unable to save changes. Try again, and if the problem persists, see your system administrator.");
            }

            return View(employeeEntity);
        }

        // GET: Emp/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employeeEntity = await _context.Employees.FindAsync(id);

            if (employeeEntity == null)
            {
                return NotFound();
            }

            return View(employeeEntity);
        }

        // POST: Emp/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("EmpId,Name,Surname,Department,Phone,Salary,Email")] EmployeeEntity employeeEntity)
        {
            if (id != employeeEntity.EmpId)
            {
                return NotFound();
            }

            try
            {
                if (ModelState.IsValid)
                {
                    _context.Update(employeeEntity);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    // If ModelState is not valid, return the view with the model
                    return View(employeeEntity);
                }
            }
            catch (DbUpdateConcurrencyException)
            {
                // Log the exception
                ModelState.AddModelError(string.Empty, "Unable to save changes. The record was deleted by another user.");
            }
            catch (DbUpdateException)
            {
                // Log the exception
                ModelState.AddModelError(string.Empty, "Unable to save changes. Try again, and if the problem persists, see your system administrator.");
            }

            // If any exception occurs, return the view with the model
            return View(employeeEntity);
        }

        // GET: Emp/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employeeEntity = await _context.Employees
                .FirstOrDefaultAsync(m => m.EmpId == id);

            if (employeeEntity == null)
            {
                return NotFound();
            }

            return View(employeeEntity);
        }

        // POST: Emp/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var employeeEntity = await _context.Employees.FindAsync(id);

            if (employeeEntity == null)
            {
                return NotFound();
            }

            _context.Employees.Remove(employeeEntity);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        private bool EmployeeEntityExists(int id)
        {
            return _context.Employees.Any(e => e.EmpId == id);
        }
    }
}
