//This Queue controller has all the queue methods that return the corresponding views.
//Created by Andrew Dale 10/15/18

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_DataStructures_Final.Controllers
{
    public class QueueController : Controller
    {
    
        //Declare queue variable
        static Queue<string> myQueue = new Queue<string>();

        //Index method
        public ActionResult Index()
        {
            ViewBag.MyQueue = myQueue;
            return View();
        }

        //Add one item to queue
        public ActionResult AddOne()
        {
            myQueue.Enqueue("New Entry " + (myQueue.Count + 1));
            return View("Index");
        }

        //Add huge list of items to queue
        public ActionResult AddHuge()
        {
            //First clear the queue
            myQueue.Clear();

            ViewBag.MyQueue = myQueue;

            //Generate 2,000 items in the queue
            for (int i = 0; i < 2000; i++)
            {
                myQueue.Enqueue("New Entry " + (myQueue.Count + 1));
            }

            return View("Index");
        }

        //Display contents of the queue
        public ActionResult Display()
        {
            //If there is something in the queue, then display the queue
            if (myQueue.Count > 0)
            {
                ViewBag.MyQueue = myQueue;
                return View("Index");
            }

            //If not, handle any errors and inform the user
            else
            {
                ViewBag.Display = "Queue is empty. Nothing to display";
                return View("Index");
            }
        }

         //Delete the most recently added entry from the queue
        public ActionResult Delete()
        {
            //Handle any errors and inform the user
            if (myQueue.Count ==  0)
            {
                ViewBag.Delete = "Queue is empty. Nothing to delete";
            }

            else
            {
                myQueue.Dequeue();
            }

            return View("Index");
        }

        //Wipe out the contents of the queue
        public ActionResult Clear()
        {
            myQueue.Clear();
            ViewBag.Clear = "The queue has been cleared";
            return View("Index");
        }

        //Search the queue for a specific entry and report if it was found and how long it took to search
        public ActionResult Search()
        {
            System.Diagnostics.Stopwatch Stopwatch = new System.Diagnostics.Stopwatch();
            Stopwatch.Start();
            TimeSpan timespan = Stopwatch.Elapsed;

            if (myQueue.Contains("New Entry 7"))
            {
                Stopwatch.Stop();
                timespan = Stopwatch.Elapsed;
                ViewBag.Search = "The queue contains 'New Entry 7'";
            }

            else
            {
                Stopwatch.Stop();
                timespan = Stopwatch.Elapsed;
                ViewBag.Search = "The queue does not contain 'New Entry 7'";
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
