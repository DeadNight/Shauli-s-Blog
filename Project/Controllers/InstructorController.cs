using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Project.DAL;
using Project.Models;
using Project.ViewModels;
using System.Data.Entity.Infrastructure;

namespace Project.Controllers
{
    public class InstructorController : Controller
    {
        private SchoolContext db = new SchoolContext();

        // GET: Instructor
        public ActionResult Index(int? id, int? courseID, string nameFilter, string officeFilter, int? courseFilter)
        {
            var viewModel = new InstructorIndexData();
            var instructors = db.Instructors
                                  .Include(i => i.OfficeAssignment)
                                  .Include(i => i.Courses.Select(c => c.Department));

            if(!string.IsNullOrWhiteSpace(nameFilter))
            {
                ViewBag.NameFilter = nameFilter;
                instructors = instructors
                    .Where(i => i.FirstMidName.ToUpper().Contains(nameFilter.ToUpper())
                             || i.LastName.ToUpper().Contains(nameFilter.ToUpper()));
            }

            if(!string.IsNullOrWhiteSpace(officeFilter))
            {
                ViewBag.OfficeFilter = officeFilter;
                instructors = instructors.Where(i => i.OfficeAssignment.Location.ToUpper().Contains(officeFilter.ToUpper()));
            }

            if(courseFilter != null)
            {
                ViewBag.CourseFilter = courseFilter;
                instructors = instructors.Where(i => courseFilter == null ? true : 1 == i.Courses.Count(c => c.CourseID == courseFilter));
            }

            viewModel.Instructors = instructors.OrderBy(i => i.LastName);
            ViewBag.AllCourses = db.Courses.OrderBy(c => c.Title).ToList();

            if (id != null)
            {
                var instructor = viewModel.Instructors.Where(i => i.ID == id.Value).SingleOrDefault();
                if (instructor == null)
                {
                    id = null;
                    return RedirectToAction("Index", new { id, nameFilter, officeFilter, courseFilter });
                }
                ViewBag.InstructorID = id.Value;
                viewModel.Courses = viewModel.Instructors.Where(i => i.ID == id.Value).Single().Courses;

            }
            if(courseID != null)
            {
                ViewBag.CourseID = courseID.Value;
                // Lazy loading
                viewModel.Enrollments = viewModel.Courses.Where(c => c.CourseID == courseID).Single().Enrollments;
                // Explicit loading
                //var selectedCourse = viewModel.Courses.Where(c => c.CourseID == courseID).Single();
                //db.Entry(selectedCourse).Collection(c => c.Enrollments).Load();
                //foreach(Enrollment enrollment in selectedCourse.Enrollments)
                //{
                //    db.Entry(enrollment).Reference(e => e.Student).Load();
                //}
                //viewModel.Enrollments = selectedCourse.Enrollments;
            }
            return View(viewModel);
        }

        // GET: Instructor/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Instructor instructor = db.Instructors.Find(id);
            if (instructor == null)
            {
                return HttpNotFound();
            }
            return View(instructor);
        }

        // GET: Instructor/Create
        public ActionResult Create()
        {
            var instructor = new Instructor();
            instructor.Courses = new List<Course>();
            PopulateAssignedCoursesData(instructor);
            return View(instructor);
        }

        // POST: Instructor/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "LastName,FirstMidName,HireDate,OfficeAssignment")] Instructor instructor, string[] selectedCourses)
        {
            if(selectedCourses != null)
            {
                instructor.Courses = new List<Course>();
                foreach(var course in selectedCourses)
                {
                    var courseToAdd = db.Courses.Find(int.Parse(course));
                    instructor.Courses.Add(courseToAdd);
                }
            }
            if (ModelState.IsValid)
            {
                db.Instructors.Add(instructor);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            PopulateAssignedCoursesData(instructor);
            return View(instructor);
        }

        // GET: Instructor/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Instructor instructor = db.Instructors
                .Include(i => i.OfficeAssignment)
                .Include(i => i.Courses)
                .Where(i => i.ID == id)
                .Single();
            PopulateAssignedCoursesData(instructor);
            if (instructor == null)
            {
                return HttpNotFound();
            }
            return View(instructor);
        }

        // POST: Instructor/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int? id, string[] selectedCourses)
        {
            if(id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Instructor instructorToUpdate = db.Instructors
                .Include(i => i.OfficeAssignment)
                .Include(i => i.Courses)
                .Where(i => i.ID == id)
                .Single();
            if(TryUpdateModel(instructorToUpdate, "", new string[] { "Last Name", "FirstMidName", "HireDate", "OfficeAssignment" }))
            {
                try
                {
                    if (string.IsNullOrWhiteSpace(instructorToUpdate.OfficeAssignment.Location))
                    {
                        instructorToUpdate.OfficeAssignment = null;
                    }

                    UpdateInstructorCourses(selectedCourses, instructorToUpdate);

                    db.Entry(instructorToUpdate).State = EntityState.Modified;
                    db.SaveChanges();

                    return RedirectToAction("Index");
                }
                catch (RetryLimitExceededException /* dex */)
                {
                    //Log the error (uncomment dex variable name and add a line here to write a log.
                    ModelState.AddModelError("", "Unable to save changes.Try again, and if the problem persists, see your system administrator.");
                }
            }
            PopulateAssignedCoursesData(instructorToUpdate);
            return View(instructorToUpdate);
        }

        private void PopulateAssignedCoursesData(Instructor instructor)
        {
            var allCourses = db.Courses;
            var instructorCourses = new HashSet<int>(instructor.Courses.Select(c => c.CourseID));
            var viewModel = new List<AssignedCourseData>();
            foreach (var course in allCourses)
            {
                viewModel.Add(new AssignedCourseData
                {
                    CourseID = course.CourseID,
                    Title = course.Title,
                    Assigned = instructorCourses.Contains(course.CourseID)
                });
            }
            ViewBag.Courses = viewModel;
        }

        private void UpdateInstructorCourses(string[] selectedCourses, Instructor instructorToUpdate)
        {
            if (selectedCourses == null)
            {
                instructorToUpdate.Courses = new List<Course>();
                return;
            }

            var selectedCoursesHS = new HashSet<string>(selectedCourses);
            var instructorCourses = new HashSet<int>(instructorToUpdate.Courses.Select(c => c.CourseID));
            foreach(var course in db.Courses)
            {
                if (selectedCoursesHS.Contains(course.CourseID.ToString()))
                {
                    if(!instructorCourses.Contains(course.CourseID))
                    {
                        instructorToUpdate.Courses.Add(course);
                    }
                }
                else
                {
                    if(instructorCourses.Contains(course.CourseID))
                    {
                        instructorToUpdate.Courses.Remove(course);
                    }
                }
            }
        }

        // GET: Instructor/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Instructor instructor = db.Instructors.Find(id);
            if (instructor == null)
            {
                return HttpNotFound();
            }
            return View(instructor);
        }

        // POST: Instructor/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Instructor instructor = db.Instructors
                .Include(i => i.OfficeAssignment)
                .Where(i => i.ID == id)
                .Single();

            instructor.OfficeAssignment = null;
            db.Instructors.Remove(instructor);

            var department = db.Departments
                .Where(d => d.InstructorID == id)
                .SingleOrDefault();
            if(department != null)
            {
                department.InstructorID = null;
            }

            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
