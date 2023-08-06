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
    public interface ICategoryService
    {
        Task<PaginationResult<CategoryDto>> GetCategoriesAsync(int page = 1, int pageSize = 10, string searchQuery = "");
        Task<CategoryDto> GetCategoryAsync(int id);
        Task<int> CreateCategoryAsync(CategoryAddDto product);
        Task UpdateCategoryAsync(int id, CategoryDto product);
        Task DeleteCategoryAsync(int id);
    }
    public class CategoryService : ICategoryService
    {
        private const string NotFound = "Product not Found";
        private readonly AppDbContext _db;
        public CategoryService(AppDbContext db)
        {
            _db = db;
        }
        public async Task<PaginationResult<CategoryDto>> GetCategoriesAsync(int page = 1, int pageSize = 10, string searchQuery = "")
        {
            var entities = await _db.Categories
                                    .AsNoTracking()
                                    .Select(x => new CategoryDto
                                    {
                                        Id = x.Id,
                                        Name = x.Name
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

            var paginationResult = new PaginationResult<CategoryDto>
            {
                TotalItems = totalItems,
                TotalPages = totalPages,
                Page = page,
                PageSize = pageSize,
                Items = paginatedProducts
            };

            return paginationResult;
        }
        public async Task<CategoryDto> GetCategoryAsync(int id)
        {
            var category = await _db.Categories.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);

            var categoryDto = new CategoryDto
            {
                Id = category.Id,
                Name = category.Name
            };
            return categoryDto;
        }
        public async Task<int> CreateCategoryAsync(CategoryAddDto categoryDto)
        {
            var category = new Category();
            category.Name = categoryDto.Name;
            _db.Categories.Add(category);
            await _db.SaveChangesAsync();
            return category.Id;
        }

        public async Task DeleteCategoryAsync(int id)
        {
            var category = await _db.Categories.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
            if (category != null)
            {
                _db.Categories.Remove(category);
                await _db.SaveChangesAsync();
            }

            await Task.FromResult(false);
        }

        public async Task UpdateCategoryAsync(int id, CategoryDto category)
        {
            var existingCategory = await _db.Categories.FirstOrDefaultAsync(x => x.Id == id);
            if (existingCategory != null)
            {
                existingCategory.Name = category.Name;
                _db.Categories.Update(existingCategory);
                await _db.SaveChangesAsync();
            }

            await Task.FromResult(existingCategory);
        }
    }
}