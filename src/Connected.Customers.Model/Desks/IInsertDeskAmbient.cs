using Connected.Customers.Desks.Dtos;
using Connected.Services;

namespace Connected.Customers.Desks;

public interface IInsertDeskAmbient : IAmbientProvider<IInsertDeskDto>
{
	string Url { get; set; }
}
