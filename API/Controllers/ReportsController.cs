using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Events;
using Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace API.Controllers
{
    public class ReportsController : BaseApiController
    {
        private readonly MeekinFirewatchContext _context;

        public ReportsController(MeekinFirewatchContext context)
        {
            _context = context;
        }

        // return a list of reports
        [HttpGet]
        public async Task<ActionResult<List<PostLabeling>>> GetReports()
        {
            return await _context.PostLabelings.ToListAsync();
        }

        // find a report matching the specific id inputted
        [HttpGet("{id}")]
        public async Task<ActionResult<PostLabeling>> GetReport(Guid id)
        {
            return await _context.PostLabelings.FindAsync(id);
        }
    }
}