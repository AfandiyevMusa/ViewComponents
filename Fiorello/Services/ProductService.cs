using System;
using Fiorello.Areas.Admin.ViewModels.Product;
using Fiorello.Data;
using Fiorello.Models;
using Fiorello.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Fiorello.Services
{
    public class ProductService : IProductService
    {
        private readonly AppDbContext _context;
        private readonly IHttpContextAccessor _accessor;

        public ProductService(AppDbContext context, IHttpContextAccessor accessor)
        {
            _context = context;
            _accessor = accessor;
        }

        public async Task<IEnumerable<Product>> GetAllAsync()
        {
            return await _context.products.Include(m => m.Images).Take(8).Where(m => !m.SoftDelete).ToListAsync();
        }

        public async Task<List<Product>> GetAllWithIncludesAsync()
        {
            return await _context.products.Include(m => m.Images).Include(m => m.Category).Include(m => m.Discount).ToListAsync();
        }

        public async Task<Product> GetByIdAsync(int? id)
        {
            return await _context.products.FindAsync(id);
        }

        public async Task<Product> GetByIdWithImagesAsync(int? id)
        {
            return await _context.products.Include(m => m.Images).FirstOrDefaultAsync(m => m.Id == id);
        }

        public List<ProductVM> GetMappedDatas(List<Product> products)
        {
            List<ProductVM> list = new();
            foreach (var product in products)
            {
                list.Add(new ProductVM
                {
                    Id = product.Id,
                    Name = product.Name,
                    Description = product.Description,
                    Price = product.Price,
                    Image = product.Images.FirstOrDefault().Images,
                    CategoryName = product.Category.Name,
                    Discount = product.Discount.Name
                });
            }

            return list;
        }

        public ProductDetailVM GetMappedData(Product product)
        {
            return new ProductDetailVM
            {
                Name = product.Name,
                Description = product.Description,
                Price = product.Price.ToString("0.####"),
                Discount = product.Discount.Name,
                CategoryName = product.Category.Name,
                CreateDate = product.CreatedDate.ToString("MM/dd/yyyy"),
                Images = product.Images.Select(m => m.Images) 
            };
        }

        public async Task<Product> GetWithIncludesAsync(int id)
        {
            return await _context.products.Where(m => m.Id == id).Include(m => m.Images).Include(m => m.Category).Include(m => m.Discount).FirstOrDefaultAsync();
        }
    }
}

