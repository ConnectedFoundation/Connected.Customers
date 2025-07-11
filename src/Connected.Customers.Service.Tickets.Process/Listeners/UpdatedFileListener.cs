﻿using Connected.Annotations;
using Connected.Notifications;
using Connected.SaaS.Storage;
using Connected.SaaS.Storage.Dtos;
using Connected.Services;

namespace Connected.Customers.Service.Tickets.Listeners;

[Middleware<IFileService>(ServiceEvents.Updated)]
internal sealed class UpdatedFileListener(FileCountSynchronizer synchronizer)
	: EventListener<IUpdateFileDto>
{
	protected override async Task OnInvoke()
	{
		await synchronizer.Synchronize(Dto);
	}
}
