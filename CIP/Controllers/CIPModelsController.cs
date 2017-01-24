using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using CIP;
using CIP.Models;
using System.Web.Mvc;
using System.Web.Http.Results;
using System.Web.Http.Cors;

namespace CIP.Controllers {
  public class CIPModelsController : ApiController {
    private CIPEntities db = new CIPEntities();

    // GET: api/CIPModels/5
    public CIPModel GetIndvidualContactById(string id = "", int ssn = 0, int phone = 0, string first = "", string last = "") {
      var currentUser = User.Identity.Name;
      var item = new CIPModel();
      if (id != null) {
        var cipRepo = new CIPRepository();
        item = cipRepo.GetCaseInfo(item);
        item.Indicators = cipRepo.GetCaseIndicators();
        item.CaseStatus = cipRepo.GetCaseStatuses();
        item.ToDoList = cipRepo.GetToDoList();
        item.CaseActivity = cipRepo.GetCaseActivity();
        item.CaseComments = cipRepo.GetCaseComments();
        item.CaseIndividuals = cipRepo.GetActiveIndividuals();
        item.IndivDetails = cipRepo.GetIndivDetails();
        item.CaseActivityDetails = cipRepo.GetActivityDetails();
        item.Username = currentUser;
      }
      else {
        item.Response = "The case entered could not be found. Please try a different search parameter";
      }
      var cipLog = new CIPLogsController();
      cipLog.PostCIPLog(id, ssn, phone, first, last, item);
      return item;
    }

    protected override void Dispose(bool disposing) {
      if (disposing) {
        db.Dispose();
      }
      base.Dispose(disposing);
    }
  }
}