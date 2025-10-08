using Connected.Annotations;

namespace Connected.Customers.Desks.Dtos;

internal sealed class UpdateDeskDto : DeskDto, IUpdateDeskDto
{
	[MinValue(1)]
	public int Id { get; set; }
}
