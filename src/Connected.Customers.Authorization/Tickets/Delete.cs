using Connected.Annotations;
using Connected.Authentication;
using Connected.Authorization;
using Connected.Authorization.Services;
using Connected.Customers.Authorization.Desks;
using Connected.Customers.Tickets;
using Connected.Customers.Tickets.Dtos;
using Connected.Membership;
using Connected.Membership.Claims;

namespace Connected.Customers.Authorization.Tickets;

[Middleware<ITicketService>(nameof(ITicketService.Delete))]
internal sealed class Delete(IClaimService claims, IAuthenticationService authentication, ITicketService tickets)
	: BoundServiceOperationAuthorization<IUpdateTicketDto>
{
	public override string Entity => ServiceMetaData.DeskKey;
	public override string EntityId => ((ITicketDto)Dto).Head.ToString();

	protected override async Task<AuthorizationResult> OnInvoke()
	{
		var ticket = await tickets.Select(Dto);

		if (ticket is null)
			return AuthorizationResult.Skip;

		var identity = await authentication.SelectIdentity();
		/*
		 * Ticket moderator can delete any ticket.
		 */
		if (await identity.HasClaim(claims, DeskClaims.ModerateTickets, Entity, EntityId))
			return AuthorizationResult.Pass;

		return AuthorizationResult.Skip;
	}
}
