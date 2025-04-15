using Connected.Customers.Service.Desks.Dtos;
using Connected.Services;

namespace Connected.Customers.Service.Desks;

public interface IInsertDeskAmbient : IAmbientProvider<IInsertDeskDto>
{
	string Url { get; set; }
}
