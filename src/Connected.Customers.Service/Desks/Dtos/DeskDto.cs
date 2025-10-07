using Connected.Entities;
using Connected.Services;
using System.ComponentModel.DataAnnotations;

namespace Connected.Customers.Service.Desks.Dtos;

internal abstract class DeskDto : Dto, IDeskDto
{
	[Required, MaxLength(128)]
	public required string Name { get; set; }

	public Status Status { get; set; }
}
