using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DinhDocLapAdmin.Models
{
    public class FaceNode
    {
        [Display(Name = "Mã mặt phẳng")]
        public int IDF { get; set; }

        [Display(Name = "Mã node")]
        public int IDN { get; set; }

        [Display(Name = "Thứ tự")]
        public int seq { get; set; }

        public Face face { get; set; }
        public Node node { get; set; }

        public static List<FaceNode> GetFull()
        {
            List<FaceNode> list = new List<FaceNode>();
            using (var context = new MyDBContext())
            {
                var listItem = context.faceNodes.ToList().OrderByDescending(b => b.IDF);

                foreach (var item in listItem)
                {
                    list.Add(new FaceNode()
                    {
                        IDF = item.IDF,
                        IDN = item.IDN,
                        seq = item.seq
                    });
                }
            }
            return list;
        }
        public static void Insert(FaceNode FaceNode)
        {
            using (var context = new MyDBContext())
            {
                context.faceNodes.Add(new FaceNode
                {
                    IDF = FaceNode.IDF,
                    IDN = FaceNode.IDN,
                    seq = FaceNode.seq,
                });
                context.SaveChanges();
            }
        }
        public static void Update(FaceNode FaceNode)
        {
            using (var context = new MyDBContext())
            {
                var list = context.faceNodes;
                FaceNode item = (from p in list
                             where (p.IDF == FaceNode.IDF && p.IDN == FaceNode.IDN)
                             select p).FirstOrDefault();

                if (item != null)
                {
                    item.IDF = FaceNode.IDF;
                    item.IDN = FaceNode.IDN;
                    item.seq = FaceNode.seq;
                    context.SaveChanges();
                }
            }
        }
    }
}
