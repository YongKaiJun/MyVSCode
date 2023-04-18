using Microsoft.AspNetCore.Mvc;

namespace Lesson01.Controllers;

public class PetHotelController : Controller
{
    // To hold the injected dependency
    private readonly IDbService _dbSvc;

    // dbSvc created and injected by ASP.NET Core
    public PetHotelController(IDbService dbSvc)
    {
        _dbSvc = dbSvc;
    }

    public IActionResult Index()
    {
        List<Booking> model = 
            _dbSvc.GetList<Booking>("SELECT * FROM Booking");
        return View(model);
    }

    public IActionResult AddBooking()
    {
        var petTypes = _dbSvc.GetList("SELECT Id, PetDesc FROM PetType ORDER BY PetDesc");

        // TODO L01 TASK 5b: Prepare a SelectList for to assign to ViewData["PetTypes"]
        // ViewData["__________"] = new __________(petTypes, "Id", "PetDesc");

        return View();
    }





    // TODO L01 TASK 5d: Implement AddBooking HttpPost action to insert new booking record.
    //                   Must use ModelState.IsValid to ensure valid input are entered and
    //                   redirect to input with proper messages.
    //                   Refer to worksheet for messages to be used for different scenarios.
    [HttpPost]
    public IActionResult AddBooking(Booking newBook)
    {













        return RedirectToAction("Index");
        
    }

    public IActionResult ViewBookingsByPetTypes()
    {
        ViewData["PetTypes"] = _dbSvc.GetList("SELECT * FROM PetType ORDER BY Id");
        List<Booking> model = _dbSvc.GetList<Booking>("SELECT * FROM Booking");
        return View(model);
    }

    public IActionResult ViewBookingsByMonths()
    {
        List<Booking> model = _dbSvc.GetList<Booking>("SELECT * FROM Booking");
        return View(model);
    }
}

