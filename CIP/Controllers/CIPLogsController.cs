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

namespace CIP.Controllers
{
    public class CIPLogsController : ApiController
    {
        private CIPEntities db = new CIPEntities();

       // GET: api/CIPLogs/5
        public IEnumerable<CIPLog> GetCIPLog(decimal id)
        {
            CIPRepository Rep = new CIPRepository();
            var modelList = new List<CIPLog>();
            return Rep.Retrieve();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CIPLogExists(decimal id)
        {
            return db.CIPLogs.Count(e => e.id == id) > 0;
        }
    }
}