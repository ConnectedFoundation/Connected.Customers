using Connected.ServiceModel.Storage.Dtos;

namespace Connected.Customers.Tickets;

public static class TicketExtensions
{
	public static bool IsTicketDirectory(this IFileDto dto)
	{
		if (dto.Directory is null)
			return false;

		return dto.Directory.StartsWith(ServiceMetaData.TicketFilesRootDirectory);
	}
}