using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography;

namespace Lesson01.Controllers;

public class LearnController : Controller
{
    private readonly IDbService _dbSvc;

    public LearnController(IDbService dbSvc)
    {
        _dbSvc = dbSvc;
    }

    #region Functional Programming Examples


    delegate string Greeting(string greet, string name);

    private string Hello(string greet, string name)
    {
        return $"{greet} {name}";
    }

    public IActionResult SayHi(string id, string country)
    {
        // The variable welcome references the method Hello
        Greeting welcome = Hello;

        var greet = country.ToLower() switch
        {
            "hawaii" => "Aloha",
            "china" => "NiHaoMa",
            "korea" => "AnnYeongHaSeYo",
            _ => "hello"
        };

        return Json(welcome(greet, id));
    }

    public IActionResult SayGood(string id)
    {
        var greet1 = (String x) => "Good Morning " + x;
        var greet2 = (String x) => "Good Afternoon " + x;
        var greet3 = (String x) => "Good Evening " + x;

        var good = (String x) => DateTime.Now.Hour < 12 ? greet1(x) :
                                 DateTime.Now.Hour < 18 ? greet2(x) :
                                 greet3(x);
        return Json(good($"{id}"));
    }

    public IActionResult GenericDelegates()
    {
        Action<string, string> func1 = (x, y) => Debug.Print(x + y);
        func1("Mr ", "Cha");

        Func<string, string, int> func2 = (a, b) => a.Length + b.Length;
        Debug.Print(func2("apple", "orange").ToString());

        Predicate<int> func3 = (i) => i % 2 == 0;
        for (int x = 0; x < 10; x++)
            if (func3(x))
                Debug.Print(x + " is even");
            else
                Debug.Print(x + " is odd");
        return Json("See the output in the Debug Window");
    }

    public ActionResult Squares()
    {
        int[] myList = { 1, 2, 3, 4, 5, 6, };
        var squares = myList
            .Where(x => x * x > 15)
            .Select(x => $"Square of {x} is {x * x}")
            .ToList();
        return Json(squares);

    }

    delegate string BinaryStringOp(string s1, string s2);

    public ActionResult StringOp(string op, string a, string b)
    {
        BinaryStringOp myFunc = null!;
        if (op.ToLower() == "c")
        {
            // Concatenate
            myFunc = (s1, s2) => s1 + s2;
        }
        else if (op.ToLower() == "r")
        {
            // Replace
            myFunc = (s1, s2) => s1.Replace(s2, "");
        }

        string result = myFunc?.Invoke(a, b) ?? "No such operation!";
       
        return Json(result);
    }

    public ActionResult StringOp2(string op, string a, string b)
    {
        BinaryStringOp myFunc = null!;
        if (op.ToLower() == "c")
        {
            myFunc = (s1, s2) => s1 + s2;
        }
        else if (op.ToLower() == "r")
        {
            myFunc = (s1, s2) => s1.Replace(s2, "");
        }

        string result = "No such operation!";
        if (myFunc != null)
        {
            result = myFunc(a, b);
        }

        return Json(result);
    }

    #endregion

    #region Functional Programming Exercises

    // TODO L01 TASK 1: Create a delegate that takes in TWO double parameters and return ONE double value
    delegate double BinaryDoubleOp(double p1, double p2);

    public string Evaluate(string op, double x, double y)
    {
        // TODO L01 TASK 2: Implement the Evaluate action to perform the 4 basic arithmetic operation based on op:
        //                      When op is sum, perform p1 + p2
        //                      When op is dif, perform p1 - p2
        //                      When op is prd, perform p1 * p2
        //                      When op is div, perform p1 / p2 

        //Model Answer:
        op = op.ToLower();
        BinaryDoubleOp? myFunc = op switch
        {
            "sum" => (p1, p2) => p1 + p2,
            "dif" => (p1, p2) => p1 - p2,
            "prd" => (p1, p2) => p1 * p2,
            "div" => (p1, p2) => p1 / p2,
            _ => null
        };

        if (myFunc != null)
        {
            double result = myFunc(x, y);
            return result.ToString();
        }
        else
        {
            return "No such Operation";
        }

    }

    #endregion

    #region LINQ Exercises

    private List<SalesOrder> GetSalesOrders()
    {
        return _dbSvc.GetList<SalesOrder>("SELECT * FROM SalesOrder");
    }

    public ActionResult FilterByPrice(double id)
    {
        ViewBag.Title = $"All orders with PRICE > {id}";
        List<SalesOrder> orders = GetSalesOrders();

        // TODO L01 TASK 4a: Filter orders list by PRICE greater than id
        List<SalesOrder> model = orders;





        return View("Display", model);
    }

    public ActionResult SortedByPrice()
    {
        ViewBag.Title = $"Sort all orders by PRICE (ASC)";
        List<SalesOrder> orders = GetSalesOrders();

        // TODO L01 TASK 4b: Sort orders list by PRICE (ASC)
        List<SalesOrder> model = orders;





        return View("Display", model);
    }

    public ActionResult FilterednSorted(double id)
    {
        ViewBag.Title = $"All orders with PRICE > {id} sorted by PRICE (ASC) & ProductId (DESC)";
        List<SalesOrder> orders = GetSalesOrders();

        // TODO L01 TASK 4c: Filter orders list by PRICE > id and Sort orders
        //                   by price (ASC) and ProductId (DESC)
        List<SalesOrder> model = orders;




        return View("Display", model);
    }

    #endregion

}

