using Connected;

namespace TestClient;

internal class Program
{
	static async Task Main(string[] args)
	{
		Application.RegisterMicroService("Connected.Customers.Service.Tickets.dll");

		await Application.StartDefaultApplication(args);
	}
}
