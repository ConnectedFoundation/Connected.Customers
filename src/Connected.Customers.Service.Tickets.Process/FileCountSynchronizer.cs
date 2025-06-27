using Connected.Customers.Service.Tickets.Dtos;
using Connected.SaaS.Storage;
using Connected.SaaS.Storage.Dtos;
using Connected.Services;

namespace Connected.Customers.Service.Tickets;

internal sealed class FileCountSynchronizer(ITicketService tickets, IFileService files)
{
	public async Task Synchronize(IFileDto dto)
	{
		if (dto.Directory is null)
			return;

		if (!dto.IsTicketDirectory())
			return;

		var ticket = await tickets.ResolveTicket(dto.Directory);

		if (ticket is null)
			return;

		var directoryDto = dto.Create<IDirectoryDto>();

		directoryDto.Path = dto.Directory;

		var fileSet = await files.Query(directoryDto);
		var props = new Dictionary<string, object?>
		{
			{ nameof(IUpdateTicketDto.FileCount), fileSet.Count }
		};

		var patchDto = dto.CreateDependentPatch(ticket.Head, ticket.Id, props);

		await tickets.Patch(patchDto);
	}
}
