using InventoryModels.DTOs;
using InventoryModels.Entity;
using InventoryService.Repository;
using InventoryService.Services.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryService.Services.Services
{
    public class ProductService : IProductService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IRepository<Product> _productRepo;

        public ProductService(IUnitOfWork unitOfWork, IRepository<Product> productRepo)
        {
            _unitOfWork = unitOfWork;
            _productRepo = productRepo;
        }

        public async Task<IEnumerable<ProductDto>> GetAllProductsAsync()
        {
            var products = await _productRepo.GetAllAsync();

            return products.Select(p => new ProductDto
            {
                Id = p.Id,
                Name = p.Name,
                SKU = p.SKU,
                CategoryId = p.CategoryId
            });
        }

        public async Task<ProductDto?> GetProductByIdAsync(int id)
        {
            var product = await _productRepo.GetByIdAsync(id);

            if (product == null)
                return null;

            return new ProductDto
            {
                Id = product.Id,
                Name = product.Name,
                SKU = product.SKU,
                CategoryId = product.CategoryId
            };
        }

        public async Task<ProductDto> CreateProductAsync(ProductDto dto)
        {
            var product = new Product
            {
                Name = dto.Name,
                SKU = dto.SKU,
                CategoryId = dto.CategoryId
            };

            await _productRepo.CreateAsync(product);
            await _unitOfWork.SaveAsync();

            dto.Id = product.Id;

            return dto;
        }

        public async Task UpdateProductAsync(int id, ProductDto dto)
        {
            var product = await _productRepo.GetByIdAsync(id);

            if (product == null)
                throw new Exception("Product not found");

            product.Name = dto.Name;
            product.SKU = dto.SKU;
            product.CategoryId = dto.CategoryId;

            _productRepo.Update(product);

            await _unitOfWork.SaveAsync();
        }

        public async Task DeleteProductAsync(int id)
        {
            var product = await _productRepo.GetByIdAsync(id);

            if (product == null)
                throw new Exception("Product not found");

            _productRepo.Delete(product);

            await _unitOfWork.SaveAsync();
        }
    }
}
