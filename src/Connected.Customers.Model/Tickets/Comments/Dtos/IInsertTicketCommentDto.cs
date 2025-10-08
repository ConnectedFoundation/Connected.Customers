using Connected.Documents.Comments.Dtos;

namespace Connected.Customers.Tickets.Comments.Dtos;

public interface IInsertTicketCommentDto : ITicketCommentDto, IInsertDocumentCommentDto<int>
{
}
