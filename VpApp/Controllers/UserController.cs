using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using VpApp.Models;
using System.Data.Entity;

namespace VpApp.Controllers
{
    [Authorize(Roles = "Администратор, Модератор, Исполнитель")]
    public class UserController : Controller
    {
        // GET: User
        private VpAppContext db = new VpAppContext();
        [HttpGet]
        public ActionResult Index()
        {
            var users = db.Users.Include(d => d.Department).Include(d => d.Role).Include(d =>d.Telefon).Include(d => d.Position).ToList();
            return View(users);
        }

        [HttpGet]
        [Authorize(Roles = "Администратор")]
        public ActionResult Create()
        {
            SelectList departments = new SelectList(db.Departments, "Id", "Name");
            ViewBag.Departments = departments;
            SelectList positions = new SelectList(db.Positions, "Id", "Name");
            ViewBag.Positions = positions;
            SelectList roles = new SelectList(db.Roles, "Id", "Name");
            ViewBag.Roles = roles;
            return View();
        }

        [HttpPost]
        [Authorize(Roles = "Администратор")]
        public ActionResult Create(User user /*Tels[] tel*/)
        {
            if (ModelState.IsValid)
            {
                user.Id = Guid.NewGuid();
                db.Users.Add(user);
                //for (int i = 0; i< tels.Count; i++)
                //{
                //    tels[i].Id = Guid.NewGuid();
                //    db.Telefons.Add(tels[i]);


                //}
                db.SaveChanges();

                return RedirectToAction("Index");
            }

            SelectList departments = new SelectList(db.Departments, "Id", "Name");
            ViewBag.Departments = departments;
            SelectList positions = new SelectList(db.Positions, "Id", "Name");
            ViewBag.Positions = positions;
            SelectList roles = new SelectList(db.Roles, "Id", "Name");
            ViewBag.Roles = roles;

            return View(user);
        }
    }
}