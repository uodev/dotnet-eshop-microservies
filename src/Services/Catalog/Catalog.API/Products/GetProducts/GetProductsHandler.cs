using Marten.Pagination;

namespace Catalog.API.Products.GetProducts;

public record GetProductsQuery(int? PageNumber = 1, int? PageSize = 10) : IQuery<GetProductsResult>;

public record GetProductsResult(
    IEnumerable<Product> Products,
    long TotalCount,
    long PageSize,
    bool HasPreviousPage,
    bool HasNextPage);

internal class GetProductsQueryHandler(IDocumentSession session)
    : IQueryHandler<GetProductsQuery, GetProductsResult>
{
    public async Task<GetProductsResult> Handle(GetProductsQuery query, CancellationToken cancellationToken)
    {
        var products = await session.Query<Product>()
            .ToPagedListAsync(query.PageNumber ?? 1, query.PageSize ?? 10, cancellationToken);

        return new GetProductsResult(
            products,
            products.TotalItemCount,
            products.PageSize,
            products.HasPreviousPage,
            products.HasNextPage);
    }
}