using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using System.Threading.Tasks;
using VideoStore.Application.Categories.Interfaces;
using VideoStore.Domain.Categories.Entities;

namespace VideoStore.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpPost]
        public async Task<IActionResult> Create(Category category)
        {
            return new JsonResult(await _categoryService.CreateCategory(category));
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var category = await _categoryService.GetAllCategoriesAsync();

            return new JsonResult(category);
        }

        [HttpPost]
        [Route("{id}")]
        public async Task<IActionResult> Update([FromBody] Category category)
        {
            return new JsonResult(await _categoryService.UpdateCategory(category));
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetById([FromRoute] string id)
        {
            return new JsonResult(await _categoryService.GetCategoryById(ObjectId.Parse(id)));
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> Remove([FromRoute] string id)
        {
            return new JsonResult(await _categoryService.DeleteCategory(ObjectId.Parse(id)));
        }
    }
}
