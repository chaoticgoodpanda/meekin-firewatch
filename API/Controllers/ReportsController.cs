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
        
        // get a list of reports matching a platformId (because multiple users can write multiple reports for multiple posts)
        [HttpGet("getReportsOnePost/{postGuidId}")]
        public async Task<ActionResult<List<PostLabeling>>> GetReportsForOnePost(Guid postGuidId, CancellationToken cancellationToken)
        {
            return await Mediator.Send(new GetReportsForOnePost.Query{PostGuidId = postGuidId}, cancellationToken); 
        }


        // find a report matching the specific id inputted
        [HttpGet("{id}")]
        // IActionResult returns HTTP responses instead of the type of thing
        public async Task<IActionResult> GetReport(Guid id)
        {
            return HandleResult(await Mediator.Send(new GetOneReport.Query{Id = id}));
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