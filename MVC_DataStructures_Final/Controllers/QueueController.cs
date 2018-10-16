using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_DataStructures_Final.Controllers
{
    public class QueueController : Controller
    {
    
        //Declare Queue Variable

        static Queue<string> myQueue = new Queue<string>();

        // Index Method 
        public ActionResult Index()
        {
            ViewBag.MyQueue = myQueue;
            return View();
        }

        //AddOne Method that allows you to add a new entry to the queue

        public ActionResult AddOne()
        {
            myQueue.Enqueue("New Entry " + (myQueue.Count + 1));
        
            return View("Index");
        }

        //AddHuge Method that allows you to add a list of 2000 new entries to the queue

        public ActionResult AddHuge()
        {
            myQueue.Clear();

            for (int iCount = 0; iCount < 2000; iCount++)
            {
                myQueue.Enqueue("New Entry " + (myQueue.Count + 1));
            }

           
            return View("Index");
        }

        //Display Method that allows you to display the queue

                public ActionResult Display()
                {
                    ViewBag.MyQueue = myQueue;


            return View("Index");

                }

         //Delete Method allows you to delete the most recently added entry from the queue

        public ActionResult Delete()
        {
            if (myQueue.Count > 0)
            {
                myQueue.Dequeue();
                return View("Index");
            }
            else
            {
                ViewBag.Clear = "Nothing to delete";
                return View("Index");
            }
        }

        //Clear Method clears the entire queue

        public ActionResult Clear()
        {
            myQueue.Clear();
            ViewBag.Clear = "The Queue has been cleared";
            return View("Index");


            

        }

        //Search Method allows you to search the queue for a specific entry and reports the time it took to find the entry

        public ActionResult Search()
        {
            System.Diagnostics.Stopwatch Stopwatch = new System.Diagnostics.Stopwatch();
            Stopwatch.Start();
            TimeSpan timespan = Stopwatch.Elapsed;

            if (myQueue.Contains("New Entry 3"))
            {
                Stopwatch.Stop();
                timespan = Stopwatch.Elapsed;
                ViewBag.Search = "The Queue contains New Entry 3";

            }

            else
            {
                Stopwatch.Stop();
                timespan = Stopwatch.Elapsed;
                ViewBag.Search = "The Queue does not contain New Entry 3";


            }

            ViewBag.Time = "Time: " + timespan;
            return View("Index");
        }


        //The ReturnHome method takes you back to the home index (Home Page)

                public ActionResult ReturnHome()
              {
                 return RedirectToAction("Index", "Home");
              }

    }
}
