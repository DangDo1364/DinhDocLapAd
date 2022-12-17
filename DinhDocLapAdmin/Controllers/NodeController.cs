using DinhDocLapAdmin.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DinhDocLapAdmin.Controllers
{
    public class NodeController : Controller
    {
        public IActionResult Index(int pg = 1)
        {
            const int pageSize = 40;
            if (pg < 1)
            {
                pg = 1;
            }
            int recsCount = Node.GetFullNodes().Count();
            var pager = new Pager(recsCount, pg, pageSize);
            int recSkip = (pg - 1) * pageSize;
            var data = Node.GetFullNodes().Skip(recSkip).Take(pager.pageSize).ToList();
            this.ViewBag.Pager = pager;

            return View(data);
        }
        public IActionResult Pagination(int pg)
        {
            const int pageSize = 40;
            if (pg < 1)
            {
                pg = 1;
            }
            int recsCount = Node.GetFullNodes().Count();
            var pager = new Pager(recsCount, pg, pageSize);

            int recSkip = (pg - 1) * pageSize;
            var data = Node.GetFullNodes().Skip(recSkip).Take(pager.pageSize).ToList();
            this.ViewBag.Pager = pager;

            return View("Index",data);
        }
        //public IActionResult Search(int search, int pg = 1)
        //{
        //    const int pageSize = 5;
        //    if (pg < 1)
        //    {
        //        pg = 1;
        //    }
        //    int recsCount = Node.GetFullNodes().Count();
        //    var pager = new Pager(recsCount, pg, pageSize);
        //    int recSkip = (pg - 1) * pageSize;
        //    var data = Category.FindCatChildByIDParent(search).Skip(recSkip).Take(pager.pageSize).ToList();
        //    this.ViewBag.Pager = pager;
        //    this.ViewBag.search = search;

        //    return View("Index", data);
        //}
        public IActionResult Insert()
        {
            return View();
        }
        public IActionResult InsertNode(Node Node)
        {
            Node.InsertNode(Node);
            return RedirectToAction("Index");
        }
        public IActionResult Update(int id)
        {
            List<Node> list = Node.GetFullNodes();
            Node n = list.Find(n => n.IDN == id);

            return View(n);
        }
        public IActionResult UpdateNode(int IDN, Node Node)
        {
            Node.Update(new Node { 
                IDN = IDN,
                x = Node.x,
                y = Node.y,
                z = Node.z,
            });
            return RedirectToAction("Index");
        }
    }
}
