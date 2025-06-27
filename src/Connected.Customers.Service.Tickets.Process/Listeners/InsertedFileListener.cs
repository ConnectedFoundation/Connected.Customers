using Connected.Annotations;
using Connected.Notifications;
using Connected.SaaS.Storage;
using Connected.SaaS.Storage.Dtos;
using Connected.Services;

namespace Connected.Customers.Service.Tickets.Listeners;

[Middleware<IFileService>(ServiceEvents.Inserted)]
internal sealed class InsertedFileListener(FileCountSynchronizer synchronizer)
	: EventListener<IInsertFileDto>
{
	protected override async Task OnInvoke()
	{
		await synchronizer.Synchronize(Dto);
	}
}
