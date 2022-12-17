using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DinhDocLapAdmin.Models
{
    public class BlockType
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IDBT { get; set; }

        [Required]
        [Display(Name = "Tên chi tiết")]
        public string blockName { get; set; }

        [Required]
        [Display(Name = "Màu khối")]
        public string color { get; set; }

        [Required]
        [Display(Name = "Màu cạnh")]
        public string colorEdge { get; set; }

        [Required]
        [Display(Name = "Chiều cao")]
        public double height { get; set; }

        public ICollection<Block> blocks { get; set; }

        public static List<BlockType> GetFullBlockTypes()
        {
            List<BlockType> list = new List<BlockType>();
            using (var context = new MyDBContext())
            {
                var listBlockTypes = context.blockTypes.ToList().OrderByDescending(bt => bt.IDBT);

                foreach (var item in listBlockTypes)
                {
                    list.Add(new BlockType()
                    {
                        IDBT = item.IDBT,
                        blockName = item.blockName,
                        color = item.color,
                        colorEdge = item.colorEdge,
                        height = item.height,
                    });
                }
            }
            return list;
        }
        public static void InsertBlockType(BlockType blockType)
        {
            using (var context = new MyDBContext())
            {
                context.blockTypes.Add(new BlockType
                {
                    blockName = blockType.blockName,
                    color = blockType.color,
                    colorEdge = "0",
                    height = blockType.height
                });
                context.SaveChanges();
            }
        }
    }
}
