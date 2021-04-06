using FakeXiecheng.API.Database;
using FakeXiecheng.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FakeXiecheng.API.Services
{
    public class TouristRouteRepository :ITouristRouteRepository
    {
        //使用数据库连接器连接数据库
        private readonly AppDbContext _context;
        
        public TouristRouteRepository(AppDbContext context)
        {
            //将参数注入的AppDbContext对象赋值给定义的私有变量_context
            _context = context;
        }

        public TouristRoute GetTouristRoute(Guid touristRouteId)
        {
            return _context.TouristRoutes.FirstOrDefault(n => n.Id == touristRouteId);
        }

        public IEnumerable<TouristRoute> GetTouristRoutes()
        {
            return _context.TouristRoutes;
        }
    }
}
