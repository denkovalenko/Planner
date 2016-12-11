using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Domain.Models;

using Newtonsoft.Json;

namespace Planner.Controllers
{
    public static class IndivPlanTabNamesEnum
    {
        public static String ScientificPublishingTab { get { return "ScientificPublishing"; } }
    }
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
        public ActionResult SaveScientificData(List<ScientificSaveDataHelper> model)
        {
            List<PlanScientificWork> userData = new List<Domain.Models.PlanScientificWork>();
            using (var db = new ApplicationDbContext())
            {
                userData = db.PlanScientificWorks.ToList();

                model.ForEach(el =>
                {
                    if (userData.Select(x => x.SchemaName).Contains(el.SchemaName))
                    {
                        var update = userData.Where(x => x.SchemaName == el.SchemaName).FirstOrDefault();
                        update.ActualVolume = (Int32)el.Value;
                    }
                    else
                    {
                        db.PlanScientificWorks.Add(new Domain.Models.PlanScientificWork { ActualVolume = (Int32)el.Value, SchemaName = el.SchemaName, Content = el.Name });
                    }
                });
                db.SaveChanges();
            }
            return null;
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

    public class ScientificSaveDataHelper
    {
        public String SchemaName { get; set; }
        public String Name { get; set; }
        public Int32? Value { get; set; }
    }
}