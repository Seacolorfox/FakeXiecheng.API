using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FakeXiecheng.API.Models
{
    public class TouristRoutePicture
    {
        public int Id { get; set; }
        public string  Url { get; set; }
        //与旅游路线的外键关系
        public Guid TouristRouteId { get; set; }
        //连接属性
        public TouristRoute TouristRoute { get; set; }
    }
}
