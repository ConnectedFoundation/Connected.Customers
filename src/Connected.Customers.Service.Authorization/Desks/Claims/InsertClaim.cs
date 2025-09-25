using Connected.Annotations;
using Connected.Authentication;
using Connected.Authorization;
using Connected.Authorization.Services;
using Connected.Membership;
using Connected.Membership.Claims;
using Connected.Membership.Claims.Dtos;

namespace Connected.Customers.Service.Desks.Claims;

[Middleware<IClaimService>(nameof(IClaimService.Insert))]
internal sealed class InsertClaim(IClaimService claims, IAuthenticationService authentication) : ServiceOperationAuthorization<IInsertClaimDto>
{
	protected override async Task<AuthorizationResult> OnInvoke()
	{
		if (Dto is null)
			return AuthorizationResult.Skip;

		if (!string.Equals(Dto.Entity, ServiceMetaData.DeskKey, StringComparison.OrdinalIgnoreCase))
			return AuthorizationResult.Skip;

		if (!await (await authentication.SelectIdentity()).HasClaim(claims, DeskClaims.DeskSecurity))
			return AuthorizationResult.Fail;

		return AuthorizationResult.Pass;
	}
}
