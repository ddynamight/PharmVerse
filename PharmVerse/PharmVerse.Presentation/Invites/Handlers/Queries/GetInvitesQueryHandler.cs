﻿using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using PharmVerse.Application.Interfaces.Persistence;
using PharmVerse.Domain.Events.Invites;
using PharmVerse.Presentation.Invites.Models.Results;
using PharmVerse.Presentation.Invites.Queries;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace PharmVerse.Presentation.Invites.Handlers.Queries
{
     public class GetInvitesQueryHandler : IRequestHandler<GetInvitesQuery, IEnumerable<GetInviteQueryResult>>
     {
          private readonly IAppDbContext _context;
          private readonly IMapper _mapper;
          private readonly IMediator _mediator;

          public GetInvitesQueryHandler(IAppDbContext context, IMapper mapper, IMediator mediator)
          {
               _context = context;
               _mapper = mapper;
               _mediator = mediator;
          }

          public async Task<IEnumerable<GetInviteQueryResult>> Handle(GetInvitesQuery request, CancellationToken cancellationToken)
          {
               var invites = await _context.Invites.ToListAsync(cancellationToken);
               await _mediator.Publish(new AllInviteAccessedEvent(invites), cancellationToken);
               return _mapper.Map<IEnumerable<GetInviteQueryResult>>(invites);
          }
     }
}