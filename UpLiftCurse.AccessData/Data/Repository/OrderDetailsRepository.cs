using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UpLiftCurse.AccessData.Data.Repository.IRepository;
using UpLiftCurse.DataAccess.Data;
using UpLiftCurse.Models;

namespace UpLiftCurse.AccessData.Data.Repository
{
    public class OrderDetailsRepository : Repository<OrderDetails> , IOrderDetailsRepository
    {
        private readonly ApplicationDbContext _db;

        public OrderDetailsRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;

        }

    }
}
