using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using eRestoran.Contracts.Requests;
using eRestoran.Contracts.Responses;
using eRestoran.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace eRestoran.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnalyticsController : ControllerBase
    {
        private readonly IAnalyticsService _service;

        public AnalyticsController(IAnalyticsService service)
        {
            _service = service;
        }

        [HttpGet("OrdersByMonth")]
        [AllowAnonymous]
        public async Task<ActionResult<OrdersByMonthResponse>> Get()
        {
            return await _service.GetOrdersByMonth(null);
        }

        [HttpGet("OrdersByMonth/{year}")]
        [AllowAnonymous]
        public async Task<ActionResult<OrdersByMonthResponse>> Get(int year)
        {
            return await _service.GetOrdersByMonth(year);
        }
        [HttpGet("ProfitByMonth")]
        [AllowAnonymous]
        public async Task<ActionResult<OrdersByMonthResponse>> GetProfit()
        {
            return await _service.GetOrdersByMonth(null);
        }

        [HttpGet("ProfitByMonth/{year}")]
        [AllowAnonymous]
        public async Task<ActionResult<OrdersByMonthResponse>> GetProfit(int year)
        {
            return await _service.GetOrdersByMonth(year);
        }


    }
}
