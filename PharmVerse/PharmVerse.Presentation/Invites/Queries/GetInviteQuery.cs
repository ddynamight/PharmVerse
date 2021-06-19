using MediatR;
using PharmVerse.Presentation.Invites.Models.Results;
using System;

namespace PharmVerse.Presentation.Invites.Queries
{
     public class GetInviteQuery : IRequest<GetInviteQueryResult>
     {
          public Guid Id { get; set; }
     }
}