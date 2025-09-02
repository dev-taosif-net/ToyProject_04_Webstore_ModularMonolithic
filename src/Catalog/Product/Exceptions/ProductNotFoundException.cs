using Shared.Exceptions;

namespace Catalog.Product.Exceptions;

public class ProductNotFoundException : NotFoundException
{
    public ProductNotFoundException(Guid Id) : base("Product", id)
    {
    }
}
