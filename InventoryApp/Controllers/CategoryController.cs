//using InventoryModels.DTOs;
//using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.Mvc;

//namespace InventoryApp.Controllers
//{
//    [Route("api/[controller]")]
//    [ApiController]
//    public class CategoryController : ControllerBase
//    {
//        private readonly I _categoryService;

//        public CategoryController(ICategoryService categoryService)
//        {
//            _categoryService = categoryService;
//        }

//        // GET: api/category
//        [HttpGet]
//        public async Task<IActionResult> GetAll()
//        {
//            var categories = await _categoryService.GetAllAsync();
//            return Ok(categories);
//        }

//        // GET: api/category/5
//        [HttpGet("{id}")]
//        public async Task<IActionResult> GetById(int id)
//        {
//            var category = await _categoryService.GetByIdAsync(id);

//            if (category == null)
//                return NotFound("Category not found");

//            return Ok(category);
//        }

//        // POST: api/category
//        [HttpPost]
//        public async Task<IActionResult> Create(CategoryDto dto)
//        {
//            var createdCategory = await _categoryService.CreateAsync(dto);
//            return Ok(createdCategory);
//        }

//        // PUT: api/category/5
//        [HttpPut("{id}")]
//        public async Task<IActionResult> Update(int id, CategoryDto dto)
//        {
//            var result = await _categoryService.UpdateAsync(id, dto);

//            if (!result)
//                return NotFound("Category not found");

//            return Ok("Category updated successfully");
//        }

//        // DELETE: api/category/5
//        [HttpDelete("{id}")]
//        public async Task<IActionResult> Delete(int id)
//        {
//            var result = await _categoryService.DeleteAsync(id);

//            if (!result)
//                return NotFound("Category not found");

//            return Ok("Category deleted successfully");
//        }
//    }
//}

