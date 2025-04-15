using Connected.Annotations.Entities;
using Connected.Customers.Service.Desks;

namespace Connected.Customers.Service;

public static class ServiceMetaData
{
	public const string DeskKey = $"{SchemaAttribute.CustomersSchema}.{nameof(IDesk)}";
}
