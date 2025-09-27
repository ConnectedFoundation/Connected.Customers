namespace Connected.Customers.Service.Desks.Claims;

//internal sealed class Claim(IAuthenticationService authentication, IClaimService claims)
//	: EntityAuthorization<IClaim>
//{
//	public override string Entity => typeof(IClaim).EntityKey();
//	public override string EntityId => Instance.Id.ToString();
//	protected override async Task<AuthorizationResult> OnInvoke()
//	{
//		if (!string.Equals(Instance.Entity, ServiceMetaData.DeskKey, StringComparison.OrdinalIgnoreCase))
//			return await Task.FromResult(AuthorizationResult.Skip);

//		if (!await (await authentication.SelectIdentity()).HasClaim(claims, DeskClaims.ReadDesk, ServiceMetaData.DeskKey, Instance.Id.ToString()))
//			return await Task.FromResult(AuthorizationResult.Fail);

//		return AuthorizationResult.Pass;
//	}
//}
