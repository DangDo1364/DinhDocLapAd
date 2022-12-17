using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DinhDocLapAdmin.Models
{
    public class FaceBlock
    {

        [Display(Name = "Mã mặt phẳng")]
        public int IDF { get; set; }

        [Display(Name = "Mã khối")]
        public int IDB { get; set; }

        public Face face { get; set; }
        public Block block { get; set; }

        public static List<FaceBlock> GetFull()
        {
            List<FaceBlock> list = new List<FaceBlock>();
            using (var context = new MyDBContext())
            {
                var listItem = context.faceBlocks.ToList().OrderByDescending(b => b.IDB);

                foreach (var item in listItem)
                {
                    list.Add(new FaceBlock()
                    {
                        IDB = item.IDB,
                        IDF = item.IDF,                     
                    });
                }
            }
            return list;
        }
        public static void Insert(FaceBlock FaceBlock)
        {
            using (var context = new MyDBContext())
            {
                context.faceBlocks.Add(new FaceBlock
                {
                    IDF = FaceBlock.IDF,
                    IDB = FaceBlock.IDB
                });
                context.SaveChanges();
            }
        }
        public static void Update(FaceBlock FaceBlock)
        {
            using (var context = new MyDBContext())
            {
                var list = context.faceBlocks;
                FaceBlock item = (from p in list
                                 where (p.IDF == FaceBlock.IDF && p.IDB == FaceBlock.IDB)
                                 select p).FirstOrDefault();

                if (item != null)
                {
                    item.IDF = FaceBlock.IDF;
                    item.IDB = FaceBlock.IDB;
                    context.SaveChanges();
                }
            }
        }
    }
}
