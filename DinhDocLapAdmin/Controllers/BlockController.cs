using DinhDocLapAdmin.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DinhDocLapAdmin.Controllers
{
    public class BlockController : Controller
    {
        public IActionResult Index(int pg = 1)
        {
            const int pageSize = 20;
            if (pg < 1)
            {
                pg = 1;
            }
            int recsCount = Block.GetFullBlocks().Count();
            var pager = new Pager(recsCount, pg, pageSize);
            int recSkip = (pg - 1) * pageSize;
            var data = Block.GetFullBlocks().Skip(recSkip).Take(pager.pageSize).ToList();
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
            int recsCount = Block.GetFullBlocks().Count();
            var pager = new Pager(recsCount, pg, pageSize);

            int recSkip = (pg - 1) * pageSize;
            var data = Block.GetFullBlocks().Skip(recSkip).Take(pager.pageSize).ToList();
            this.ViewBag.Pager = pager;

            return View("Index", data);
        }

        public IActionResult Insert()
        {
            List<Building> list = Building.GetFullBD();
            this.ViewBag.ListBuilding = list;
            List<BlockType> listBT = BlockType.GetFullBlockTypes();
            List<Face> listFace = Face.GetFullFaces();
            this.ViewBag.ListFace = listFace;
            return View(listBT);
        }
        public IActionResult InsertB(Block Block, int IDF)
        {
            Block.InsertBlock(Block);
            int IDB = Block.GetFullBlocks().OrderByDescending(b => b.IDB).FirstOrDefault().IDB;
            FaceBlock.Insert(new FaceBlock
            {
                IDF = IDF,
                IDB = IDB,
            });
            return RedirectToAction("Index");
        }
    }
}
