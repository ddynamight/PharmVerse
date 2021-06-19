using AutoMapper;
using MediatR;
using PharmVerse.Application.Interfaces.Persistence;
using PharmVerse.Domain.Events.Invites;
using PharmVerse.Domain.Invites;
using PharmVerse.Presentation.Invites.Commands;
using PharmVerse.Presentation.Invites.Models.Results;
using System;
using System.Threading;
using System.Threading.Tasks;
using PharmVerse.Common.Extensions;

namespace PharmVerse.Presentation.Invites.Handlers.Commands
{
     public class CreateInviteCommandHandler : IRequestHandler<CreateInviteCommand, CreateInviteCommandResult>
     {
          private readonly IAppDbContext _context;
          private readonly IMapper _mapper;
          private readonly IMediator _mediator;

          public CreateInviteCommandHandler(IAppDbContext context, IMapper mapper, IMediator mediator)
          {
               _context = context;
               _mapper = mapper;
               _mediator = mediator;
          }

          public async Task<CreateInviteCommandResult> Handle(CreateInviteCommand request, CancellationToken cancellationToken)
          {
               var invite = _mapper.Map<Invite>(request);
               invite.Date = DateTime.Now;

               invite.AddDomainEvent(new InviteCreatedEvent(invite));
               await _context.Invites.AddAsync(invite, cancellationToken);
               await _context.SaveChangesAsync(cancellationToken);
               await _mediator.Publish(new InviteCreatedEvent(invite), cancellationToken);

               return _mapper.Map(invite, new CreateInviteCommandResult());
          }
     }
}