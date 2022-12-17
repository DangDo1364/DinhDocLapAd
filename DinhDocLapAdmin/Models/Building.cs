using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DinhDocLapAdmin.Models
{
    public class Building
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IDBD { get; set; }

        [Required]
        [Display(Name = "Tên tòa nhà")]
        public string buildingName { get; set; }

        [Required]
        [Display(Name = "Địa chỉ tòa nhà")]
        public string address { get; set; }

        [Required]
        [Display(Name = "Mô tả")]
        public string buildingDesc { get; set; }

        public ICollection<Block> blocks { get; set; }

        public static List<Building> GetFullBD()
        {
            List<Building> list = new List<Building>();
            using (var context = new MyDBContext())
            {
                var listBuildings = context.buildings.ToList();

                foreach (var item in listBuildings)
                {
                    list.Add(new Building()
                    {
                        IDBD = item.IDBD,
                        buildingName = item.buildingName,
                        address = item.address,
                        buildingDesc = item.buildingDesc,
                    });
                }
            }
            return list;
        }
        public static void InsertBuilding(Building Building)
        {
            using (var context = new MyDBContext())
            {
                context.buildings.Add(new Building
                {
                   buildingName = Building.buildingName,
                   address = Building.address,
                   buildingDesc = Building.buildingDesc
                });
                context.SaveChanges();
            }
        }
    }
}
