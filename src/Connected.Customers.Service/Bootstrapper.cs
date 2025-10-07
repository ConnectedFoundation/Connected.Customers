using Connected.Runtime;
using Microsoft.Extensions.DependencyInjection;

namespace Connected.Customers.Service.Tickets;

internal sealed class Bootstrapper : Startup
{
	protected override void OnConfigureServices(IServiceCollection services)
	{
		services.AddScoped<FileCountSynchronizer>();
	}
}
