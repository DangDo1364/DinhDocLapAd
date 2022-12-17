using DinhDocLapAdmin.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DinhDocLapAdmin.Controllers
{
    public class FaceNodeController : Controller
    {
        public IActionResult Index(int pg = 1)
        {
            const int pageSize = 20;
            if (pg < 1)
            {
                pg = 1;
            }
            int recsCount = FaceNode.GetFull().Count();
            var pager = new Pager(recsCount, pg, pageSize);
            int recSkip = (pg - 1) * pageSize;
            var data = FaceNode.GetFull().Skip(recSkip).Take(pager.pageSize).ToList();
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
            int recsCount = FaceNode.GetFull().Count();
            var pager = new Pager(recsCount, pg, pageSize);

            int recSkip = (pg - 1) * pageSize;
            var data = FaceNode.GetFull().Skip(recSkip).Take(pager.pageSize).ToList();
            this.ViewBag.Pager = pager;

            return View("Index", data);
        }
        public IActionResult Update(int IDF,int IDN)
        {
            List<FaceNode> list = FaceNode.GetFull();
            FaceNode Face = list.Find(n => n.IDF == IDF && n.IDN == IDN);

            return View(Face);
        }
        public IActionResult UpdateFace(int IDN, int IDF, int seq)
        {
            FaceNode.Update(new FaceNode
            {
                IDN = IDN,
                IDF = IDF,
                seq = seq,
            });
            return RedirectToAction("Index");
        }
    }
}
