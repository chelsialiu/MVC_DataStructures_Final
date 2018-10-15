using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_DataStructures_Final.Controllers
{
        public class StackController : Controller
        {
            static Stack<string> myStack = new Stack<string>();
            // GET: Stack
            public ActionResult Index()
            {
                ViewBag.MyStack = myStack;
                return View();
            }

            public ActionResult AddOne()
            {
                myStack.Push("New Entry " + (myStack.Count + 1));
                return View("Index");
            }

            public ActionResult AddHuge()
            {
                myStack.Clear();
                ViewBag.MyStack = myStack;
                ViewBag.MyStack.Clear();
                for (int i = 0; i <= 1999; i++)
                {
                    myStack.Push("New Entry " + (i + 1));
                }
                return View("Index");
            }

            public ActionResult Display()
            {
                ViewBag.MyStack = myStack;
                return View("Index");
            }

            public ActionResult Delete()
            {
                if (myStack.Count == 0)
                {
                    ViewBag.Clear = "Stack is Empty";
                }
                else
                {
                    myStack.Pop();
                }
                return View("Index");
            }

            public ActionResult Clear()
            {
                ViewBag.MyStack = myStack;
                myStack.Clear();
                ViewBag.MyStack.Clear();
                ViewBag.Clear = "Stack is Empty";
                return View("Index");
            }

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
                    ViewBag.Search = "The stack contains 'New Entry 7'";
                    timespan = Stopwatch.Elapsed;
                }
                else
                {
                    Stopwatch.Stop();
                    timespan = Stopwatch.Elapsed;
                    ViewBag.Search = "The stack does not contain 'New Entry 7'";
                }
                ViewBag.Time = "Time: " + timespan;
                return View("Index");
            }

            public ActionResult ReturnHome()
            {
                return RedirectToAction("Index", "Home");
            }
        }
    }