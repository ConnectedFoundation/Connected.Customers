using Connected.Annotations;
using Connected.Authentication;
using Connected.Authorization;
using Connected.Authorization.Services;
using Connected.Membership;
using Connected.Membership.Claims;
using Connected.Services;

namespace Connected.Customers.Service.Desks.Claims;

[Middleware<IClaimService>(nameof(IClaimService.Delete))]
internal sealed class DeleteClaim(IClaimService claims, IAuthenticationService authentication)
	: ServiceOperationAuthorization<IPrimaryKeyDto<long>>
{
	protected override async Task<AuthorizationResult> OnInvoke()
	{
		if (Dto is null)
			return AuthorizationResult.Skip;

		var claim = await claims.Select(Dto);

		if (claim is null)
			return AuthorizationResult.Skip;

		if (!string.Equals(claim.Entity, ServiceMetaData.DeskKey, StringComparison.OrdinalIgnoreCase))
			return AuthorizationResult.Skip;

		if (!await (await authentication.SelectIdentity()).HasClaim(claims, DeskClaims.DeskSecurity, ServiceMetaData.DeskKey, Dto.Id.ToString()))
			return AuthorizationResult.Fail;

		return AuthorizationResult.Pass;
	}
}
