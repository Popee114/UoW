using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Teaching.Models;
using Teaching.Serivecs.Interfaces;

namespace Teaching.Controllers
{
    [Route("api/")]
    [ApiController]
    public class AccountController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public AccountController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet("all/User")]
        public async Task<List<User>> GetUsersAsync()
        {
            return await _unitOfWork.UserRepository.GetEntityList();
        }

        [HttpGet("all/Cars")]
        public async Task<List<Car>> GetCarsAsync()
        {
            return await _unitOfWork.CarRepository.GetEntityList();
        }
    }
}