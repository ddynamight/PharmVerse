using MediatR;
using PharmVerse.Presentation.Invites.Models.Results;
using System.Collections.Generic;

namespace PharmVerse.Presentation.Invites.Queries
{
     public class GetInvitesQuery : IRequest<IEnumerable<GetInviteQueryResult>>
     {
     }
}
