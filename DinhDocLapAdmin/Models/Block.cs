using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DinhDocLapAdmin.Models
{
    public class Block
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IDB { get; set; }

        [Required]
        [Display(Name = "Mã loại khối")]
        public int IDBT { get; set; }

        [Required]
        [Display(Name = "Mô tả")]
        public string blockDesc { get; set; }

        [Required]
        [Display(Name = "Mã tòa nhà")]
        public int IDBD { get; set; }

        [ForeignKey("IDBD")]
        public Building building { get; set; }

        [ForeignKey("IDBT")]
        public BlockType blockType { get; set; }

        public ICollection<FaceBlock> faceBlocks { get; set; }

        public static List<Block> GetFullBlocks()
        {
            List<Block> list = new List<Block>();
            using (var context = new MyDBContext())
            {
                var listBlocks = context.blocks.ToList().OrderByDescending(b => b.IDB);

                foreach (var item in listBlocks)
                {
                    list.Add(new Block()
                    {
                        IDB = item.IDB,
                        blockDesc = item.blockDesc,
                        IDBT = item.IDBT,
                        IDBD = item.IDBD,
                    });
                }
            }
            return list;
        }
        public static void InsertBlock(Block block)
        {
            using (var context = new MyDBContext())
            {
                context.blocks.Add(new Block
                {
                    IDBT = block.IDBT,
                    blockDesc = block.blockDesc,
                    IDBD = block.IDBD 
                });
                context.SaveChanges();
            }
        }
        public static void Update(Block Block)
        {
            using (var context = new MyDBContext())
            {
                var list = context.blocks;
                Block item = (from p in list
                             where (p.IDB == Block.IDB)
                             select p).FirstOrDefault();
                if (item != null)
                {
                    item.IDBD = Block.IDB;
                    item.IDBT = Block.IDBT;
                    item.blockDesc = Block.blockDesc;
                    context.SaveChanges();
                }

            }
        }
    }
}
