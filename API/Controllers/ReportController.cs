using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Services;
using API.DTO;
using API.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace API.Controllers
{
    public class ReportController: ControllerBase
    {
        private readonly ILogger<UserController> _logger;
        private readonly ReportService _reportService;

        public ReportController(ReportService reportService, ILogger<UserController> logger)
        {
            _logger = logger;
            _reportService = reportService;
        }

        //get report by user id
        [HttpGet("api/Report/user/{userId}")]
        public async Task<List<ReportDTO>> Get(int userId)
        {
            //get all reports from the database
            return await _reportService.GetReportByUserIdAsync(userId);
        }
    }
}