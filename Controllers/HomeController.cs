using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using burulas.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using burulas.Data.Concrete.EfCore;
using Microsoft.EntityFrameworkCore;
using burulas.Entity;

namespace burulas.Controllers;

public class HomeController : Controller
{
    public BurulasContext _burulasContext;
    public HomeController(BurulasContext burulasContext)
    {
        _burulasContext = burulasContext;
    }

    public IActionResult Index()
    {
        var employee = _burulasContext.Employees.Include(x => x.Schedules).ToList();
        return View(employee);
    }
    public IActionResult Create()
    {
        // ViewBag.Schedules = new SelectList(_burulasContext.Schedules.ToList(), "Day", "Day");
        return View();
    }
    [HttpPost]
    public async Task<IActionResult> Create(Employee employee)
    {
        if (ModelState.IsValid)
        {
            await _burulasContext.Employees.AddAsync(employee);
            await _burulasContext.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        // ViewBag.Schedules = new SelectList(_burulasContext.Schedules.ToList(), "Day","Day");
        return View(employee);
    }

    public IActionResult Edit(int id)
    {
        var emp = _burulasContext.Employees.FirstOrDefault(x => x.Id == id);
        // ViewBag.Schedules = new SelectList(_burulasContext.Schedules.ToList(), "Day", "Day");
        return View(emp);
    }
    [HttpPost]
    public async Task<IActionResult> Edit(Employee employee)
    {

        if (ModelState.IsValid)
        {
            _burulasContext.Employees.Update(employee);
            await _burulasContext.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        // ViewBag.Schedules = new SelectList(_burulasContext.Schedules.ToList(), "Day","Day");
        return View(employee);
    }

    public IActionResult Delete(int id)
    {
        var emp = _burulasContext.Employees.FirstOrDefault(x => x.Id == id);
        // ViewBag.Schedules = new SelectList(_burulasContext.Schedules.ToList(), "Day", "Day");
        return View(emp);
    }
    [HttpPost]
    public async Task<IActionResult> Delete(Employee employee)
    {
        var silinecekkayit = await _burulasContext.Employees.FirstOrDefaultAsync(x => x.Id == employee.Id);
        if (silinecekkayit != null)
        {
            _burulasContext.Employees.Remove(silinecekkayit);
            await _burulasContext.SaveChangesAsync();
            return RedirectToAction("Index");
        }
        // ViewBag.Schedules = new SelectList(_burulasContext.Schedules.ToList(), "Day","Day");
        return View(employee);
    }

    public IActionResult ScIndex()
    {
        List<Schedule> pazartesiSchedules = _burulasContext.Schedules
                                                   .Include(x => x.Employees)
                                                   .Where(x => x.Id == 1)
                                                   .ToList();
        List<Schedule> saliSchedules = _burulasContext.Schedules
                                            .Include(x => x.Employees)
                                            .Where(x => x.Id == 2)
                                            .ToList();
        List<Schedule> carsambaSchedules = _burulasContext.Schedules
                                            .Include(x => x.Employees)
                                            .Where(x => x.Id == 3)
                                            .ToList();
        List<Schedule> persembeSchedules = _burulasContext.Schedules
                                            .Include(x => x.Employees)
                                            .Where(x => x.Id == 4)
                                            .ToList();
        List<Schedule> cumaSchedules = _burulasContext.Schedules
                                            .Include(x => x.Employees)
                                            .Where(x => x.Id == 5)
                                            .ToList();
        List<Schedule> cumartesiSchedules = _burulasContext.Schedules
                                            .Include(x => x.Employees)
                                            .Where(x => x.Id == 6)
                                            .ToList();
        List<Schedule> pazarSchedules = _burulasContext.Schedules
                                            .Include(x => x.Employees)
                                            .Where(x => x.Id == 7)
                                            .ToList();
        ViewBag.Pazartesi = pazartesiSchedules;
        ViewBag.Sali = saliSchedules;
        ViewBag.Carsamba = carsambaSchedules;
        ViewBag.Persembe = persembeSchedules;
        ViewBag.Cuma = cumaSchedules;
        ViewBag.Cumartesi = cumartesiSchedules;
        ViewBag.Pazar = pazarSchedules;


        return View();
    }
    public IActionResult ScEdit()
    {
        ViewBag.Schedules = new SelectList(_burulasContext.Schedules.ToList(), "Id", "Day");
        ViewBag.Employees = new SelectList(_burulasContext.Employees.ToList(), "Id", "FirstName");
        return View();
    }
    [HttpPost]
    public async Task<IActionResult> ScEdit(DayAndEmployeeIds dayAndEmployeeIds)
    {
        var findEmployee = _burulasContext.Employees.FirstOrDefault(x => x.Id == dayAndEmployeeIds.employeId);
        var findSc = _burulasContext.Schedules.Include(sc => sc.Employees).FirstOrDefault(x => x.Id == dayAndEmployeeIds.dayId);

        if (findEmployee != null && findSc != null)
        {
            // Çalışan zaten ilişkilendirilmiş mi kontrol et
            var employeIs = findSc.Employees.FirstOrDefault(x => x.Id == findEmployee.Id);

            if (employeIs == null)
            {
                // Eğer çalışan zaten ilişkilendirilmemişse, ekleyin
                findSc.Employees.Add(findEmployee);
            }

            // Schedule'ı güncelle
            _burulasContext.Schedules.Update(findSc);

            // Veritabanına kaydedin
            await _burulasContext.SaveChangesAsync();

            return RedirectToAction("ScIndex");
        }

        return View();
    }

    public ActionResult ScDelete(int id)
    {
    var silinecekKayit = _burulasContext.Employees.FirstOrDefault(x => x.Id == id);
    return View(silinecekKayit);
    }
    [HttpPost]
    public async Task<ActionResult> ScDelete(int id,Employee employee)
    {
         var degisecekKayit = _burulasContext.Schedules.Include(x => x.Employees).FirstOrDefault(x => x.Id == id);

    if (degisecekKayit != null)
    {
        // Kaydı kaldır
        degisecekKayit.Employees.Remove(employee);
        await _burulasContext.SaveChangesAsync(); // Değişiklikleri veritabanına kaydet
    }
        return RedirectToAction("ScIndex");
    }


    public IActionResult Privacy()
    {
        return View();
    }

}
