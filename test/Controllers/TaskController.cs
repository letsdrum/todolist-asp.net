﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using test.Models;

namespace test.Controllers
{
    public class TaskController : Controller
    {
        DBContext Context = new DBContext();

        public ActionResult Index()
        {
            ViewBag.Tasks = Context.Table;
            return View();
        }

        [HttpGet]
        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddTodo()
        {
            var TaskName = Request.Params["TaskName"];
            var Description = Request.Params["Description"];
            Table todo = new Table()
            {
                Id = Context.Table.Count() + 1,
                TaskName = TaskName,
                Description = Description,
                DateCreated = DateTime.Now
            };

            Context.Table.Add(todo);

            Context.SaveChanges();

            ViewBag.Tasks = Context.Table;
            ViewBag.Added = true;
            return View("Index");
        }


        public ActionResult DeleteTodo(int id)
        {
            var todo = Context.Table.Find(id);

            Context.Table.Remove(todo);
            Context.SaveChanges();

            ViewBag.Tasks = Context.Table;
            ViewBag.Deleted = true;
            return View("Index");
        }

        
    }
}
