using Connected.Annotations;
using Connected.Authentication;
using Connected.Authorization;
using Connected.Authorization.Services;
using Connected.Customers.Authorization.Desks;
using Connected.Customers.Tickets;
using Connected.Customers.Tickets.Dtos;
using Connected.Customers.Tickets.Text;
using Connected.Entities;
using Connected.Membership;
using Connected.Membership.Claims;

namespace Connected.Customers.Authorization.TicketTexts;

[Middleware<ITicketTextService>(nameof(ITicketTextService.Update))]
internal sealed class Update(IClaimService claims, IAuthenticationService authentication, ITicketService tickets)
	: BoundServiceOperationAuthorization<IUpdateTicketDto>
{
	public override string Entity => typeof(ITicket).EntityKey();
	public override string EntityId => Dto.Id.ToString();

	protected override async Task<AuthorizationResult> OnInvoke()
	{
		var ticket = await tickets.Select(Dto);

		if (ticket is null)
			return AuthorizationResult.Skip;

		var identity = await authentication.SelectIdentity();

		if (await identity.HasClaim(claims, DeskClaims.ModerateTickets, Entity, EntityId))
			return AuthorizationResult.Pass;

		if (string.Equals(identity?.Token, ticket.Author, StringComparison.Ordinal))
			return AuthorizationResult.Pass;

		if (string.Equals(identity?.Token, ticket.Owner, StringComparison.Ordinal))
			return AuthorizationResult.Pass;

		return AuthorizationResult.Skip;
	}
}
