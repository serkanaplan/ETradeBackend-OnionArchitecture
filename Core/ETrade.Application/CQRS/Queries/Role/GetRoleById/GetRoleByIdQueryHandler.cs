using ETrade.Application.Abstractions.Services;
using MediatR;

namespace ETrade.Application.CQRS.Queries.Role.GetRoleById;

public class GetRoleByIdQueryHandler(IRoleService roleService) : IRequestHandler<GetRoleByIdQueryRequest, GetRoleByIdQueryResponse>
{
    readonly IRoleService _roleService = roleService;

    public async Task<GetRoleByIdQueryResponse> Handle(GetRoleByIdQueryRequest request, CancellationToken cancellationToken)
    {
        var (id, name) = await _roleService.GetRoleById(request.Id);
        return new()
        {
            Id = id,
            Name = name
        };
    }
}
