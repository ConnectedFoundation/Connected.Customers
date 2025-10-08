using Connected.Documents.Comments.Dtos;

namespace Connected.Customers.Tickets.Comments.Dtos;

public interface IUpdateTicketCommentDto : ITicketCommentDto, IUpdateDocumentCommentDto<int>
{
}
