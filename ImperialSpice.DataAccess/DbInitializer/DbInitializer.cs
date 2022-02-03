﻿using ImperialSpice.DataAccess.Data;
using ImperialSpice.Models;
using ImperialSpice.Utility;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImperialSpice.DataAccess.DbInitializer
{
    public class DbInitializer : IDbInitializer
    {
        private readonly ApplicationDbContext _db;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public DbInitializer(ApplicationDbContext db,
            UserManager<IdentityUser> userManager,
            RoleManager<IdentityRole> roleManager)
        {
            _db = db;
            _roleManager = roleManager;
            _userManager = userManager;
        }
        public void Initialize()
        {
            try
            {
                if (_db.Database.GetPendingMigrations().Count() > 0)
                {
                    _db.Database.Migrate();
                }
            }
            catch (Exception)
            {

            }

            if (!_roleManager.RoleExistsAsync(SD.KitchenRole).GetAwaiter().GetResult())
            {
                _roleManager.CreateAsync(new IdentityRole(SD.KitchenRole)).GetAwaiter().GetResult();
                _roleManager.CreateAsync(new IdentityRole(SD.ManagerRole)).GetAwaiter().GetResult();
                _roleManager.CreateAsync(new IdentityRole(SD.FrontDeskRole)).GetAwaiter().GetResult();
                _roleManager.CreateAsync(new IdentityRole(SD.CustomerRole)).GetAwaiter().GetResult();

                _userManager.CreateAsync(new ApplicationUser
                {
                    UserName = "admin@imperialspice.com",
                    Email = "admin@imperialspice.com",
                    EmailConfirmed = true,
                    FirstName = "Admin",
                    LastName = "User"
                }, "Admin@123").GetAwaiter().GetResult();

                ApplicationUser user = _db.ApplicationUser.FirstOrDefault(u => u.Email == "admin@imperialspice.com");

                _userManager.AddToRoleAsync(user, SD.ManagerRole).GetAwaiter().GetResult();
            }
            return;
        }
    }
}
