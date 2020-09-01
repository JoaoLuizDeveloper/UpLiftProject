﻿using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UpLiftCurse.DataAccess.Data;
using UpLiftCurse.Models;
using UpLiftCurse.Utility;

namespace UpLiftCurse.AccessData.Data.Initializer
{
    public class DbInitializer : IDbInitializer
    {
        private readonly ApplicationDbContext _db;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public DbInitializer(ApplicationDbContext db, UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _db = db;
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public void Initialize()
        {
            try
            {
                if(_db.Database.GetPendingMigrations().Count() > 0)
                {
                    _db.Database.Migrate();
                }
            }
            catch(Exception e)
            {

            }

            if (_db.Roles.Any(r => r.Name == SD.Admin)) return;

            _roleManager.CreateAsync(new IdentityRole(SD.Admin)).GetAwaiter().GetResult();
            _roleManager.CreateAsync(new IdentityRole(SD.Manager)).GetAwaiter().GetResult();

            _userManager.CreateAsync(new Usuario
            {
                UserName = "joaoluizdeveloper@gmail.com",
                Email = "joaoluizdeveloper@gmail.com",
                EmailConfirmed = true,
                Name = "joão Luiz"
            }, "Admin123*").GetAwaiter().GetResult();

            Usuario user = _db.Usuarios.Where(x => x.Email == "joaoluizdeveloper@gmail.com").FirstOrDefault();
            _userManager.AddToRoleAsync(user, SD.Admin).GetAwaiter().GetResult();
        }
    }
}
