using MyToDo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MyToDo.Models;
using MyToDo.Migrations;
using WebGrease.Css.Extensions;
using System.Net;

namespace MyToDo.Controllers
{
    public class ToDoesController : Controller

    {
        ApplicationDbContext context = new ApplicationDbContext();
        // GET: ToDoes
        public ActionResult Index()
        {
            
            return View(context.ToDos);
        }

        [HttpPost]
        public ActionResult Index(int ? id ,bool status)
        {
            
                var update = context.ToDos.FirstOrDefault(x => x.Id == id);
            if (update != null)
            {
               update.Status = status;
                context.SaveChanges();
                return Json(new { status });
            }
         
            return View("Index");  
        }

        public ActionResult Create()
        { return View(); }


        [HttpPost]
        public ActionResult Create(ToDo todo) 
        {
           // if(ModelState.IsValid)
           // {
                context.ToDos.Add(todo);
                context.SaveChanges();
                return RedirectToAction("Index");  
          // }
              
            
          
                
        }
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ToDo toDo = context.ToDos.Find(id);
            if (toDo == null)
            {
                return HttpNotFound();
            }
            return View(toDo);
        }

        
        [HttpPost, ActionName("Delete")]
       
        public ActionResult DeleteConfirmed(int id)
        {
            ToDo toDo = context.ToDos.Find(id);
            context.ToDos.Remove(toDo);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Details(int ? id) 
        {
            var todo = context.ToDos.FirstOrDefault(y => y.Id == id);
            if (todo == null) 
            {
                return Content("Task not found ");
            }

            return View(todo);
        }

        public ActionResult Edit(int ? id)
        {

            var todo = context.ToDos.FirstOrDefault(x => x.Id == id);
            return View(todo);
        }
        [HttpPost]
        public ActionResult Edit(ToDo todo) 
        {
            var todos = context.ToDos.FirstOrDefault(x => x.Id == todo.Id);
            if (ModelState.IsValid)
            {
                context.ToDos.Remove(todos);
                context.ToDos.Add(todo);
            }
            context.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}