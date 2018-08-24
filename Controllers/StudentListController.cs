using ListStudents.Models;
using System.Collections;
using System.Data;
using System.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace ListStudents.Controllers
{
    public class StudentListController : Controller
    {
        private StudentsEntities entities = new StudentsEntities();
        // GET: StudentList
        public ActionResult Index()
        {

            return View(entities.StudentList.ToList());
        }
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StudentList studentList = entities.StudentList.Find(id);
            if (studentList == null)
            {
                return HttpNotFound();
            }
            return View(studentList);
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "StudentId,FristName,LastName,Grade")] StudentList studentList)
        {
            if (ModelState.IsValid)
            {
                entities.StudentList.Add(studentList);
                entities.SaveChanges();
                return RedirectToAction("Index");
               
            }
            return View(studentList);
            
        }
        public ActionResult Edit(int? id)
        {
            if(id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StudentList studentList = entities.StudentList.Find(id);
            if( studentList == null)
            {
                return HttpNotFound();
            }
            return View(studentList);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "StudentId,FristName,Lastname,Grade")] StudentList studentList)
        {
            if (ModelState.IsValid)
            {
                entities.Entry(studentList).State = EntityState.Modified;
                entities.SaveChanges();
                return RedirectToAction("Index");

            }
            return View(studentList);
        }
        public ActionResult Delete(int? id)
        {
            if(id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StudentList studentList = entities.StudentList.Find(id);
            if(studentList == null)
            {
                return HttpNotFound();
            }
            return View(studentList);
        }
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int? id)
        {
            StudentList studentList = entities.StudentList.Find(id);
            entities.StudentList.Remove(studentList);
            entities.SaveChanges();
            return RedirectToAction("Index");
        }
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                entities.Dispose();
                base.Dispose(disposing);
            }
           
        }








    }
       
            


    
}