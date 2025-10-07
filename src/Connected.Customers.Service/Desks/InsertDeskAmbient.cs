using Connected.Collections;
using Connected.Customers.Service.Desks.Dtos;
using Connected.Services;

namespace Connected.Customers.Service.Desks;

internal sealed class InsertDeskAmbient(IDeskService desks) : AmbientProvider<IInsertDeskDto>, IInsertDeskAmbient
{
	public required string Url { get; set; }

	protected override async Task OnInvoke()
	{
		Url = WebString.Create(Dto.Name, (await desks.Query(null)).Select(f => f.Url));
	}
}
