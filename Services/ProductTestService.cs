using Microsoft.EntityFrameworkCore;
using BackEnd.SuperMarket.Data;
using BackEnd.SuperMarket.DTOs;
using BackEnd.SuperMarket.Models;
using BackEnd.SuperMarket.Utilities;
using System.Threading.Tasks;
using System.Linq;
using System;

namespace BackEnd.SuperMarket.Services
{
    public interface IProductTestService
    {
        Task<PaginationResult<ProductDto>> GetProductsAsync(int page = 1, int pageSize = 10, string searchQuery = "");
        Task<ProductDto> GetByIdAsync(int id);
        Task<ProductTest> PostAsync(ProductAddDto product);
        Task<ProductTest> UpdateAsync(int id, ProductUpdateDto product);
        Task<bool> DeleteAsync(int id);
    }
    public class ProductTestService :   IProductTestService

    {
        private readonly AppDbContext _db;
        public ProductTestService(AppDbContext db)
        {
            _db = db;
        }

        public async Task<PaginationResult<ProductDto>> GetProductsAsync(int page = 1, int pageSize = 10, string searchQuery = "")
        {
            var entities = await _db.ProductTests
                                    .AsNoTracking()
                                    .Select(x => new ProductDto
                                    {
                                        Id = x.Id,
                                        Name = x.Name,
                                        Price = x.Price,
                                        Quantity = x.Quantity,
                                        PricePartial = x.PricePartial
                                    }).ToListAsync();

            var filteredProducts = string.IsNullOrEmpty(searchQuery)
        ? entities
        : entities.Where(p => p.Name.Contains(searchQuery, StringComparison.OrdinalIgnoreCase));

            var totalItems = filteredProducts.Count();
            var totalPages = (int)Math.Ceiling(totalItems / (double)pageSize);

            var paginatedProducts = filteredProducts
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToList();

            var paginationResult = new PaginationResult<ProductDto>
            {
                TotalItems = totalItems,
                TotalPages = totalPages,
                Page = page,
                PageSize = pageSize,
                Items = paginatedProducts
            };

            return paginationResult;
        }
        public async Task<ProductDto> GetByIdAsync(int id)
        {
            var entity = await _db.ProductTests
                                  .AsNoTracking()
                                  .Select(x => new ProductDto
                                  {
                                      Id = x.Id,
                                      Name = x.Name,
                                      Quantity = x.Quantity,
                                      Price = x.Price,
                                      PricePartial = x.PricePartial
                                  }).FirstOrDefaultAsync();
            if (entity == null) throw new Exception("Product not found");
            return entity;
        }
        public async Task<ProductTest> PostAsync(ProductAddDto product)
        {
            var newProduct = new ProductTest();
            newProduct.Name = product.Name;
            newProduct.Quantity = product.Quantity;
            newProduct.Price = product.Price;
            newProduct.PricePartial = product.Price * product.Quantity;
            _db.ProductTests.Add(newProduct);
            await _db.SaveChangesAsync();
            return newProduct;
        }
        public async Task<ProductTest> UpdateAsync(int id, ProductUpdateDto product)
        {
            var entityUpdate = await _db.ProductTests.FindAsync(id);
            if (entityUpdate == null) throw new Exception("Product not found");

            entityUpdate.Name = product.Name;
            entityUpdate.Quantity = product.Quantity;
            entityUpdate.Price = product.Price;
            entityUpdate.PricePartial = product.Price * product.Quantity;
            await _db.SaveChangesAsync();
            return entityUpdate;
        }
        public async Task<bool> DeleteAsync(int id)
        {
            var entityForDelete = await _db.ProductTests.FindAsync(id);
            if (entityForDelete == null) throw new Exception("Product not found");
            _db.ProductTests.Remove(entityForDelete);
            await _db.SaveChangesAsync();
            return true;
        }
        
    }
}
