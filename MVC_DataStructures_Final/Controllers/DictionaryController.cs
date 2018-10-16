//This Dictionary controller has all the dictionary  methods that return the corresponding views.
//Created by Chelsia Liu 10/15/18

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_DataStructures_Final.Controllers
{
    public class DictionaryController : Controller
    {
        //Declare dictionary variable
        static Dictionary<string, int> myDictionary = new Dictionary<string, int>();

        //Index method
        public ActionResult Index()
        {
            ViewBag.MyDictionary = myDictionary;
            return View();
        }

        //Add one item to dictionary
        public ActionResult AddOne()
        {
            myDictionary.Add("New Entry " + (myDictionary.Count + 1), (myDictionary.Count + 1));
            return View("Index");
        }

        //Add huge list of items to dictionary
        public ActionResult AddHuge()
        {
            //First clear the dictionary
            myDictionary.Clear();

            ViewBag.MyDictionary = myDictionary;

            //Generate 2,000 items in the dictionary
            for (int i = 0; i < 2000; i++)
            {
                myDictionary.Add("New Entry " + (myDictionary.Count + 1), (myDictionary.Count + 1));
            }

            return View("Index");
        }

        //Display contents of the dictionary
        public ActionResult Display()
        {
            //If there is something in the dictionary, then display the dictionary
            if (myDictionary.Count > 0)
            {
                ViewBag.MyDictionary = myDictionary;
                return View("Index");
            }

            //If not, handle any errors and inform the user
            else
            {
                ViewBag.Display = "Dictionary is empty. Nothing to display";
                return View("Index");
            }
        }

        //Delete item from the dictionary
        public ActionResult Delete()
        {
            //Handle any errors and inform the user
            if (myDictionary.Count == 0)
            {
                ViewBag.Delete = "Dictionary is empty. Nothing to delete";
            }

            else
            {
                myDictionary.Remove("New Entry 1");
            }

            return View("Index");
        }

        //Wipe out the contents of the dictionary
        public ActionResult Clear()
        {
            //First clear the dictionary
            myDictionary.Clear();
            ViewBag.Clear = "The dictionary has been cleared";
            return View("Index");
        }

        //Search the queue for a specific entry and report if it was found and how long it took to search
        public ActionResult Search()
        {
            System.Diagnostics.Stopwatch Stopwatch = new System.Diagnostics.Stopwatch();
            Stopwatch.Start();
            TimeSpan timespan = Stopwatch.Elapsed;

            if (myDictionary.ContainsValue(7))
            {
                Stopwatch.Stop();
                timespan = Stopwatch.Elapsed;
                ViewBag.Search = "The dictionary contains 'New Entry 7'";
            }

            else
            {
                Stopwatch.Stop();
                timespan = Stopwatch.Elapsed;
                ViewBag.Search = "The dictionary does not contain 'New Entry 7'";
            }

            ViewBag.Time = "Elasped search time: " + timespan;
            return View("Index");
        }

        //Return to the home index (Home Page)
        public ActionResult ReturnHome()
        {
            return RedirectToAction("Index", "Home");
        }
    }
}
