using FypProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FypProject.Services
{
    public class StoreService
    {
        private readonly ApplicationDbContext _db;

        public StoreService() : this(new ApplicationDbContext()) { }
        public StoreService(ApplicationDbContext context)
        {
            _db = context;
        }
    }
}