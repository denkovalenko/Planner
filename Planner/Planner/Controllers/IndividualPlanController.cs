using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Domain.Models;

using Newtonsoft.Json;

namespace Planner.Controllers
{
    public class IndividualPlanController : Controller
    {
        // GET: IndividualPlan
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult TrainingJob()
        {
            return View();
        }

        public ActionResult PlanScientificWork()
        {
            return View();
        }

        public ActionResult PlanMethodicalWork()
        {
            return View();
        }

        public ActionResult PlanManagment()
        {
            return View();
        }
        public string GetPlanTrainingJobs()
        {
            using (var db = new ApplicationDbContext())
            {
                var data = db.PlanTrainingJobs.ToList();
                return JsonConvert.SerializeObject(data);
            }
        }

        public void SavePlanTrainingJobs(PlanTrainingJob model)
        {
            using (var db = new ApplicationDbContext())
            {
                model.Id = Guid.NewGuid().ToString();
                db.Entry(model).State = System.Data.Entity.EntityState.Added;
                db.SaveChanges();
            }
        }

        public void DeletePlanTrainingJobs(string id)
        {
            using (var db = new ApplicationDbContext())
            {
                if (id != null)
                {
                    db.Entry(new PlanTrainingJob() { Id = id }).State = System.Data.Entity.EntityState.Deleted;
                    db.SaveChanges();
                }
            }
        }

        public void EditPlanTrainingJobs(PlanTrainingJob model)
        {
            using (var db = new ApplicationDbContext())
            {
                if (model.Id != null)
                {
                    db.Entry(model).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                }
            }
        }

        public string GetPlanScientificWork()
        {
            using (var db = new ApplicationDbContext())
            {
                var data = db.PlanScientificWorks.ToList();
                return JsonConvert.SerializeObject(data);
            }
        }

        public void SavePlanScientificWork(PlanScientificWork model)
        {
            using (var db = new ApplicationDbContext())
            {
                model.Id = Guid.NewGuid().ToString();
                db.Entry(model).State = System.Data.Entity.EntityState.Added;
                db.SaveChanges();
            }
        }

        public void DeletePlanScientificWork(string id)
        {
            using (var db = new ApplicationDbContext())
            {
                if (id != null)
                {
                    db.Entry(new PlanScientificWork() { Id = id }).State = System.Data.Entity.EntityState.Deleted;
                    db.SaveChanges();
                }
            }
        }

        public void EditPlanScientificWork(PlanScientificWork model)
        {
            using (var db = new ApplicationDbContext())
            {
                if (model.Id != null)
                {
                    db.Entry(model).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                }
            }
        }
        public string GetPlanMethodicalWork()
        {
            using (var db = new ApplicationDbContext())
            {
                var data = db.PlanMethodicalWorks.ToList();
                return JsonConvert.SerializeObject(data);
            }
        }

        public void SavePlanMethodicalWork(PlanMethodicalWork model)
        {
            using (var db = new ApplicationDbContext())
            {
                model.Id = Guid.NewGuid().ToString();
                db.Entry(model).State = System.Data.Entity.EntityState.Added;
                db.SaveChanges();
            }
        }

        public void DeletePlanMethodicalWork(string id)
        {
            using (var db = new ApplicationDbContext())
            {
                if (id != null)
                {
                    db.Entry(new PlanMethodicalWork() { Id = id }).State = System.Data.Entity.EntityState.Deleted;
                    db.SaveChanges();
                }
            }
        }

        public void EditPlanMethodicalWork(PlanMethodicalWork model)
        {
            using (var db = new ApplicationDbContext())
            {
                if (model.Id != null)
                {
                    db.Entry(model).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                }
            }
        }
        
        public string GetPlanManagment()
        {
            using (var db = new ApplicationDbContext())
            {
                var data = db.PlanManagments.ToList();
                return JsonConvert.SerializeObject(data);
            }
        }

        public void SavePlanManagment(PlanManagment model)
        {
            using (var db = new ApplicationDbContext())
            {
                model.Id = Guid.NewGuid().ToString();
                db.Entry(model).State = System.Data.Entity.EntityState.Added;
                db.SaveChanges();
            }
        }

        public void DeletePlanManagment(string id)
        {
            using (var db = new ApplicationDbContext())
            {
                if (id != null)
                {
                    db.Entry(new PlanManagment() { Id = id }).State = System.Data.Entity.EntityState.Deleted;
                    db.SaveChanges();
                }
            }
        }

        public void EditPlanManagment(PlanManagment model)
        {
            using (var db = new ApplicationDbContext())
            {
                if (model.Id != null)
                {
                    db.Entry(model).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                }
            }
        }
    }
}