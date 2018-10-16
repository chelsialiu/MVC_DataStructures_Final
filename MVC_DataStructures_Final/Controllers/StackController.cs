//This Stack controller has all the stack methods that return the corresponding views.
//Created by Matt Smith 10/15/18

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_DataStructures_Final.Controllers
{
        public class StackController : Controller
        {
            //Declare stack variable
            static Stack<string> myStack = new Stack<string>();

            //Index method
            public ActionResult Index()
            {
                ViewBag.MyStack = myStack;
                return View();
            }

            //Add one item to stack
            public ActionResult AddOne()
            {
                myStack.Push("New Entry " + (myStack.Count + 1));
                return View("Index");
            }

             //Add huge list of items to stack
             public ActionResult AddHuge()
            {
                //First clear the stack
                myStack.Clear();

                ViewBag.MyStack = myStack;

                for (int i = 0; i < 2000; i++)
                {
                    myStack.Push("New Entry " + (i + 1));
                }

                return View("Index");
            }
            
            //Display contents of the stack
            public ActionResult Display()
            {
                //If there is something in the stack, then display the stack
                if (myStack.Count > 0)
                {
                    ViewBag.MyStack = myStack;
                    return View("Index");
                }

                //If not, handle any errors and inform the user
                else
                {
                    ViewBag.Display = "Stack is empty. Nothing to display";
                    return View("Index");
                }
            }

            //Delete the most recently added entry from the stack
            public ActionResult Delete()
            {
                //Handle any errors and inform the user
                if (myStack.Count == 0)
                {
                    ViewBag.Clear = "Stack is empty. Nothing to delete.";
                }

                else
                {
                    myStack.Pop();
                }

                return View("Index");
            }

            //Wipe out the contents of the queue
            public ActionResult Clear()
            {
                myStack.Clear();
                ViewBag.Clear = "The stack has been cleared";
                return View("Index");
            }

            //Search the stack for a specific entry and report if it was found and how long it took to search
            public ActionResult Search()
            {
                System.Diagnostics.Stopwatch Stopwatch = new System.Diagnostics.Stopwatch();
                Stopwatch.Start();
                TimeSpan timespan = Stopwatch.Elapsed;

                bool bResult;
                bResult = myStack.Contains("New Entry 7");

                if (bResult == true)
                {
                    Stopwatch.Stop();
                    timespan = Stopwatch.Elapsed;
                    ViewBag.Search = "The stack contains 'New Entry 7'";

                }

                else
                {
                    Stopwatch.Stop();
                    timespan = Stopwatch.Elapsed;
                    ViewBag.Search = "The stack does not contain 'New Entry 7'";
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