﻿using Shared.Pagination;

namespace Catalog.Product.Features.GetProducts;

public record GetProductsQuery(PaginationRequest request) : IQuery<GetProductsResult>;

public record GetProductsResult(PaginatedResult<ProductDto> Result);

internal class GetProductsHandler(CatalogDbContext dbContext) : IQueryHandler<GetProductsQuery, GetProductsResult>
{
    public async Task<GetProductsResult> Handle(GetProductsQuery query, CancellationToken cancellationToken)
    {
        var pageIndex = query.request.PageIndex;
        var pageSize = query.request.PageSize;

        var totalCount = await dbContext.Products.LongCountAsync(cancellationToken);

        var products = await dbContext.Products
            .AsNoTracking()
            .OrderBy(p => p.Name)
            .Skip(pageSize * (pageIndex-1))
            .Take(pageSize)
            .ToListAsync(cancellationToken);

        var productDtos = products.Adapt<List<ProductDto>>();

        return new GetProductsResult(new PaginatedResult<ProductDto>(pageIndex,pageSize,totalCount,productDtos));

    }
}