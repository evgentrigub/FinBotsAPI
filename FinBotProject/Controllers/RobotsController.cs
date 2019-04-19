﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApi.Entities;
using WebApi.Helpers;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class RobotsController : ControllerBase
    {
        /// <summary>
        /// //внедрение зависимостей для внедрения контекста бд
        /// </summary>
        private readonly DataContext _context;

        public RobotsController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IEnumerable<TradingBot> GetAllRobots()
        {
            try
            {
                var tradingsBots = _context.TradingBots.ToList();
                return tradingsBots;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpGet]
        public IEnumerable<TradingBot> GetUserRobots(int id)
        {
            try
            {
                var tradingsBots = _context.UsersBots.Where(r => r.User.Id == id).Select(r => r.TradingBot).ToList();
                return tradingsBots;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
