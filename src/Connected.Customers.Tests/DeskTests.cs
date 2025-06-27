using Connected.Authentication;
using Connected.Customers.Service.Desks;
using Connected.Customers.Service.Desks.Dtos;
using Connected.Identities;
using Connected.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Connected.Customers.Tests;

public sealed class DeskTests(IDeskService desks, IAuthenticationService authentication, IUserService users)
{
	public static async Task Run()
	{
		using var scope = Scope.Create();

		var service = scope.ServiceProvider.GetRequiredService<DeskTests>();

		await service.Invoke();
	}

	private async Task Invoke()
	{
		await Authenticate();

		var dto = Dto.Factory.Create<IInsertDeskDto>();

		dto.Status = Entities.Status.Enabled;
		dto.Name = "Desk 1";

		var id = await desks.Insert(dto);
	}

	private async Task Authenticate()
	{
		var dto = Dto.Factory.Create<IUpdateIdentityDto>();

		dto.Identity = new TestIdentity
		{
			Token = "abcd"
		};

		await authentication.UpdateIdentity(dto);
	}
}
