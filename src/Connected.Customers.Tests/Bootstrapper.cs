using Connected.Runtime;
using Microsoft.Extensions.DependencyInjection;

namespace Connected.Customers.Tests;

internal sealed class Bootstrapper : Startup
{
	protected override void OnConfigureServices(IServiceCollection services)
	{
		services.AddScoped<DeskTests>();
	}
}
