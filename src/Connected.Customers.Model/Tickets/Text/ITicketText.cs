using Connected.Documents.Text;
using Connected.Entities;

namespace Connected.Customers.Tickets.Text;

public interface ITicketText : IDocumentText<int>, IDistributedEntity<int, int>
{

}
