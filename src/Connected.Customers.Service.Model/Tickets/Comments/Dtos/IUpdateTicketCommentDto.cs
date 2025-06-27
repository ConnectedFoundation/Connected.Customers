using Connected.Documents.Comments.Dtos;

namespace Connected.Customers.Service.Tickets.Comments.Dtos;

public interface IUpdateTicketCommentDto : ITicketCommentDto, IUpdateDocumentCommentDto<int>
{
}
