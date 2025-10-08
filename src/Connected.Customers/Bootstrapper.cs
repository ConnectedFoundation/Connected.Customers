using Connected.Customers.Agents;
using Connected.Runtime;
using Microsoft.Extensions.DependencyInjection;

namespace Connected.Customers;

internal sealed class Bootstrapper : Startup
{
	protected override void OnConfigureServices(IServiceCollection services)
	{
		services.AddScoped<FileCountSynchronizer>();
	}
}
