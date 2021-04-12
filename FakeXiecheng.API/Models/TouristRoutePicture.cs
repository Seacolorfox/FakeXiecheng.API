using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FakeXiecheng.API.Models
{
    public class TouristRoutePicture
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]//让数据库自增
        public int Id { get; set; }
        [MaxLength(100)]
        public string  Url { get; set; }
        [ForeignKey("TouristRouteId")]//与旅游路线的外键关系,Entity Framework 在映射数据库时会自动把每个模型的主键自动以类名加ID的形式做外键关联
        public Guid TouristRouteId { get; set; }
        //连接属性
        public TouristRoute TouristRoute { get; set; }
    }
}
