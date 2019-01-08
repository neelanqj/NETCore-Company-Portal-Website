using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace PongStudiosPortal.Controllers
{
    [Authorize("SuperAdmin")]
    public class ClaimsController : Controller
    {
        public IActionResult Index()
        {
            return View(User?.Claims);
        }
    }
}
