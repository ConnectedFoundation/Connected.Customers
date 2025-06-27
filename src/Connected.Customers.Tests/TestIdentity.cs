using Connected.Identities;

namespace Connected.Customers.Tests;

internal sealed record TestIdentity : IIdentity
{
	public required string Token { get; init; }
}
