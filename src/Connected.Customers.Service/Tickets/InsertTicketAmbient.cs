using Connected.Collections;
using Connected.Customers.Service.Tickets.Dtos;
using Connected.Services;

namespace Connected.Customers.Service.Tickets;

internal sealed class InsertTicketAmbient(ITicketService tickets) : AmbientProvider<IInsertTicketDto>, IInsertTicketAmbient
{
	public string? Url { get; set; }

	protected override async Task OnInvoke()
	{
		if (Dto.Title is null)
			return;

		var existing = await tickets.Query(Dto.CreateHead(Dto.Head));

		Url = WebString.Create(Dto.Title, existing.Select(f => f.Url));
	}
}
