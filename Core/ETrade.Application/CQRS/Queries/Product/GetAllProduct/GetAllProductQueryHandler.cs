﻿using MediatR;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using ETrade.Application.Repositories.ProductRepository;

namespace ETrade.Application.CQRS.Queries.Product.GetAllProduct;

public class GetAllProductQueryHandler(IProductReadRepository productReadRepository, ILogger<GetAllProductQueryHandler> logger) : IRequestHandler<GetAllProductQueryRequest, GetAllProductQueryResponse>
{
    readonly IProductReadRepository _productReadRepository = productReadRepository;
    readonly ILogger<GetAllProductQueryHandler> _logger = logger;

    public async Task<GetAllProductQueryResponse> Handle(GetAllProductQueryRequest request, CancellationToken cancellationToken)
    {
        _logger.LogInformation("Get all products");

        var totalProductCount = _productReadRepository.GetAll(false).Count();

        var products = _productReadRepository.GetAll(false).Skip(request.Page * request.Size).Take(request.Size)
            .Include(p => p.ProductImageFiles)
            .Select(p => new
            {
                p.Id,
                p.Name,
                p.Stock,
                p.Price,
                p.CreatedDate,
                p.UpdatedDate,
                p.ProductImageFiles
            }).ToList();

        return new()
        {
            Products = products,
            TotalProductCount = totalProductCount
        };
    }
}