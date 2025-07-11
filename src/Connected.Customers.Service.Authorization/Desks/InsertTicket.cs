﻿using Connected.Annotations;
using Connected.Authorization.Services;
using Connected.Customers.Service.Tickets;
using Connected.Customers.Service.Tickets.Dtos;
using Connected.Membership.Annotations;

namespace Connected.Customers.Service.Desks;

[Middleware<ITicketService>(nameof(ITicketService.Insert))]
[Claims(DeskClaims.InsertTicket)]
internal sealed class InsertTicket : ServiceOperationAuthorization<IInsertTicketDto>
{
	public override string? Type => ServiceMetaData.DeskKey;

	public override string? PrimaryKey => Dto.Head.ToString();
}
