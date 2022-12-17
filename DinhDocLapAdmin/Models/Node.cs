using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DinhDocLapAdmin.Models
{
    public class Node
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IDN { get; set; }

        [Required]
        [Display(Name = "x")]
        public double x { get; set; }

        [Required]
        [Display(Name = "y")]
        public double y { get; set; }

        [Required]
        [Display(Name = "z")]
        public double z { get; set; }

        public ICollection<FaceNode> faceNodes { get; set; }

        public static List<Node> GetFullNodes()
        {
            List<Node> list = new List<Node>();
            using (var context = new MyDBContext())
            {
                var listNodes = context.nodes.ToList().OrderByDescending(n => n.IDN);

                foreach (var node in listNodes)
                {
                    list.Add(new Node()
                    {
                        IDN = node.IDN,
                        x = node.x,
                        y = node.y,
                        z = node.z
                    });
                }
            }
            return list;
        }
        public static void InsertNode(Node Node)
        {
            using (var context = new MyDBContext())
            {
                context.nodes.Add(new Node
                {
                   x = Node.x,
                   y = Node.y,
                   z = Node.z,
                });
                context.SaveChanges();
            }
        }
        public static void Update(Node Node)
        {
            using (var context = new MyDBContext())
            {
                var list = context.nodes;
                Node item = (from p in list
                                 where (p.IDN == Node.IDN)
                                 select p).FirstOrDefault();
                if (item != null)
                {
                    item.x = Node.x;
                    item.y = Node.y;
                    item.z = Node.z;
                    context.SaveChanges();
                }

            }
        }
    }
}
