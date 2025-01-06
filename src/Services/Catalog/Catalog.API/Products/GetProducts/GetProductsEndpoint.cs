﻿
namespace Catalog.API.Products.GetProducts
{
    //public record GetProductRequest();
    public record GetProductsResponse(IEnumerable<Product> products);

    public class GetProductsEndpoint : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapGet("products", async (ISender sender) =>
            {
                var result = await sender.Send(new GetProductsQuery());
                var response = result.Adapt<GetProductsResponse>();
                return Results.Ok(response);
            });
        }
    }
}
