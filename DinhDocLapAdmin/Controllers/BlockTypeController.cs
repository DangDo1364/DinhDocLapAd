using DinhDocLapAdmin.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DinhDocLapAdmin.Controllers
{
    public class BlockTypeController : Controller
    {
        public IActionResult Index(int pg = 1)
        {
            const int pageSize = 20;
            if (pg < 1)
            {
                pg = 1;
            }
            int recsCount = BlockType.GetFullBlockTypes().Count();
            var pager = new Pager(recsCount, pg, pageSize);
            int recSkip = (pg - 1) * pageSize;
            var data = BlockType.GetFullBlockTypes().Skip(recSkip).Take(pager.pageSize).ToList();
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
            int recsCount = BlockType.GetFullBlockTypes().Count();
            var pager = new Pager(recsCount, pg, pageSize);

            int recSkip = (pg - 1) * pageSize;
            var data = BlockType.GetFullBlockTypes().Skip(recSkip).Take(pager.pageSize).ToList();
            this.ViewBag.Pager = pager;

            return View("Index", data);
        }
        public IActionResult Insert()
        {
            return View();
        }
        public IActionResult InsertBT(BlockType blockType)
        {
            BlockType.InsertBlockType(blockType);
            return RedirectToAction("Index");
        }
    }
}
