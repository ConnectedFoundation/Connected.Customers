using Connected.Customers.Service.Desks;
using Connected.Customers.Service.Tickets.Dtos;
using Connected.Services;
using Connected.Validation;

namespace Connected.Customers.Service.Tickets.Validation;

internal sealed class InsertTicketValidator(IDeskService desks)
	: Validator<IInsertTicketDto>
{
	protected override async Task OnInvoke()
	{
		if (await desks.Select(Dto.CreatePrimaryKey(Dto.Head)) is null)
			throw ValidationExceptions.NotFound(nameof(Dto.Head), Dto.Head);
	}
}
