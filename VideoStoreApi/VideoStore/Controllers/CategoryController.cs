using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using System.Threading.Tasks;
using VideoStore.Application.Categories.Interfaces;
using VideoStore.Domain.Categories.Contracts;
using VideoStore.Domain.Categories.Entities;
using VideoStore.Domain.Models.Enums;

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
        public async Task<IActionResult> Create(CategoryCommand category)
        {
            var response = await _categoryService.CreateCategory(category.SetOperation(Operation.Insert));
            
            Response.StatusCode = (int)response.StatusCode;
            
            return new JsonResult(response);
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var response = _categoryService.GetAllCategories();
            
            Response.StatusCode = (int)response.StatusCode;

            return new JsonResult(response);
        }

        [HttpPost]
        [Route("{id}")]
        public async Task<IActionResult> Update(CategoryCommand category)
        {
            var response = await _categoryService.UpdateCategory(category.SetOperation(Operation.Update));
            
            Response.StatusCode = (int)response.StatusCode;

            return new JsonResult(response);
        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult GetById([FromRoute] string id)
        {
            var response = _categoryService.GetCategoryById(ObjectId.Parse(id));

            Response.StatusCode = (int)response.StatusCode;

            return new JsonResult(response);
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> Remove([FromRoute] string id)
        {
            var response = await _categoryService.DeleteCategory(ObjectId.Parse(id));

            Response.StatusCode = (int)response.StatusCode;

            return new JsonResult(response);
        }
    }
}
