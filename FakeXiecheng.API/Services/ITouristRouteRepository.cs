using FakeXiecheng.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FakeXiecheng.API.Services
{
    public interface ITouristRouteRepository
    {
        //获得所有旅游路线的数据,返回TouristRoute列表
        IEnumerable<TouristRoute> GetTouristRoutes();
        //根据Id查询特定旅游路线
        TouristRoute GetTouristRoute(Guid touristRouteId);
    }
}
