using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Campaign.Models;
using System.Collections.Generic;
using System.Linq;

namespace Campaign.Controllers
{
  public class MissionsController : Controller
  {
    private readonly CampaignContext _db;

    public MissionsController(CampaignContext db)
    {
      _db = db;
    }

    public ActionResult Index()
    {
      List<Mission> model = _db.Missions
                            .Include(mission => mission.Operation)
                            .ToList();
      return View(model);
    }

    public ActionResult Create()
    {
      ViewBag.OperationId = new SelectList(_db.Operations, "OperationId", "Name");
      return View();
    }

    [HttpPost]
    public ActionResult Create(Mission mission)
    {
      if (mission.OperationId == 0)
      {
        return RedirectToAction("Create");
      }
      _db.Missions.Add(mission);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    public ActionResult Details(int id)
    {
      Mission thisMission = _db.Missions
                          .Include(mission => mission.Operation)
                          .FirstOrDefault(mission => mission.MissionId == id);
      return View(thisMission);
    }

    public ActionResult Edit(int id)
    {
      Mission thisMission = _db.Missions.FirstOrDefault(mission => mission.MissionId == id);
      ViewBag.OperationId = new SelectList(_db.Operations, "OperationId", "Name");
      return View(thisMission);
    }

    [HttpPost]
    public ActionResult Edit(Mission mission)
    {
      _db.Missions.Update(mission);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    public ActionResult Delete(int id)
    {
      Mission thisMission = _db.Missions.FirstOrDefault(mission => mission.MissionId == id);
      return View(thisMission);
    }

    [HttpPost, ActionName("Delete")]
    public ActionResult DeleteConfirmed(int id)
    {
      Mission thisMission = _db.Missions.FirstOrDefault(mission => mission.MissionId == id);
      _db.Missions.Remove(thisMission);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }
  }
}