using DinhDocLapAdmin.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DinhDocLapAdmin.Controllers
{
    public class FaceBlockController : Controller
    {
        public IActionResult Index(int pg = 1)
        {
            const int pageSize = 20;
            if (pg < 1)
            {
                pg = 1;
            }
            int recsCount = FaceBlock.GetFull().Count();
            var pager = new Pager(recsCount, pg, pageSize);
            int recSkip = (pg - 1) * pageSize;
            var data = FaceBlock.GetFull().Skip(recSkip).Take(pager.pageSize).ToList();
            this.ViewBag.Pager = pager;

            return View(data);
        }
        public IActionResult Pagination(int pg)
        {
            const int pageSize = 20;
            if (pg < 1)
            {
                pg = 1;
            }
            int recsCount = FaceBlock.GetFull().Count();
            var pager = new Pager(recsCount, pg, pageSize);

            int recSkip = (pg - 1) * pageSize;
            var data = FaceBlock.GetFull().Skip(recSkip).Take(pager.pageSize).ToList();
            this.ViewBag.Pager = pager;

            return View("Index", data);
        }
    }
}
