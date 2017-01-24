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
using System.Web.Http.Results;
using System.Web.Mvc;

namespace CIP.Controllers {
  public class CIPLogsController : ApiController {
    private CIPEntities db = new CIPEntities();
    private CIPRepository Rep = new CIPRepository();
    // GET: api/CIPLogs/5
    public IEnumerable<CIPLog> GetCIPLog(decimal id) {
      var modelList = new List<CIPLog>();
      return Rep.Retrieve();
    }

    public void PostCIPLog(string id, int ssn, int phone, string first, string last, CIPModel model) {
      Rep.Create(id, ssn, phone, first, last, model);
    }

    protected override void Dispose(bool disposing) {
      if (disposing) {
        db.Dispose();
      }
      base.Dispose(disposing);
    }
  }
}