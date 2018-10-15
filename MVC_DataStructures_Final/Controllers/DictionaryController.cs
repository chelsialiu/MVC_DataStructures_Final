//Created by chelsliu on 10/13/18
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_DataStructures_Final.Controllers
{
    public class DictionaryController : Controller
    {
        static Dictionary<string, int> myDictionary = new Dictionary<string, int>();

        // GET: Dictionary
        public ActionResult Index()
        {
            ViewBag.MyDictionary = myDictionary;
            return View();
        }

        //This method adds one entry to the dictionary
        public ActionResult AddOne()
        {
            myDictionary.Add("New Entry " + (myDictionary.Count + 1), (myDictionary.Count + 1));
            return View("Index");
        }

        //This method first clears the data structure and then adds a huge list of 2,000 entries to the dictionary 
        public ActionResult AddHuge()
        {
            ClearDictionary();
            ViewBag.MyDictionary = myDictionary;


            for (int i = 0; i <= 1999; i++)
            {
                AddOne();
            }
            return View("Index");
        }

        //This method will display the dictionary using a foreach loop
        public ActionResult Display()
        {
            ViewBag.MyDictionary = myDictionary;

            //Handle any errors and inform the user

            return View("Index");
        }

        //FIX ME: Delete any item from structure
        public ActionResult Delete()
        {
            ViewBag.MyDictionary = myDictionary;

            string keyToDelete;

            Console.WriteLine("Enter the item you want to delete from the dictionary." +
                " New Entry: ");

            keyToDelete = Console.ReadLine();

            Console.WriteLine("You want to delete " + keyToDelete);

            //FIX ME: Handle any errors and inform the user somewhere on the form 
            //if it cannot delete HINT: Use the ViewBag
            return View();

        }

        //This method will clear the entire dictionary
        public ActionResult ClearDictionary()
        {
            ViewBag.MyDictionary = myDictionary;
            myDictionary.Clear();
            ViewBag.Clear = "Dictionary is empty";
            return View("Index");
        }

        //Search for any item in the data structure (hardcoded) and return if it was found
        //or not found and how long it took to search
        public ActionResult Search()
        {
            System.Diagnostics.Stopwatch stopwatch = new System.Diagnostics.Stopwatch();

            stopwatch.Start();
            TimeSpan timespan = stopwatch.Elapsed;

            foreach (KeyValuePair<string, int> entry in myDictionary)
            {
                System.Threading.Thread.Sleep(13);


                if (myDictionary.ContainsValue(13))
                {
                    stopwatch.Stop();
                    timespan = stopwatch.Elapsed;
                    ViewBag.Search = "The dictionary contains 'New Entry 7'";
                }

                else
                {
                    stopwatch.Stop();
                    timespan = stopwatch.Elapsed;
                    ViewBag.Search = "The dictionary does not contain 'New Entry 7'";
                }

                ViewBag.Time = "Time: " + timespan;
                return View("Index");

            }
        }

        //Return back to the main menu
        public ActionResult ReturnHome()
        {
            return RedirectToAction("Index", "Home");
        }
    }
}