using Microsoft.AspNetCore.Mvc;

namespace Lesson01.Controllers;

public class SingRoomController : Controller
{
    private readonly IDbService _dbSvc;

    public SingRoomController(IDbService dbSvc)
    {
        _dbSvc = dbSvc;
    }

    // GET: SingRoom
    public IActionResult Index()
    {
        List<SRBooking> model = _dbSvc.GetList<SRBooking>("SELECT * FROM SRBooking");
        return View(model);
    }

    public IActionResult CreateBooking()
    {

        // TODO L01 TASK 3c: Prepare 2 SelectList objects for to assign to
        //                   ViewData["PackageTypes"] and ViewData["Slots"].
        //                   Refer to 6P pdf on how to do it.
        var packageTypes = _dbSvc.GetList("SELECT Id, PkgDesc FROM SRPackageType ORDER BY PkgDesc");
        // ViewData["PackageTypes"] = new __________(__________, "Id", "PkgDesc");

        var slots = _dbSvc.GetList("SELECT Id, SlotDesc FROM SRSlot ORDER BY SlotDesc");
        // ViewData["Slots"] = new __________(__________, "Id", "SlotDesc");

        return View();
    }

    [HttpPost]
    public IActionResult CreateBooking(SRBooking srBook)
    {
        if (ModelState.IsValid)
        {
            var sql = @"INSERT SRBooking(CustName, SlotId, PkgTypeId, 
                                         BookingDate, Duration, AOSnack, AODrink) 
                        VALUES ('{0}', {1}, {2}, '{3:yyyy-MM-dd}', {4}, '{5}', '{6}')";

            if (_dbSvc.ExecSQL(sql, srBook.CustName, srBook.SlotId, srBook.PkgTypeId, 
                               srBook.BookingDate, srBook.Duration, srBook.AOSnack, srBook.AODrink) == 1)
                TempData["Msg"] = "New booking added.";
            else
                TempData["Msg"] = "Failed to create booking.";
        }
        else
        {
            TempData["Msg"] = "Invalid information entered";
        }
        return RedirectToAction("Index");
    }

    public IActionResult ViewBookingsByPackage()
    {
        ViewData["PackageTypes"] = _dbSvc.GetList("SELECT * FROM SRPackageType ORDER BY PkgDesc");
        List<SRBooking> model = _dbSvc.GetList<SRBooking>("SELECT * FROM SRBooking");
        return View(model);
    }
}

