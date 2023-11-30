using GeoProfs.Models;
using Microsoft.AspNetCore.Mvc;

namespace GeoProfs.Controllers {
    public class HomeController : Controller {

        private static List<LeaveRequest> leaveRequest = new List<LeaveRequest>() {

        };
        public IActionResult Index()
        {
            return View();
        }

        //public IActionResult LeaveRequestPartial()
        //{
        //    return PartialView("_LeaveRequests", leaveRequest);
        //}

        public IActionResult LeaveRequestPartial()
        {
            return PartialView("_leaveRequest");
        }
    }
}
