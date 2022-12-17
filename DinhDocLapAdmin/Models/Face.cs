using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DinhDocLapAdmin.Models
{
    public class Face
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IDF { get; set; }

        [Required]
        [Display(Name = "Tên mặt")]
        public string faceName { get; set; }
            
        public ICollection<FaceNode> faceNodes { get; set; }
        public ICollection<FaceBlock> faceBlocks { get; set; }

        public static List<Face> GetFullFaces()
        {
            List<Face> list = new List<Face>();
            using (var context = new MyDBContext())
            {
                var listFaces = context.faces.ToList().OrderByDescending(f=>f.IDF);

                foreach (var face in listFaces)
                {
                    list.Add(new Face()
                    {
                       IDF = face.IDF,
                       faceName = face.faceName
                    });
                }
            }
            return list;
        }
        public static void InsertFace(Face Face)
        {
            using (var context = new MyDBContext())
            {
                context.faces.Add(new Face
                {
                    faceName = Face.faceName
                });
                context.SaveChanges();
            }
        }
        public static void Update(Face Face)
        {
            using (var context = new MyDBContext())
            {
                var list = context.faces;
                Face item = (from p in list
                             where (p.IDF == Face.IDF)
                             select p).FirstOrDefault();

                if (item != null)
                {
                    item.faceName = Face.faceName;
                    context.SaveChanges();
                }

            }
        }
    }
}
