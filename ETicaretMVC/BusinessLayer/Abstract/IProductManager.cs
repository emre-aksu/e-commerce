using ModelLayer.Entities;
using ModelLayer.JsonResponseObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IProductManager
    {
        Task<List<Product>> GetProducts(params string[] includeList);
        Task<List<Product>> GetByPrice(decimal min, decimal max);
        Task<Product> GetById(int id, params string[] includeList);
        Task<ProductJsonResponseObject> GetProductById(int id, params string[] includeList);
    }
}
