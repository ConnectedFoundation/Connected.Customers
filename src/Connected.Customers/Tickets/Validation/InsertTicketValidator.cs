using Connected.Customers.Desks;
using Connected.Customers.Tickets.Dtos;
using Connected.Services;
using Connected.Services.Validation;

namespace Connected.Customers.Tickets.Validation;

internal sealed class InsertTicketValidator(IDeskService desks)
	: Validator<IInsertTicketDto>
{
	protected override async Task OnInvoke()
	{
		if (await desks.Select(Dto.CreatePrimaryKey(Dto.Head)) is null)
			throw ValidationExceptions.NotFound(nameof(Dto.Head), Dto.Head);
	}
}
