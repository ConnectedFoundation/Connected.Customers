namespace Connected.Customers.Service;

public static class ServiceUrls
{
	private const string Namespace = "services/customers/service";

	public const string Tickets = $"{Namespace}/tickets";
	public const string TicketComments = $"{Namespace}/tickets/comments";
	public const string Desks = $"{Namespace}/desks";
	public const string TicketTexts = $"{Namespace}/tickets/texts";

	public const string SelectByUrlOperation = "select-by-url";
}
