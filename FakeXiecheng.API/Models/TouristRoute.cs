using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FakeXiecheng.API.Models
{
    public class TouristRoute
    {
        [Key]//表示为主键
        public Guid Id { get; set; }
        [Required]//表示不为空
        [MaxLength(100)]//长度限制
        public string Title { get; set; }
        [Required]
        [MaxLength(1500)]
        public string Description { get; set; }
        [Column(TypeName ="decimal(18,2)")]//添加限定
        public decimal OriginalPrice { get; set; }
        [Range(0.0,1.0)]
        public double? DiscountPresent { get; set; }
        public DateTime CreateTime { get; set; }
        public DateTime? UpdateTime { get; set; }
        public DateTime? DepartureTime { get; set; }
        [MaxLength]//最大长度的限制
        public string Features { get; set; }
        [MaxLength]
        public string Fees { get; set; }
        [MaxLength]
        public string Notes { get; set; }
        //一条旅游路线可以有多张旅游图片，为1对N关系
        public ICollection<TouristRoutePicture> TouristRoutePictures { get; set; } 
            = new List<TouristRoutePicture>();//这一步是为了让代码更健壮避免一些未知错误
    }
}
