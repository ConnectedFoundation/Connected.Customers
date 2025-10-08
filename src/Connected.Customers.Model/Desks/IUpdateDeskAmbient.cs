using Connected.Customers.Desks.Dtos;
using Connected.Services;

namespace Connected.Customers.Desks;

public interface IUpdateDeskAmbient : IAmbientProvider<IUpdateDeskDto>
{
	string Url { get; set; }
}
