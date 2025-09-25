using Connected.Authentication;
using Connected.Authorization;
using Connected.Authorization.Entities;
using Connected.Membership;
using Connected.Membership.Claims;

namespace Connected.Customers.Service.Desks.Claims;

internal sealed class Claim(IAuthenticationService authentication, IClaimService claims)
	: EntityAuthorization<IClaim>
{
	protected override async Task<AuthorizationResult> OnInvoke()
	{
		if (!string.Equals(Entity.Entity, ServiceMetaData.DeskKey, StringComparison.OrdinalIgnoreCase))
			return await Task.FromResult(AuthorizationResult.Skip);

		if (!await (await authentication.SelectIdentity()).HasClaim(claims, DeskClaims.ReadDesk, ServiceMetaData.DeskKey, Entity.Id.ToString()))
			return await Task.FromResult(AuthorizationResult.Fail);

		return AuthorizationResult.Pass;
	}
}
