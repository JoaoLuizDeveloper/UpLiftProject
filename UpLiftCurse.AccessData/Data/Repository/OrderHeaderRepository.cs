﻿using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UpLiftCurse.AccessData.Data.Repository.IRepository;
using UpLiftCurse.DataAccess.Data;
using UpLiftCurse.Models;

namespace UpLiftCurse.AccessData.Data.Repository
{
    public class OrderHeaderRepository : Repository<OrderHeader> , IOrderHeaderRepository
    {
        private readonly ApplicationDbContext _db;

        public OrderHeaderRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void ChangeOrderStatus(int orderheaderId, string status)
        {
            var orderFromDb = _db.OrderHeader.FirstOrDefault(o => o.Id == orderheaderId);
            orderFromDb.Status = status;
            _db.SaveChanges();
        }
    }
}
