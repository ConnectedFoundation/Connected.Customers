using Connected.Documents.Comments.Dtos;

namespace Connected.Customers.Service.Tickets.Comments.Dtos;

public interface IInsertTicketCommentDto : ITicketCommentDto, IInsertDocumentCommentDto<int>
{
}
