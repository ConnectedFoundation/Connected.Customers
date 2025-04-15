using Connected.Entities;
using Connected.Services;

namespace Connected.Customers.Service.Desks.Dtos;

public interface IDeskDto : IDto
{
	string Name { get; set; }
	Status Status { get; set; }
}
