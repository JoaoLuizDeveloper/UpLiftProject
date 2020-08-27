﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using UpLiftCurse.AccessData.Data.Repository.IRepository;
using UpLiftCurse.Extensions;
using UpLiftCurse.Models;
using UpLiftCurse.Models.ViewModels;
using UpLiftCurse.Utility;

namespace UpLiftCurse.Areas.Customer.Controllers
{
    [Area("Customer")]
    public class CartController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        [BindProperty]
        private CartVM CartVM { get; set; }

        public CartController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            CartVM = new CartVM()
            {
                OrderHeader = new Models.OrderHeader(),
                ServiceList = new List<Service>(),
            };
        }

        public IActionResult Index()
        {
            if(HttpContext.Session.Getobject<List<int>>(SD.SessionCart) != null)
            {
                List<int> sessionList = new List<int>();
                sessionList = HttpContext.Session.Getobject<List<int>>(SD.SessionCart);
                foreach (int serviceId in sessionList)
                {
                    CartVM.ServiceList.Add(_unitOfWork.Service.GetFirstOrDefault(u => u.Id == serviceId, includeProperties: "Frequency,Category"));

                }

            }
            return View(CartVM);
        }
    }
}