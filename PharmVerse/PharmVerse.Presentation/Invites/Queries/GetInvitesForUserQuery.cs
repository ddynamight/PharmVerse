using MediatR;
using PharmVerse.Presentation.Invites.Models.Results;
using System.Collections.Generic;

namespace PharmVerse.Presentation.Invites.Queries
{
     public class GetInvitesForUserQuery : IRequest<IEnumerable<GetInviteQueryResult>>
     {
          public string AppUserId { get; set; }
     }
}