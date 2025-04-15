using Connected.Customers.Service.Desks.Dtos;
using Connected.Services;

namespace Connected.Customers.Service.Desks;

public interface IUpdateDeskAmbient : IAmbientProvider<IUpdateDeskDto>
{
	string Url { get; set; }
}
