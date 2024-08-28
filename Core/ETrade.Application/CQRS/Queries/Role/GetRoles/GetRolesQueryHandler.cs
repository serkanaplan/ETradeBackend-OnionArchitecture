using ETrade.Application.Abstractions.Services;
using MediatR;

namespace ETrade.Application.CQRS.Queries.Role.GetRoles;

public class GetRolesQueryHandler(IRoleService roleService) : IRequestHandler<GetRolesQueryRequest, GetRolesQueryResponse>
{
    readonly IRoleService _roleService = roleService;

    public async Task<GetRolesQueryResponse> Handle(GetRolesQueryRequest request, CancellationToken cancellationToken)
    {
        var (datas, count) = _roleService.GetAllRoles(request.Page, request.Size);
        return new()
        {
            Datas = datas,
            TotalCount = count
        };
    }
}
