using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CIP.Models {
  public class CIPLog {
    [Key]
    public decimal id { get; set; }
    public string AuditLogDetail { get; set; }
    public string UserID { get; set; }
    public string Case_ID { get; set; }
    public int? SSN { get; set; }
    public int? PhoneNo { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public DateTime CreateDTM { get; set; }
  }
}