using Connected.ServiceModel.Storage;

namespace Connected.Customers.Tickets;

internal class TicketPathParser
{
	public int? Desk { get; private set; }
	public int? Ticket { get; private set; }

	public void Parse(string filePath)
	{
		Desk = null;
		Ticket = null;

		if (!filePath.StartsWith(ServiceMetaData.TicketFilesRootDirectory))
			return;

		var tokens = filePath.Substring(ServiceMetaData.TicketFilesRootDirectory.Length).Split(StorageMetaData.PathSeparator, StringSplitOptions.RemoveEmptyEntries);

		if (tokens.Length < 2)
			return;

		if (int.TryParse(tokens[1], out int deskId))
			Desk = deskId;

		if (int.TryParse(tokens[1], out int ticketId))
			Ticket = ticketId;
	}
}