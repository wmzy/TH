using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using TH.Repositories.Entities;

namespace TH.Repositories
{
public interface IProductRepository
{
    IEnumerable<Product> GetProducts(int pageIndex, int pageSize, out int recordCount);
    IEnumerable<Product> GetProductsByGenre(string genre, int pageIndex, int pageSize, out int recordCount);
    IEnumerable<Product> GetProductsByActor(string actor, int pageIndex, int pageSize, out int recordCount);
    Product GetProduct(string productId);
}
}
