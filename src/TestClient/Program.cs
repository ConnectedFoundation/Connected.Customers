using Connected;
using Connected.Customers.Tests;

Application.RegisterMicroService("Connected.Customers.Service.Desks.dll");
Application.RegisterMicroService("Connected.Customers.Service.Tickets.dll");
Application.RegisterMicroService("Connected.Customers.Tests.dll");

var thread = new Thread(new ThreadStart(async () =>
{
	while (!Application.HasStarted)
		Thread.Sleep(500);

	await DeskTests.Run();
}));

thread.Start();

await Application.StartDefaultApplication(args);