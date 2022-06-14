using Ecommercetask.Data.Data;
using Ecommercetask.Data.Model;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommercetask.Core.Handlers.ProductHandler.Queries.GetProductById
{
    public class GetProductByIdQuery : IRequest<ProductModel>
    {
        public int Id { get; set; }
    }

    public class GetProductByIdHandler : IRequestHandler<GetProductByIdQuery, ProductModel>
    {
        private readonly EcommerceSiteContext _db = null;

        public GetProductByIdHandler(EcommerceSiteContext db)
        {
            _db = db;
        }

        public async Task<ProductModel> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
        {

            var productbyid = await _db.Product.Where(d => d.Id == request.Id).FirstOrDefaultAsync();
            var product = new ProductModel()
            {
                Id = productbyid.Id,
                Product_Name = productbyid.Product_Name,
                Description = productbyid.Description,
                Brand = productbyid.Brand,
                Price = productbyid.Price,
                Product_Subcategory_Id = productbyid.Product_Subcategory_Id,
                Quantity = productbyid.Quantity,
                Image = productbyid.Image,
                Is_Active = productbyid.Is_Active,
            };
            return product;
        }
    }
}
