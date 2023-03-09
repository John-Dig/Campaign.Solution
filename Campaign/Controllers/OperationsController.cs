using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Campaign.Models;
using System.Collections.Generic;
using System.Linq;

namespace Campaign.Controllers
{
  public class OperationsController : Controller
  {
    private readonly CampaignContext _db;

    public OperationsController(CampaignContext db)
    {
      _db = db;
    }

    public ActionResult Index()
    {
      List<Operation> model = _db.Operations.ToList();
      return View(model);
    }

    public ActionResult Create()
    {
      return View();
    }

    [HttpPost]
    public ActionResult Create(Operation operation)
    {
      _db.Operations.Add(operation);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    public ActionResult Details(int id)
    {
      Operation thisOperation = _db.Operations
                                  .Include(operation => operation.Missions)
                                  .FirstOrDefault(operation => operation.OperationId == id);
      return View(thisOperation);
    }

    public ActionResult Edit(int id)
    {
      Operation thisOperation = _db.Operations.FirstOrDefault(operation => operation.OperationId == id);
      return View(thisOperation);
    }

    [HttpPost]
    public ActionResult Edit(Operation operation)
    {
      _db.Operations.Update(operation);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    public ActionResult Delete(int id)
    {
      Operation thisOperation = _db.Operations.FirstOrDefault(operation => operation.OperationId == id);
      return View(thisOperation);
    }

    [HttpPost, ActionName("Delete")]
    public ActionResult DeleteConfirmed(int id)
    {
      Operation thisOperation = _db.Operations.FirstOrDefault(operation => operation.OperationId == id);
      _db.Operations.Remove(thisOperation);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }
  }
}
