using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PharmVerse.Presentation.Invites.Commands;
using PharmVerse.Presentation.Invites.Models.Results;
using PharmVerse.Presentation.Invites.Queries;

namespace PharmVerse.Service.Controllers
{
     /// <summary>
     /// This handles all requests for invites
     /// </summary>
     [Route("[controller]"), ApiController, Authorize]
     public class InvitesController : ControllerBase
     {
          private readonly IMediator _mediator;
          private readonly IMapper _mapper;

          /// <summary>
          /// This handles all requests for invites
          /// </summary>
          /// <param name="mediator"></param>
          /// <param name="mapper"></param>
          public InvitesController(IMediator mediator, IMapper mapper)
          {
               _mediator = mediator;
               _mapper = mapper;
          }

          /// <summary>
          /// gets all invites in the system
          /// </summary>
          /// <returns></returns>
          [HttpGet, ProducesResponseType(typeof(IEnumerable<GetInviteQueryResult>), StatusCodes.Status200OK),
           ProducesDefaultResponseType]
          public async Task<IActionResult> GetInvites()
          {
               var invites = await _mediator.Send(new GetInvitesQuery());
               return Ok(invites);
          }

          /// <summary>
          ///  gets a single invite by ID
          /// </summary>
          /// <param name="inviteId"></param>
          /// <returns></returns>
          [HttpGet("{inviteId}", Name = "GetInvite"),
           ProducesResponseType(typeof(GetInviteQueryResult), StatusCodes.Status200OK), ProducesDefaultResponseType]
          public async Task<IActionResult> GetInvite(Guid inviteId)
          {
               var invite = await _mediator.Send(new GetInviteQuery {Id = inviteId});
               return Ok(invite);
          }


          /// <summary>
          /// creates a new invite
          /// </summary>
          /// <param name="command"></param>
          /// <returns></returns>
          [HttpPost(Name = "CreateInvite"),
           ProducesResponseType(typeof(GetInviteQueryResult), StatusCodes.Status201Created),
           ProducesDefaultResponseType]
          public async Task<IActionResult> CreateInvite([FromBody] CreateInviteCommand command)
          {
               var result = await _mediator.Send(command);
               var invite = _mapper.Map<GetInviteQuery>(result);
               return CreatedAtRoute("GetInvite", new {inviteid = result.Id}, invite);
          }

          /// <summary>
          /// updates an invite
          /// </summary>
          /// <param name="command"></param>
          /// <returns></returns>
          [HttpPut(Name = "UpdateInvite"),
           ProducesResponseType(typeof(GetInviteQueryResult), StatusCodes.Status201Created),
           ProducesDefaultResponseType]
          public async Task<IActionResult> UpdateInvite([FromBody] UpdateInviteCommand command)
          {
               var result = await _mediator.Send(command);
               var invite = _mapper.Map<GetInviteQuery>(result);
               return AcceptedAtRoute("GetInvite", new {inviteid = result.Id}, invite);
          }

          /// <summary>
          /// deletes single invite
          /// </summary>
          /// <param name="command"></param>
          /// <returns></returns>
          [HttpDelete(Name = "DeleteInvite"),
           ProducesResponseType(typeof(DeleteInviteCommandResult), StatusCodes.Status201Created),
           ProducesResponseType(typeof(string), StatusCodes.Status404NotFound), ProducesDefaultResponseType]
          public async Task<IActionResult> DeleteInvite([FromBody] DeleteInviteCommand command)
          {
               var result = await _mediator.Send(command);
               if (!result.IsDeleted)
               {
                    return NotFound($"{result.Message}");
               }

               return NoContent();
          }
     }
}