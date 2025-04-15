using Connected.Collections;
using Connected.Customers.Service.Desks.Dtos;
using Connected.Services;

namespace Connected.Customers.Service.Desks;

internal sealed class UpdateDeskAmbient(IDeskService desks) : AmbientProvider<IUpdateDeskDto>, IUpdateDeskAmbient
{
	public required string Url { get; set; }

	protected override async Task OnInvoke()
	{
		Url = WebString.Create(Dto.Name, (await desks.Query(null)).Where(f => f.Id != Dto.Id).Select(f => f.Url));
	}
}
