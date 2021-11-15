using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
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

        // return a list of reports
        [HttpGet]
        public async Task<ActionResult<List<PostLabeling>>> GetReports(CancellationToken cancellationToken)
        {
            return await Mediator.Send(new GetReports.Query(), cancellationToken);
        }

        // find a report matching the specific id inputted
        [HttpGet("{id}")]
        public async Task<ActionResult<PostLabeling>> GetReport(Guid id)
        {
            return await Mediator.Send(new GetOneReport.Query{Id = id});
        }
        
        // creates a new report for post, with Rabat labels
        [HttpPost]
        public async Task<IActionResult> CreateReport(PostLabeling postLabeling)
        {
            return Ok(await Mediator.Send(new CreateReport.Command { PostLabeling = postLabeling }));
        }
        
        // updates a report
        [HttpPut("{id}")]
        public async Task<IActionResult> EditReport(Guid id, PostLabeling postLabeling)
        {
            postLabeling.Id = id;
            return Ok(await Mediator.Send(new EditReport.Command { PostLabeling = postLabeling }));
        }
        
        // delete a specific report
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteReport(Guid id)
        {
            return Ok(await Mediator.Send(new DeleteReport.Command { Id = id }));
        }
    }
}