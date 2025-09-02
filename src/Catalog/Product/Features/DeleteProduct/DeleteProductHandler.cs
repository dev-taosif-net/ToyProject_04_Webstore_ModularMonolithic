﻿using Catalog.Product.Exceptions;

namespace Catalog.Product.Features.DeleteProduct;


public record DeleteProductCommand(Guid ProductId) : ICommand<DeleteProductResult>;

public record DeleteProductResult(bool IsSuccess);

internal class DeleteProductHandler(CatalogDbContext dbContext): ICommandHandler<DeleteProductCommand, DeleteProductResult>
{
    public async Task<DeleteProductResult> Handle(DeleteProductCommand command, CancellationToken cancellationToken)
    {
        var product = await dbContext.Products
            .FindAsync([command.ProductId], cancellationToken: cancellationToken);

        if (product is null)
        {
            throw new ProductNotFoundException(command.ProductId);
        }

        dbContext.Products.Remove(product);
        await dbContext.SaveChangesAsync(cancellationToken);

        return new DeleteProductResult(true);
    }
}