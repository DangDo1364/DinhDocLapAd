using DinhDocLapAdmin.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DinhDocLapAdmin.Controllers
{
    public class FaceController : Controller
    {
        public IActionResult Index(int pg = 1)
        {
            const int pageSize = 20;
            if (pg < 1)
            {
                pg = 1;
            }
            int recsCount = Face.GetFullFaces().Count();
            var pager = new Pager(recsCount, pg, pageSize);
            int recSkip = (pg - 1) * pageSize;
            var data = Face.GetFullFaces().Skip(recSkip).Take(pager.pageSize).ToList();
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
            int recsCount = Face.GetFullFaces().Count();
            var pager = new Pager(recsCount, pg, pageSize);

            int recSkip = (pg - 1) * pageSize;
            var data = Face.GetFullFaces().Skip(recSkip).Take(pager.pageSize).ToList();
            this.ViewBag.Pager = pager;

            return View("Index", data);
        }
        public IActionResult Insert()
        {
            return View();
        }
        public IActionResult InsertFace(Face Face, int IDNodeFrom, int IDNodeTo)
        {
            if(IDNodeFrom > Node.GetFullNodes().Count() || IDNodeTo > Node.GetFullNodes().Count())
            {
                return RedirectToAction("Index");
            }  
            else
            {
                Face.InsertFace(Face);
                int IDF = 0;
                IDF = Face.GetFullFaces().OrderByDescending(f => f.IDF).FirstOrDefault().IDF;
                if (IDF == 0)
                    return RedirectToAction("Index");
                int Count = 0;
                for(int i = IDNodeFrom; i <= IDNodeTo; i++)
                {
                    Count++;
                    FaceNode.Insert(new FaceNode { 
                        IDF = IDF,
                        IDN = i,
                        seq = Count                
                    });          
                }    
            }    
            return RedirectToAction("Index");
        }
        public IActionResult Update(int id)
        {
            List<Face> list = Face.GetFullFaces();
            Face f = list.Find(n => n.IDF == id);

            return View(f);
        }
        public IActionResult UpdateFace(int ID, Face Face)
        {
            Face.Update(new Face
            {
                IDF = ID,
                faceName = Face.faceName
            });
            return RedirectToAction("Index");
        }
    }
}
