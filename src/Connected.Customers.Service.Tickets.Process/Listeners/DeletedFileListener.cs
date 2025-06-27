using Connected.Annotations;
using Connected.Notifications;
using Connected.SaaS.Storage;
using Connected.SaaS.Storage.Dtos;
using Connected.Services;

namespace Connected.Customers.Service.Tickets.Listeners;

[Middleware<IFileService>(ServiceEvents.Deleted)]
internal sealed class DeletedFileListener(FileCountSynchronizer synchronizer)
	: EventListener<IDeleteFileDto>
{
	protected override async Task OnInvoke()
	{
		await synchronizer.Synchronize(Dto);
	}
}
